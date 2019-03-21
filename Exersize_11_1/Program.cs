using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_11_1
{
    class Program
    {
        delegate double Unary(double arg);
        delegate double Binary(double arg1, double arg2);
        static void Main(string[] args)
        {
            Unary DelAbs = x => Math.Abs(x);
            Unary DelSqrt = x => Math.Sqrt(x);
            Binary DelLogN = (x, y) => Math.Log(x, y);
            Binary DelPow = (x, y) => Math.Pow(x, y);

            double X = 16;
            double Y = (1d - DelSqrt(DelAbs(DelLogN(X, 2))) + 25 * DelPow(10, -5) * DelLogN(DelPow(X, 2), 10)) / (DelLogN(X, 2) + 0.00025 * DelLogN(X, 2));
            double controlY = (1d - Math.Sqrt(Math.Abs(Math.Log(X, 2))) + 25 * Math.Pow(10, -5) * Math.Log(Math.Pow(X, 2), 10)) / (Math.Log(X, 2) + 0.00025 * Math.Log(X, 2));

            Console.WriteLine(Y == controlY);
        }
    }
}
