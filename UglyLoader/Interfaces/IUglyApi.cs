namespace UglyLoader
{
    using System;

    public interface IUglyLoaderApi
        
    {
        IUglyLoaderApi UsePath(string path);
        IUglyLoaderApi LoadAssemblies<TType>(Action<TType> buildAction) where TType : class;
    }
}
