namespace Acceptance.Test
{
    using System;

    public class ShouldLoadImplementation : IShouldLoad
    {
        public void ExampleMethod(string value)
        {
            Console.WriteLine($"Execute class: {nameof(ShouldLoadImplementation)} with value: {value}");
        }
    }
}
