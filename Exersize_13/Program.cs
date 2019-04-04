using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country1 = new China(100, 5, 15, 25);
            Country country2 = new USA(100, 20, 30, 30);

            War.Start(country1, country2);

            Console.ReadLine();
        }
    }
}
