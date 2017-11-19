namespace Acceptance.Test
{
    using System;

    public class AnotherClassToLoad : IShouldLoad
    {
        public void ExampleMethod(string value)
        {
            Console.WriteLine($"Executin class: {nameof(AnotherClassToLoad)} with value: {value}");
        }
    }
}
