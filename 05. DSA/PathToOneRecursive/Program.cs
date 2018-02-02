using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathToOneRecursive
{
    class Program
    {
        private static int bestCount = int.MaxValue;
        private static int startNum;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            startNum = n;

            CalculatePathToOne(n, 0, true, true);

            Console.WriteLine(bestCount);
        }

        private static void CalculatePathToOne(int n, int count, bool add, bool subtract)
        {
            if (count > bestCount)
            {
                return;
            }

            if (n < 1)
            {
                return;
            }

            if (n > startNum + 1)
            {
                return;
            }

            if (n == 1)
            {
                if (bestCount > count)
                {
                    bestCount = count;
                }

                return;
            }

            if (n % 2 == 0)
            {
                CalculatePathToOne(n / 2, count + 1, true, true);
            }
            else
            {
                if (add)
                {
                    CalculatePathToOne(n + 1, count + 1, true, false);
                }

                if (subtract)
                {
                    CalculatePathToOne(n - 1, count + 1, false, true);
                }
            }
        }
    }
}