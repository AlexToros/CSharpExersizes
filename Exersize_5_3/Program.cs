using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_5_3
{
    static class MyMath
    {
        public static long Fact(int number)
        {
            if (number > 20) throw new SystemException("Невозможно вычислить результат. Слишком большое число");
            if (number < 0) throw new ArgumentException("Область определения факториала - целые неотрицательные числа!");
            if (number <= 1) return 1;
            long res = 2;
            for (int i = 3; i <= number; i++)
                res *= i;
            return res;
        }

        public static double Reciprocal(double number) => 1 / number;

        public static double FracPart(double number)
        {
            return number - (int)number;
        }

        public static bool IsEven(int number) => number % 2 == 0;
        public static bool IsOdd(int number) => !IsEven(number);

        public static double Crt(double number)
        {
            return Math.Pow(number, 1.0 / 3);
        }

        public static double DegToRad(double degree)
        {
            return degree * Math.PI / 180;
        }
        public static double RegToDeg(double radian)
        {
            return radian * 180 / Math.PI;
        }
        public static bool BinnaryDigit(int number)
        {
            double pow = Math.Log(number, 2);
            return pow == Math.Ceiling(pow);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
