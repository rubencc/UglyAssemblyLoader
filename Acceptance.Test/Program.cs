namespace Acceptance.Test
{
    using System;
    using UglyLoader.Implementations;

    class Program
    {
        static void Main(string[] args)
        {
            UglyLoaderApiBuilder.Build()
                .LoadAssemblies<IShouldLoad>(act => act.ExampleMethod("it works"))
                .LoadAssemblies<IShouldLoadToo>(act => act.AnotherMethod());


            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
