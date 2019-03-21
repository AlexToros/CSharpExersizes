using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_11_2
{
    delegate void Binnary(double arg1, ref double arg2);
    class Calc
    {
        public static void Addition(double arg1, ref double arg2) => arg2 += arg1;
        public static void Substraction(double arg1, ref double arg2) => arg2 = arg2 - arg1;
        public static void Multiplication(double arg1, ref double arg2) => arg2 *= arg1;
        public static void Division(double arg1, ref double arg2) => arg2 = arg1 / arg2;
        public static void Pow(double arg1, ref double arg2) => arg2 = Math.Pow(arg2, arg1);

        public void InstanceAddition(double arg1, ref double arg2) => arg2 += arg1;
        public void InstanceSubstraction(double arg1, ref double arg2) => arg2 = arg2 - arg1;
        public void InstanceMultiplication(double arg1, ref double arg2) => arg2 *= arg1;
        public void InstanceDivision(double arg1, ref double arg2) => arg2 = arg1 / arg2;
        public void InstancePow(double arg1, ref double arg2) => arg2 = Math.Pow(arg2, arg1);

    }
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
            Binnary Mul = Calc.Multiplication;
            Binnary Div = Calc.Division;
            Binnary Add = Calc.Addition;
            Binnary Sub = Calc.Substraction;
            Binnary Pow = Calc.Pow;

            CalcY = Pow;
            CalcY += Div;
            CalcY += Add;
            CalcY += Mul;
            CalcY += Sub;
            CalcY += Pow;
            
            CalcY.Invoke(A, ref xCopy);

            Console.WriteLine("Проверка со статическими методами пройдена: " + (xCopy == controlX));

            xCopy = X;
            Calc calc = new Calc();

            CalcY = calc.InstancePow;
            CalcY += calc.InstanceDivision;
            CalcY += calc.InstanceAddition;
            CalcY += calc.InstanceMultiplication;
            CalcY += calc.InstanceSubstraction;
            CalcY += calc.InstancePow;

            CalcY.Invoke(A, ref xCopy);

            Console.WriteLine("Проверка с экземплярными методами пройдена: " + (xCopy == controlX));
        }
    }
}
