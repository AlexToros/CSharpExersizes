using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_3_2
{
    
    struct ConveyerControl
    {
        public enum Action
        {
            Stop,
            Start,
            Forward,
            Back
        }

        public void Conveyer(Action action)
        {
            switch (action)
            {
                case Action.Stop:
                    Console.Write("Работа ковейера\nОстановка!\r");
                    break;
                case Action.Start:
                    Console.Write("Работа ковейера\nЗапуск!\r");
                    break;
                case Action.Forward:
                    Console.Write("Работа ковейера\nПеремещение вперед!\r");
                    break;
                case Action.Back:
                    Console.Write("Работа ковейера\nПеремещение назад!\r");
                    break;
                default:
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConveyerControl conveyerControl = new ConveyerControl();
            conveyerControl.Conveyer(ConveyerControl.Action.Stop);
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        conveyerControl.Conveyer(ConveyerControl.Action.Stop);
                        break;
                    case ConsoleKey.RightArrow:
                        conveyerControl.Conveyer(ConveyerControl.Action.Start);
                        break;
                    case ConsoleKey.UpArrow:
                        conveyerControl.Conveyer(ConveyerControl.Action.Forward);
                        break;
                    case ConsoleKey.DownArrow:
                        conveyerControl.Conveyer(ConveyerControl.Action.Back);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
