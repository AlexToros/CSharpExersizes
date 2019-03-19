using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_9_1
{
    class RandomArray
    {
        private Random rndGen;
        private long[] array;

        public int Length { get => array.Length; }
        public bool IsError { get; private set; }

        public RandomArray(int capacity)
        {
            array = new long[capacity];
            rndGen = new Random();
        }

        public long this[int x]
        {
            get
            {
                IsError = x < 0 || x > Length;
                if (IsError)
                    return -1;
                return array[x];
            }
            set
            {
                var pow = Math.Log(value, 2);

                IsError = x < 0 || x > Length || Math.Log(value, 2) % 1 == 0;
                if (!IsError)
                    array[x] = value;
            }
        }

        public long this[double x]
        {
            get => this[(int)Math.Round(x)];
            set => this[(int)Math.Round(x)] = value;
        }

        public void RandomInit()
        {
           array = Enumerable.Range(0, (int)Math.Log(long.MaxValue, 2))
                             .Select(x => (long)Math.Pow(2, x))
                             .OrderBy(x => rndGen.NextDouble())
                             .Take(Length)
                             .ToArray();            
        }

        public double AmmountOfDegrees()
        {
            var pows = array.Select(x => Math.Log(x, 2));
            return pows.Aggregate((x, y) => x * y) / pows.Sum();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var r = 0.3 % 1;
            var f = 4.0 % 1;
            var t = 4.9 % 1;
        }
    }
}
