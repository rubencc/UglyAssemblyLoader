namespace Acceptance.Test
{
    using System;

    public class ShouldLoadImplementation : IShouldLoad
    {
        public void ExampleMethod(string value)
        {
            Console.WriteLine($"Executin class: {nameof(ShouldLoadImplementation)} with value {value}");
        }
    }
}
