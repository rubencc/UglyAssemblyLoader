namespace Acceptance.Test
{
    using System;

    public class AnotherClassToLoad : IShouldLoad, IShouldLoadToo
    {
        public void ExampleMethod(string value)
        {
            Console.WriteLine($"Execute class: {nameof(AnotherClassToLoad)} with value: {value}");
        }

        public void AnotherMethod()
        {
            Console.WriteLine("It has ben loaded");
        }
    }
}
