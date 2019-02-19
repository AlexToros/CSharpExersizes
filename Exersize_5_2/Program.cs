using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exersize_5_2
{
    class Invest
    {
        private static string bankName;
        private static double percent;
        private static TimeSpan duration;

        private DateTime openDate;
        private string holderFIO;
        private decimal totalSum;

        static Invest()
        {
            bankName = "ВТБ";
            percent = 0.06;
            duration = new TimeSpan(3 * 365, 0, 0, 0);
        }

        public Invest(string FIO, DateTime Open, decimal Sum)
        {
            holderFIO = FIO;
            openDate = Open;
            totalSum = Sum;
        }

        public override string ToString()
        {
            return string.Format("Вклад в банке {0}, на сумму {1:C}, под {2:P} годовых, на срок {3} дней.\nДержатель вклада: {4}, дата открытия {5:dd.MM.yyyy}",
                bankName,
                totalSum,
                percent,
                duration.TotalDays,
                holderFIO,
                openDate);
        }

        public decimal SumAfter(int Days)
        {
            return Math.Round(totalSum * (decimal)Math.Pow(1 + percent, Days/365.0),2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Console.OutputEncoding = Encoding.Default;
            Invest invest = new Invest("Пьянков Александр Сергеевич", DateTime.Now, 100000);
            Console.WriteLine(invest);

            Console.WriteLine("Сумма вклада после 365 дней: " + invest.SumAfter(180));
            Console.ReadLine();
        }
    }
}
