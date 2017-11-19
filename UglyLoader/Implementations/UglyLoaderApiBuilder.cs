namespace UglyLoader.Implementations
{
    using Interfaces;

    public sealed class UglyLoaderApiBuilder
    {
        public static IUglyLoaderApi Build()
           
        {
            return new UglyLoaderApi();
        }
    }
}
