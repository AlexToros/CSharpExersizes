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
            Back = 37,
            Start = 38,
            Forward = 39,
            Stop = 40,
        }

        public void Conveyer(Action action)
        {
            Console.WriteLine("Работа конвейера");
            switch (action)
            {
                case Action.Stop:
                    Console.WriteLine("Остановка!");
                    break;
                case Action.Start:
                    Console.WriteLine("Запуск!");
                    break;
                case Action.Forward:
                    Console.WriteLine("Перемещение вперед!");
                    break;
                case Action.Back:
                    Console.WriteLine("Перемещение назад!");
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
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                ConveyerControl.Action action = (ConveyerControl.Action)key.Key.GetHashCode();
                conveyerControl.Conveyer(action);
            }
        }
    }
}
