using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_12_2
{
    delegate bool BoleanF(double x);
    delegate double Unary(double x);
    class Program
    {
        static void Main(string[] args)
        {
            BoleanF PowOfTwo = x => {
                double temp = Math.Log(x, 2);
                return Math.Abs(temp - (int)temp) < double.Epsilon;
            };
            Unary Fact = x =>
            {
                double t = 1;
                for (int i = 2; i <= x; i++)
                    t *= i;
                return t;
            };
            Unary Reciprocal = x => 1 / x;
            Unary FracPart = x => x - Math.Round(x);
            BoleanF IsEven = x => x % 2 == 0;
            BoleanF isOdd = x => !IsEven(x);
            Unary Crt = x => Math.Pow(x, 1.0 / 3);
            Unary DegToRad = x => x * Math.PI / 180;
            Unary RadToDeg = x => x * 180 / Math.PI;
        }
    }
}
