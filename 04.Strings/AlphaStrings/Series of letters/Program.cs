using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_of_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i-1])
                {
                    sb.Append(input[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
