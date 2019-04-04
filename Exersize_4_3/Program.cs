using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Exersize_4_3
{

    class Program
    {
        static Game game;
        static ConsoleColor[] FormatColors = { ConsoleColor.Cyan, ConsoleColor.Green,ConsoleColor.Magenta,ConsoleColor.Yellow};
        static void Main(string[] args)
        {
            Car car = new Car(100,15,80);
            Airplane airplane = new Airplane(5000, 100, 10000);
            Horse horse = new Horse(20, 1, 50);
            Boat boat = new Boat(50, 10, 100);
            game = new Game(car, airplane, horse, boat);

            Timer timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            Console.WriteLine(Vehicle.Headers);
            timer.Start();
            Console.ReadLine();
            timer.Stop();
            Console.ReadLine();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int i = 0;
            foreach (var item in game.Move())
            {
                Console.ForegroundColor = FormatColors[i++];
                Console.WriteLine(item);
            }
        }
    }
}
