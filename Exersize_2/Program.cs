using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace Exersize_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo ce = new CultureInfo("en-us");
            ce.NumberFormat.CurrencyNegativePattern = 1; // минус вместо скобок у отрицательных валют
            Thread.CurrentThread.CurrentCulture = ce;

            Console.OutputEncoding = Encoding.Default;
            decimal StartMoney;
            do
            {
                Console.Write("Введите сумму вклада: ");
                StartMoney = decimal.Parse(Console.ReadLine());
            } while (!CheckInput(StartMoney));

            Console.WriteLine("Вы вложили сумму - {0}, на срок - 10 лет. План капитализации:", StartMoney);
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Через {0} год(а)(лет) сумма вашего вклада составит {1:C}", i, Math.Round(StartMoney += StartMoney * 0.08M, 3));
            }

            Console.WriteLine("Вложили полученный капитал в акции Сбербанка на год.\nКапитализация:");
            for (int i = 1; i <= 12; i++)
            {
                decimal percent = SberbankPercent(i);
                decimal delta = StartMoney * SberbankPercent(i);
                Console.WriteLine("Через {0} месяц(а)(ев) сумма ваших вложений составит {1:C} ({2:C} {3:P})", i, Math.Round(StartMoney = StartMoney + delta, 3),Math.Round(delta,3), percent);
            }

            Console.Write("Введите число месяцев для прогноза прибыли(от 13 до 48): ");
            int months = int.Parse(Console.ReadLine());

            for (int i = 13; i <= months; i++)
            {
                StartMoney += StartMoney * SberbankPercent(i);
            }

            Console.WriteLine("Ваш капитал соствит {0:C}", Math.Round(StartMoney,3));
            Console.ReadLine();
        }

        static bool CheckInput(decimal input)
        {
            if (input >= 5000) return true;
            else
            {
                Console.WriteLine("Минимальная сумма вклада - 5000!");
                return false;
            }
        }

        static decimal SberbankPercent(int month)
        {
            return (0.1M + 0.02M * month * month + 0.5M * (decimal)Math.Sin(2 * month) + (decimal)Math.Cos(3 * month))/100;
        }
    }
}
