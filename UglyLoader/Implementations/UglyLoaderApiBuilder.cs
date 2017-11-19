namespace UglyLoader.Implementations
{
    using Interfaces;

    public sealed class UglyLoaderApiBuilder
    {
        IUglyLoaderApi<TType> Build<TType>()
            where TType : class
        {
            return new UglyLoaderApi<TType>();
        }
    }
}
