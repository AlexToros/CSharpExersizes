using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_9_2
{
    class NaturalNumber
    {
        private int _pow;
        public int Pow
        {
            get => (int)Math.Pow(Ground, _pow);
            set => _pow = value;
        }
        public int Ground { get; set; }

        public NaturalNumber(int pow, int ground)
        {
            _pow = pow;
            Ground = ground;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NaturalNumber n = new NaturalNumber(2, 33);
            Console.WriteLine(n.Pow);
        }
    }
}
