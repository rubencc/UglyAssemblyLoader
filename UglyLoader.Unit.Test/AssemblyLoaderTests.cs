namespace UglyLoader.Unit.Test
{
    using FluentAssertions;
    using Xunit;

    public class AssemblyLoaderTests
    {
        [Fact(DisplayName = "Load assemblies succeed")]
        public void Load_assemblies_succeed()
        {
            AssemblyLoader api = new AssemblyLoader();
            int loaded = 0;

            api.LoadAssemblies<IToLoadInTest>(x =>
            {
                loaded = x.Execute();
            });

            loaded.Should().Be(88998899);
        }
    }
}
