using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exersize_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину катета: ");
            double katet = double.Parse(Console.ReadLine());
            Console.Write("Введите значение радиуса: ");
            double radius = double.Parse(Console.ReadLine());

            var triangleInfo = GetTriangle(katet, radius);
            TriangleOutput(triangleInfo.ToTuple());


            Console.WriteLine("Подставив полученное значение катета в изначальную задачу, получим: ");

            triangleInfo = GetTriangle(triangleInfo.unknownKatet, radius);
            TriangleOutput(triangleInfo.ToTuple());

            Console.WriteLine("При равнобедренном треугольнике (катет = 2 + корень из 2 и радиус = 1), получим: ");

            TriangleOutput(GetTriangle(2 + Math.Sqrt(2), 1).ToTuple());
            Console.ReadLine();
        }

        static (double square, double unknownKatet, double firstAngle, double secondAngle) GetTriangle(double katet, double insertRadius)
        {
            if (katet <= insertRadius * 2) throw new ArgumentException("Невозможный треугольник");

            double sharpAngleNearKnownKatet = 2*Math.Atan(insertRadius / (katet - insertRadius));
            double anotherSharpAngle = Math.PI/2 - sharpAngleNearKnownKatet;
            double square = (Math.Pow(katet, 2) / 2) * (Math.Sin(Math.PI / 2) * Math.Sin(sharpAngleNearKnownKatet) / Math.Sin(anotherSharpAngle));
            double unknownKatet = square / katet * 2;
            return (Math.Round(square,10), Math.Round(unknownKatet, 10), Math.Round(sharpAngleNearKnownKatet, 10), Math.Round(anotherSharpAngle, 10));
        }

        static double FromRadianToDegree(double radian) => radian * 180 / Math.PI;

        static void TriangleOutput(Tuple<double, double, double, double> triangleInfo)
        {
            Console.WriteLine("Площадь: {0:0.###}, неизвестный катет: {1:0.###}, углы при катетах: {2:0.###} градусов и {3:0.###} градусов",
                triangleInfo.Item1,
                triangleInfo.Item2,
                FromRadianToDegree(triangleInfo.Item3),
                FromRadianToDegree(triangleInfo.Item4));
        }
    }
}
