namespace UglyLoader.Implementations
{
    using System;
    using Interfaces;

    internal sealed class UglyLoaderApi<TType> : IUglyLoaderApi<TType>
        where TType : class
    {
        private string pathFiles;
        private readonly IAssemblyLoader loader;

        public UglyLoaderApi()
        {
            this.loader = new AssemblyLoader();
        }

        public IUglyLoaderApi<TType> UsePath(string path)
        {
            if(String.IsNullOrEmpty(path))
                throw new ArgumentException("null path");
            this.pathFiles = path;

            return this;
        }

        public void LoadAssemblies(Action<TType> buildAction)
        {
            if (String.IsNullOrEmpty(this.pathFiles))
            {
                this.loader.LoadAssemblies(buildAction);
            }
            else
            {
                this.loader.LoadAssemblies(buildAction, this.pathFiles);
            }
        }
    }
}
