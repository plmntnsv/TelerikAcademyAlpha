using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokiSkoki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            int[] b = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] d = new int[b.Length];
            Stack<int> s = new Stack<int>();

            for (int i = b.Length - 1; i >= 0; i--)
            {
                int currentB = b[i];

                while (s.Count > 0 && currentB >= b[s.Peek()])
                {
                    s.Pop();
                }

                if (s.Count > 0)
                {
                    d[i] = d[s.Peek()] + 1;
                }

                s.Push(i);
            }

            Console.WriteLine(d.Max());
            Console.WriteLine(string.Join(" ", d));
        }
    }
}
