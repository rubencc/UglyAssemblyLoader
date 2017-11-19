namespace Acceptance.Test
{
    using System;
    using UglyLoader.Implementations;

    class Program
    {
        static void Main(string[] args)
        {
            UglyLoaderApiBuilder.Build<IShouldLoad>()
                .LoadAssemblies(act => act.ExampleMethod("it works"));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
