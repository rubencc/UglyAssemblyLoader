namespace UglyLoader
{
    using System;

    public interface ILoader
    {
        void LoadAssemblies<TType>(Action<TType> buildAction) where TType : class;
        void LoadAssemblies<TType>(Action<TType> buildAction, string path) where TType : class;
    }
}
