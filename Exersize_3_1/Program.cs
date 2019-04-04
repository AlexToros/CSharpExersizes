using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_3_1
{
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distanse(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    struct Line
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public double Length { get => A.Distanse(B); }

        public Line(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public bool IsOnLine(Point point)
        {
            if (point.X > Math.Max(A.X, B.X) || point.X < Math.Min(A.X, B.X) ||
                point.Y > Math.Max(A.Y, B.Y) || point.Y < Math.Min(A.Y, B.Y))
                return false;

            if (A.X == B.X || A.Y == B.Y)
                return true;

            return Math.Abs((point.X - A.X) / (A.X - B.X) - (point.Y - A.Y) / (A.Y - B.Y)) < double.Epsilon * 1000;
        }

        public override string ToString()
        {
            return string.Format("Длина: {0}", A.Distanse(B));
        }
    }
    struct Rectangle
    {
        private Line[] sides;

        public double SquareSize { get => sides[0].Length * sides[1].Length; }
        public double Perimeter { get => (sides[0].Length + sides[1].Length) * 2; }

        public Rectangle(Point leftUpPoint, double xLength, double yLength)
        {
            sides = new Line[4];
            sides[0] = new Line(leftUpPoint, new Point(leftUpPoint.X + xLength, leftUpPoint.Y));
            sides[1] = new Line(new Point(leftUpPoint.X + xLength, leftUpPoint.Y), new Point(leftUpPoint.X + xLength, leftUpPoint.Y + yLength));
            sides[2] = new Line(new Point(leftUpPoint.X + xLength, leftUpPoint.Y + yLength), new Point(leftUpPoint.X, leftUpPoint.Y + yLength));
            sides[3] = new Line(new Point(leftUpPoint.X, leftUpPoint.Y + yLength), leftUpPoint);
        }

        public bool IsOnSquare(Point point)
        {
            return sides.Any(l => l.IsOnLine(point));
        }

        public override string ToString()
        {
            return string.Format("Площадь: {0}, периметр: {1}", SquareSize, Perimeter);
        }
    }
    struct Square
    {
        private Line[] sides;

        public double SquareSize { get => Math.Pow(sides[0].Length, 2); }
        public double Perimeter { get => sides[0].Length * 4; }

        public Square(Point leftUpPoint, double sideLength)
        {
            sides = new Line[4];
            sides[0] = new Line(leftUpPoint, new Point(leftUpPoint.X + sideLength, leftUpPoint.Y));
            sides[1] = new Line(new Point(leftUpPoint.X + sideLength, leftUpPoint.Y), new Point(leftUpPoint.X + sideLength, leftUpPoint.Y + sideLength));
            sides[2] = new Line(new Point(leftUpPoint.X + sideLength, leftUpPoint.Y + sideLength), new Point(leftUpPoint.X, leftUpPoint.Y + sideLength));
            sides[3] = new Line(new Point(leftUpPoint.X, leftUpPoint.Y + sideLength), leftUpPoint);
        }

        public bool IsOnSquare(Point point)
        {
            return sides.Any(l => l.IsOnLine(point));
        }

        public override string ToString()
        {
            return string.Format("Площадь: {0}, периметр: {1}", SquareSize, Perimeter);
        }
    }
    struct Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool IsOnCircle(Point point)
        {
            return Math.Abs(Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2) - Math.Pow(Radius, 2)) < double.Epsilon * 1000;
        }
    }

    struct Romb
    {
        private Line[] sides;

        public double SquareSize { get => sides[0].A.Distanse(sides[3].A) * sides[0].B.Distanse(sides[3].B) / 2; }
        public double Perimeter { get => (sides[0].Length + sides[1].Length) * 2; }

        public Romb(Point leftUpPoint, double xLength, double yLength)
        {
            sides = new Line[4];
            sides[0] = new Line(new Point(leftUpPoint.X + xLength / 2, leftUpPoint.Y), new Point(leftUpPoint.X + xLength, leftUpPoint.Y + yLength / 2));
            sides[1] = new Line(new Point(leftUpPoint.X + xLength, leftUpPoint.Y + yLength / 2), new Point(leftUpPoint.X + xLength / 2, leftUpPoint.Y + yLength));
            sides[2] = new Line(new Point(leftUpPoint.X + xLength / 2, leftUpPoint.Y + yLength), new Point(leftUpPoint.X, leftUpPoint.Y + yLength / 2));
            sides[3] = new Line(new Point(leftUpPoint.X, leftUpPoint.Y + yLength / 2), new Point(leftUpPoint.X + xLength / 2, leftUpPoint.Y));
        }

        public bool IsOnSquare(Point point)
        {
            return sides.Any(l => l.IsOnLine(point));
        }

        public override string ToString()
        {
            return string.Format("Площадь: {0}, периметр: {1}", SquareSize, Perimeter);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = {
                new Point(20,30),
                new Point(20,40),
                new Point(30,30),
                new Point(30,40)
            };
            Point checkPoint = new Point(22, 30);
            Line line = new Line(points[0], points[2]);
            Square square = new Square(points[0], 20);
            Console.WriteLine("Создана линия");
            Console.WriteLine(line);
            Console.WriteLine($"Создан квадрат по координатам {string.Join(", ",points)}");
            Console.WriteLine(square);
            Console.WriteLine($"Проверка, лежит ли точка {checkPoint} на созданном квадрате");
            Console.WriteLine(square.IsOnSquare(checkPoint));
            Console.ReadLine();
        }
    }
}
