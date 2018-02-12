namespace Autofac.Example
{
    public class ExampleInitialization : IContainerConfig
    {
        public void ConfigIoCContainer(ContainerBuilder container)
        {
            container.RegisterInstance(new RandomInteger()).As<IRandomGenerator>();
            container.RegisterInstance(new RandomString()).As<IRandomGenerator>();
        }
    }
}
