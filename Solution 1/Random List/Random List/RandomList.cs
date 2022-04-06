using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class RandomList : List<string>
    {

        private Random random;

        public RandomList()
        {
            random = new Random();
        }
        public string GetRandomElement()
        {
            var index = random.Next(0, Count);
            return this[index];
        }

        public string RemoveElement()
        {
            var index = random.Next(0, this.Count);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }

    }
}
