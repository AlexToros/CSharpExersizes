using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_8_2
{
    class Grades
    {
        private List<int> gradeCollection;
        public double Average { get => gradeCollection.Average(); }
        public Grades()
        {
            gradeCollection = new List<int>();
        }
        public void AddRange(params int[] grades)
        {
            foreach (int grade in grades)
            {
                New(grade);
            }
        }
        public void New(int grade)
        {
            if (grade <= 0 || grade > 5)
                throw new ArgumentException("Значение оценки может быть только от единицы до пяти");
            gradeCollection.Add(grade);
        }
    }
    class Student : IComparable<Student>
    {
        private int _stage;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Stage
        {
            get => _stage;
            set
            {
                if (value <= 0 || value > 5)
                    throw new ArgumentException("Номер курса может быть только от единицы до пяти");
                _stage = value;
            }
        }
        public Grades Physics { get; set; }
        public Grades Math { get; set; }
        public Grades ITScience { get; set; }
        public double TotalAverageSum { get => Math.Average + Physics.Average + ITScience.Average; }
        public Student(string firstName, string lastName, int stage) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Stage = stage;
        }
        public Student()
        {
            Physics = new Grades();
            Math = new Grades();
            ITScience = new Grades();
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName}, группа: {Stage}, общий средний балл: {TotalAverageSum}";
        }

        public int CompareTo(Student other)
        {
            int res = Stage.CompareTo(other.Stage);
            if (res == 0)
                res = TotalAverageSum.CompareTo(other.TotalAverageSum);
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добавление студентов в массив");
            Student[] arrStudent = InputStudents(2).ToArray();

            Console.WriteLine("Добавление студентов в очередь");
            Queue<Student> queueStudend = new Queue<Student>(InputStudents(2));

            Console.WriteLine("Самый неуспевающий студент второй группы из массива:");
            Array.Sort(arrStudent);
            Console.WriteLine(arrStudent.Where(s => s.Stage == 2).First());


            Console.WriteLine("Самый неуспевающий студент второй группы из очереди:");
            Student std = null;
            while (queueStudend.Count > 0)
            {
                Student tmpStd = queueStudend.Dequeue();
                if (std == null) std = tmpStd;
                if (tmpStd.Stage != 2) continue;
                if (tmpStd.CompareTo(std) == -1)
                    std = tmpStd;
            }
            Console.WriteLine(std);
            Console.ReadLine();
        }
        static IEnumerable<Student> InputStudents(int count)
        {
            for (int i = 0; i < count;)
            {
                Student newStd = new Student();
                try
                {
                    Console.WriteLine("Новый студент");

                    Console.Write("\tФамилия: ");
                    newStd.LastName = Console.ReadLine();

                    Console.Write("\tИмя: ");
                    newStd.FirstName = Console.ReadLine();

                    Console.Write("\tНомер группы: ");
                    int stage;
                    if (int.TryParse(Console.ReadLine(), out stage))
                        newStd.Stage = stage;
                    else
                    {
                        throw new ArgumentException("Номер группы должен представять из себя целое число от одного до пяти");
                    }

                    Console.WriteLine("\tВвод оценок (через запятую)");
                    Console.Write("\t\tФизика: ");
                    newStd.Physics.AddRange(GradesParse(Console.ReadLine()));

                    Console.Write("\t\tМатематика: ");
                    newStd.Math.AddRange(GradesParse(Console.ReadLine()));

                    Console.Write("\t\tИнформатика: ");
                    newStd.ITScience.AddRange(GradesParse(Console.ReadLine()));
                    i++;
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    continue;
                }
                yield return newStd;
            }
        }
        static int[] GradesParse(string grades)
        {
            try
            {
                return grades.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                throw new ArgumentException("Каждая оценка должна быть числом");
            }
        }
    }
}
