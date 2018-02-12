namespace UglyLoader.Unit.Test
{
    using FluentAssertions;
    using Xunit;

    public class UglyLoaderApiBuilderTests
    {
        [Fact(DisplayName = "Build succeed")]
        public void Build_succeed()
        {
            var builder = UglyLoaderApiBuilder.Build();

            builder.Should().BeAssignableTo<UglyLoaderApi>();
        }
    }
}
