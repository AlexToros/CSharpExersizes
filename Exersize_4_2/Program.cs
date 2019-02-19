using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Building House = new Building(BuildingType.House, 10, 600, 30);
            Building Office = new Building(BuildingType.Office, 3, 500);

            Console.WriteLine(House);
            Console.WriteLine(Office);

            Console.ReadLine();
        }
    }
}
