namespace Acceptance.Test
{
    using UglyLoader.Implementations;

    class Program
    {
        static void Main(string[] args)
        {
            UglyLoaderApiBuilder.Build<IShouldLoad>()
                .LoadAssemblies(act => act.ExampleMethod("it works"));
        }
    }
}
