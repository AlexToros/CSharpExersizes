using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exersize_10_1-2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersFromFile = new List<int>();
            int oddNumberCount = 0, evenNumberCount = 0;
            Random rnd = new Random();
            string source = "1.txt";
            string result = "2.txt";

            var log = new StreamWriter("system.log");
            Console.SetOut(log);

            Console.Write("Введите количество чисел в создаваемом файле: ");
            int quantity = int.Parse(Console.ReadLine());

            using (FileStream fs = new FileStream(source, FileMode.Create))
                for (int i = 0; i < quantity; i++)
                {
                    string line = rnd.Next(10, 100).ToString() + "\r\n";
                    byte[] buffer = Encoding.Default.GetBytes(line);
                    fs.Write(buffer, 0, buffer.Length);
                }
                        
            using (StreamReader sr = new StreamReader(source,Encoding.Default))
                for (int i = 0; i < quantity; i++)
                {
                    int number = int.Parse(sr.ReadLine());
                    numbersFromFile.Add(number);
                    if (number % 2 == 0)
                        evenNumberCount++;
                    else
                        oddNumberCount++;
                }

            Console.WriteLine($"Количество четых чисел:   {evenNumberCount}");
            Console.WriteLine($"Количество нечетых чисел: {evenNumberCount}");
            if (evenNumberCount > oddNumberCount)
            {
                Console.Write("Четных чисел больше.\nСреднее арифметическое: ");
                Console.WriteLine(numbersFromFile.Average());
            }
            else
            {
                Console.Write("Четных чисел больше.\nСреднее геометрическое: ");
                Console.WriteLine(Math.Pow(numbersFromFile.Aggregate((x, y) => x * y), 1.0 / numbersFromFile.Count));
            }

            Console.WriteLine("Ниже содержимое сгенерированного файла:");
            numbersFromFile.ForEach(n => Console.WriteLine(n));


            int maxIndx = numbersFromFile.FindIndex(x => x == numbersFromFile.Max());
            int minIndx = numbersFromFile.FindIndex(x => x == numbersFromFile.Min());

            using (StreamWriter sw = new StreamWriter(result,false , Encoding.Default))
                for (int i = Math.Min(maxIndx, minIndx) + 1, lim = Math.Max(maxIndx, minIndx); i < lim; i++)
                    sw.WriteLine(numbersFromFile[i]);

            Console.WriteLine($"В файл 2.txt записаны все числа, находящиеся между минимальным ({numbersFromFile[minIndx]}) и максимальным ({numbersFromFile[maxIndx]}) числом в файле 1.txt");
            

            var fromStream = new StreamReader("1.txt");
            var toStream = new StreamWriter("3.txt");
            Console.SetIn(fromStream);
            Console.SetOut(toStream);
            
            for (int i = 0; i < quantity; i++)
                Console.WriteLine(Console.ReadLine());


            log.Close();
            fromStream.Close();
            toStream.Close();
        }
    }
}
