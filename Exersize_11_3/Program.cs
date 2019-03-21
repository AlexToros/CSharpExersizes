using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_11_3
{
    delegate double Binnary(double arg1,  double arg2);
    delegate double Unnary(double arg1);
    class Calc
    {
        public static double Addition(double arg1, double arg2) => arg1 + arg2;
        public static double Substraction(double arg1, double arg2) => arg1 - arg2;
        public static double Multiplication(double arg1, double arg2) => arg2 * arg1;
        public static double Division(double arg1, double arg2) => arg2 = arg1 / arg2;
        public static double Pow(double arg1, double arg2) => arg2 = Math.Pow(arg1, arg2);
        public static double Negative(double arg1) => -arg1;


    }
    class Program
    {
        static void Main(string[] args)
        {
            Binnary Mul = Calc.Multiplication;
            Binnary Div = Calc.Division;
            Binnary Add = Calc.Addition;
            Binnary Sub = Calc.Substraction;
            Binnary Pow = Calc.Pow;
            Unnary Neg = Calc.Negative;

            double X = -3, A = -3;
            double Y = 0;
            for (int i = 0; i < 7; i++)
            {
                double tA = Pow(A, i);
                double tX = Pow(X, 6 - i);
                if (tA == 1)
                    Y = Sub(Y, tX);
                else if (tX == 1)
                    Y = Sub(Y, tA);
                else
                {
                    int Sign = i % 2 == 0 ? -1 : 1;
                    double temp = Div(tA, tX);
                    temp = Mul(Sign, temp);
                    Y = Add(Y, temp);
                }
            }
            double controlY = -Math.Pow(X, 6) + A / Math.Pow(X, 5) - Math.Pow(A, 2) / Math.Pow(X, 4) + Math.Pow(A, 3) / Math.Pow(X, 3) - Math.Pow(A, 4) / Math.Pow(X, 2) + Math.Pow(A, 5) / X - Math.Pow(A, 6);
        }
    }
}
