using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Exersize_10_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new StreamReader("source.txt", Encoding.Default);
            var result = new StreamWriter("result.txt", false, Encoding.Default);

            using (result)
            using (source)
                while (!source.EndOfStream)
                {
                    string line = source.ReadLine();
                    int countSpec = line.Count(c => !Char.IsLetter(c) && !Char.IsNumber(c));
                    if (countSpec > 0)
                        result.WriteLine($"{line} - {countSpec}");
                }
        }
    }
}
