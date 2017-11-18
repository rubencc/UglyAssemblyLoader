namespace UglyLoader
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    public class AssemblyLoader : IAssemblyLoader
    {
        public void LoadAssemblies<TType>(Action<TType> buildAction)
            where TType : class
        {
            this.PreloadUnusedAssemblies(AppDomain.CurrentDomain);

            this.Load(buildAction);
        }

        public void LoadAssemblies<TType>(Action<TType> buildAction, string path) where TType : class
        {
            this.PreloadUnusedAssemblies(AppDomain.CurrentDomain, path);

            this.Load(buildAction);
        }

        private void Load<TType>(Action<TType> buildAction) where TType : class
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type item in assembly.GetTypes())
                {
                    if (!item.IsClass)
                        continue;

                    if (item.IsAbstract)
                        continue;

                    if (item.GetInterfaces().Contains(typeof(TType)))
                    {
                        Type[] argTypes = new Type[] { };
                        ConstructorInfo cInfo = item.GetConstructor(argTypes);
                        if (cInfo == null)
                            continue;

                        var loadedType = (TType)cInfo.Invoke(new object[] { });
                        buildAction.Invoke(loadedType);
                    }
                }
            }
        }

        private void PreloadUnusedAssemblies(AppDomain appDomain, string path)
        {
            var loaded = appDomain.GetAssemblies();
            var directory = new DirectoryInfo(path);
            var assemblies = directory.GetFiles("*.dll");
            if (!assemblies.Any())
            {
                return;
            }

            foreach (var info in assemblies)
            {
                if (!loaded.Any(assembly => !assembly.IsDynamic && assembly.Location.Contains(info.Name)))
                {
                    appDomain.Load(AssemblyName.GetAssemblyName(info.FullName));
                }
            }
        }

        private void PreloadUnusedAssemblies(AppDomain appDomain)
        {
            var loaded = appDomain.GetAssemblies();
            var directory = new DirectoryInfo(appDomain.SetupInformation.ApplicationBase);
            var assemblies = directory.GetFiles("*.dll");
            if (!assemblies.Any())
            {
                return;
            }

            foreach (var info in assemblies)
            {
                if (!loaded.Any(assembly => !assembly.IsDynamic && assembly.Location.Contains(info.Name)))
                {
                    appDomain.Load(AssemblyName.GetAssemblyName(info.FullName));
                }
            }
        }
    }
}
