namespace UglyLoader
{
    using System;

    internal sealed class UglyLoaderApi: IUglyLoaderApi
        
    {
        private string pathFiles;
        private readonly IAssemblyLoader loader;

        public UglyLoaderApi()
        {
            this.loader = new AssemblyLoader();
        }

        public IUglyLoaderApi UsePath(string path)
        {
            if(String.IsNullOrEmpty(path))
                throw new ArgumentException("null path");
            this.pathFiles = path;

            return this;
        }

        public IUglyLoaderApi LoadAssemblies<TType>(Action<TType> buildAction) where TType : class
        {
            if (String.IsNullOrEmpty(this.pathFiles))
            {
                this.loader.LoadAssemblies(buildAction);
            }
            else
            {
                this.loader.LoadAssemblies(buildAction, this.pathFiles);
            }

            return this;
        }
    }
}
