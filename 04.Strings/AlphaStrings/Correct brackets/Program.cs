using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correct_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool correct = true;
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push('(');
                }
                else if (input[i] == ')')
                {
                    if (stack.Count == 0)
                    {
                        correct = false;
                        break;
                    }

                    stack.Pop();
                }
            }

            if (correct && stack.Count == 0)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }
}
