using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Example
{
    using UglyLoader;

    class Program
    {
        static void Main(string[] args)
        {
            var container = new ContainerBuilder();


            UglyLoaderApiBuilder.Build()
                .LoadAssemblies<IContainerConfig>(act => act.ConfigIoCContainer(container));

            var builder = container.Build();
            using (var scope = builder.BeginLifetimeScope())
            {
                IEnumerable<IRandomGenerator> generators =
                    scope.Resolve<IEnumerable<IRandomGenerator>>();           

                foreach (var item in generators)
                {
                    Console.WriteLine(item.Next());
                }
            }


            Console.ReadLine();
        }
    }
}
