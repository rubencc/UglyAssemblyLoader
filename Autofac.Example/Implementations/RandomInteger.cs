namespace Autofac.Example
{
    using System;

    public class RandomInteger : IRandomGenerator
    {
        private readonly Random rd;

        public RandomInteger()
        {
            this.rd = new Random();
        }

        public string Next()
        {
            return this.rd.Next().ToString();
        }
    }
}
