using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = { 0.001, 0.1, -1, 1, 4 };
            
            ResultTable(Function, input, "Результаты вычисления неоптимизированной функции");
            ResultTable(OptimizedFunction, input, "Результаты вычисления оптимизированной функции функции");

            Console.ReadLine();
        }

        static double Function(double X)
        {
            double Y = (1 - Math.Sqrt(Math.Abs(Math.Log(X, 2))) + 25 * Math.Pow(10, -5) * Math.Log10(X)) / 
                (Math.Log(X, 2) + 0.00025 * Math.Log10(X));

            if (double.IsNaN(Y) || double.IsInfinity(Y)) throw new ArgumentException("Вне области определения");
            return Y;
        }

        static double OptimizedFunction(double X)
        {
            double Log2X = Math.Log(X, 2);
            double Log10X = Math.Log10(X);
            double Y = 1 + (1 - Math.Sqrt(Math.Abs(Log2X)) - Log2X) / (Log2X + 0.00025 * Log10X);

            if (double.IsNaN(Y) || double.IsInfinity(Y)) throw new ArgumentException("Вне области определения");
            return Y;
        }

        static void FormatTableRow(object left, object right)
        {
            string formatStr = "{0,-15}{1,-15}";
            Console.WriteLine(formatStr, left, right);
        }

        static void ResultTable(Func<double, double> func, double[] inputArgs, string HeaderText)
        {
            double Y;
            TimeSpan CalculationTime = new TimeSpan();
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine(HeaderText);
            FormatTableRow("X", "Y");
            foreach (double inputValue in inputArgs)
            {
                try
                {
                    stopwatch.Restart();
                    Y = func(inputValue);
                    stopwatch.Stop();
                    CalculationTime.Add(stopwatch.Elapsed);
                    FormatTableRow(inputValue, Y);
                }
                catch (ArgumentException ex)
                {
                    FormatTableRow(inputValue, ex.Message);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Затрачено всего времени: {0}, в среднем на одно вычисление: {1}",
                stopwatch.Elapsed, 
                new TimeSpan(stopwatch.Elapsed.Ticks/inputArgs.Length));
        }
    }
}
