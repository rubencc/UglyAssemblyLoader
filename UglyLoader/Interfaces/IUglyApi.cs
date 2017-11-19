namespace UglyLoader.Interfaces
{
    using System;

    public interface IUglyLoaderApi<out TType>
        where TType : class
    {
        IUglyLoaderApi<TType> UsePath(string path);
        void LoadAssemblies(Action<TType> buildAction);
    }
}
