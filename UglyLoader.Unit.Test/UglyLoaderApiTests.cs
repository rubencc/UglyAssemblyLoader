namespace UglyLoader.Unit.Test
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class UglyLoaderApiTests
    {
        [Fact(DisplayName = "Use null path failed")]
        public void Use_path_null_failed()
        {
            UglyLoaderApi api = new UglyLoaderApi();

            Action act = () => api.UsePath(null);

            act.Should().Throw<ArgumentException>()
                .WithMessage("null path");

        }

        [Fact(DisplayName = "Use empty path failed")]
        public void Use_path_empty_failed()
        {
            UglyLoaderApi api = new UglyLoaderApi();

            Action act = () => api.UsePath(String.Empty);

            act.Should().Throw<ArgumentException>()
                .WithMessage("null path");

        }

        [Fact(DisplayName = "Load assemblies succeed")]
        public void Load_assemblies_succeed()
        {
            UglyLoaderApi api = new UglyLoaderApi();
            int loaded = 0;

            api.LoadAssemblies<IToLoadInTest>(x =>
            {
                loaded = x.Execute();
            });

            loaded.Should().Be(88998899);
        }
    }
}
