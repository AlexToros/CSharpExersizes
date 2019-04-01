using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_12_1
{
    delegate void Binnary(double arg1, ref double arg2);
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите X: ");
            double X = double.Parse(Console.ReadLine());
            Console.Write("Введите A: ");
            double A = double.Parse(Console.ReadLine());
            double xCopy = X;
            double controlX = Math.Pow((A / Math.Pow(X, A) + A) * A - A, A);

            Binnary CalcY;
            Binnary Mul = delegate (double x, ref double y) { y *= x; };
            Binnary Div = delegate (double x, ref double y) { y = x / y; };
            Binnary Add = delegate (double x, ref double y) { y += x; };
            Binnary Sub = delegate (double x, ref double y) { y = y - x; };
            Binnary Pow = delegate (double x, ref double y) { y = Math.Pow(y, x); };

            CalcY = Pow;
            CalcY += Div;
            CalcY += Add;
            CalcY += Mul;
            CalcY += Sub;
            CalcY += Pow;

            CalcY.Invoke(A, ref xCopy);

            Console.WriteLine("Проверка с использованием анонимных методов: " + (xCopy == controlX));

            xCopy = X;

            Mul = (double x, ref double y) => y *= x; 
            Div = (double x, ref double y) => y = x / y;
            Add = (double x, ref double y) => y += x;
            Sub = (double x, ref double y) => y = y - x;
            Pow = (double x, ref double y) => y = Math.Pow(y, x); 

            CalcY = Pow;
            CalcY += Div;
            CalcY += Add;
            CalcY += Mul;
            CalcY += Sub;
            CalcY += Pow;

            CalcY.Invoke(A, ref xCopy);

            Console.WriteLine("Проверка с использованием блочных лямбда выражений: " + (xCopy == controlX));
        }
    }
}
