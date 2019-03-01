using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersize_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string valid = "()(()())";
            string invalid1 = "(((";
            string invalid2 = "())()";

            Console.WriteLine(IsBracesValid(valid));
            Console.WriteLine(IsBracesValid(invalid1));
            Console.WriteLine(IsBracesValid(invalid2));
            Console.ReadLine();
        }

        static bool IsBracesValid(string bracesString)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char brace in bracesString)
            {
                if (brace != '(' && brace != ')')
                    continue;
                if (brace == '(')
                    stack.Push(brace);
                if (brace == ')')
                {
                    if (stack.Count == 0)
                        return false;
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
    }
}
