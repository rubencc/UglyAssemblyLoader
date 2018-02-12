namespace Autofac.Example
{
    using System;
    using System.Collections.Generic;

    public class RandomString : IRandomGenerator
    {
        private readonly Dictionary<int, char> map;
        private readonly Random rd;

        public RandomString()
        {
            this.rd = new Random();
            this.map = new Dictionary<int, char>()
            {
                {0, 'A'},
                {1, 'B'},
                {2, 'C'},
                {3, 'D'},
                {4, 'E'},
                {5, 'F'},
                {6, 'G'},
                {7, 'H'},
                {8, 'I'},
                {9, 'J'},
            };
        }

        public string Next()
        {
            var length = rd.Next(0, 21);

            string result = String.Empty;
            
            for (int i = 0; i < length; i++)
            {
                var random = rd.Next(0, 9);
                result += this.map[random].ToString();
            }

            return result;
        }
    }
}
