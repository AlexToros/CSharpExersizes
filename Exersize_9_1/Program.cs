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
        public bool? IsError { get; private set; }

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
                if (IsError.Value)
                    return -1;
                return array[x];
            }
            set
            {
                var pow = Math.Log(value, 2);

                IsError = x < 0 || x > Length || Math.Log(value, 2) % 1 != 0;
                if (!IsError.Value)
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
            int limit = (int)Math.Log(long.MaxValue, 2);
            for (int i = 0; i < Length; i++)
            {
                array[i] = (long)Math.Pow(2, rndGen.Next(0, limit));
            }
        }

        public double AmmountOfDegrees()
        {
            var pows = array.Select(x => Math.Log(x, 2));
            return pows.Aggregate((x, y) => x * y) / pows.Sum();
        }

        public override string ToString()
        {
            string message = IsError.HasValue ? (IsError.Value ? "Последняя операция c ошибкой" : "Последняя операция без ошибок") : "Операций не производилось";
            return $"[{string.Join(", ", array)}]\n{message}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray rArray;
            while (true)
            {
                Console.Write("Создание экземпляра класса RandomArray\nВведите длину массива (от 10 до 100): ");
                int capacity = 0;
                if (int.TryParse(Console.ReadLine(), out capacity) && capacity >= 10 && capacity <= 100)
                {
                    rArray = new RandomArray(capacity);
                    break;
                }
                else
                    Console.WriteLine("Вводимое значение должно быть натуральным числом от 10 до 100\nПовторите ввод");
            }

            StepInfo(rArray, "Массив до инициации случайными значениями");
            
            rArray.RandomInit();

            StepInfo(rArray, "Массив после инициации случайными значениями");

            StepInfo(rArray.AmmountOfDegrees(), "Результат работы метода AmountOfDegrees");

            rArray[0] = 5;
            StepInfo(rArray, "Попытка присвоить невалидное значение - 5, первому элементу массива");

            rArray[0] = 8;
            StepInfo(rArray, "Попытка присвоить валидное значение - 8, первому элементу массива");


        }

        static void StepInfo(object obj, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(obj + "\n");
        }
    }
}
