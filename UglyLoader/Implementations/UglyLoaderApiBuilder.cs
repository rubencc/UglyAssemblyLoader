namespace UglyLoader.Implementations
{
    using Interfaces;

    public sealed class UglyLoaderApiBuilder
    {
        public static IUglyLoaderApi<TType> Build<TType>()
            where TType : class
        {
            return new UglyLoaderApi<TType>();
        }
    }
}
