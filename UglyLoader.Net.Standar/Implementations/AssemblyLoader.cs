[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("UglyLoader.Unit.Test")]
namespace UglyLoader
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    internal sealed class AssemblyLoader : IAssemblyLoader
    {
        public void LoadAssemblies<TType>(Action<TType> buildAction)
            where TType : class
        {
            this.LoadNotUsedAssemblies(AppDomain.CurrentDomain);

            this.Load(buildAction);
        }

        public void LoadAssemblies<TType>(Action<TType> buildAction, string path) where TType : class
        {
            this.LoadNotUsedAssemblies(AppDomain.CurrentDomain, path);

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

                    if (!item.GetInterfaces().Contains(typeof(TType)))
                        continue;

                    Type[] argTypes = new Type[] { };
                    ConstructorInfo cInfo = item.GetConstructor(argTypes);
                    if (cInfo == null)
                        continue;

                    var loadedType = (TType)cInfo.Invoke(new object[] { });
                    buildAction.Invoke(loadedType);

                }
            }
        }

        private void LoadNotUsedAssemblies(AppDomain appDomain, string path = null)
        {
            Assembly[] loaded = appDomain.GetAssemblies();

            string loadPath = String.IsNullOrEmpty(path) ? appDomain.BaseDirectory : path;

            DirectoryInfo directory = new DirectoryInfo(loadPath);
            FileInfo[] assemblies = directory.GetFiles("*.dll");
            if (!assemblies.Any())
            {
                return;
            }

            foreach (var info in assemblies)
            {
                if (!loaded.Any(x => !x.IsDynamic && x.Location.Contains(info.Name)))
                {
                    appDomain.Load(AssemblyName.GetAssemblyName(info.FullName));
                }
            }
        }
    }
}