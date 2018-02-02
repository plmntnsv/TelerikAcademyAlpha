using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        private static List<List<int>> permutations = new List<List<int>>();
        private static int n;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }

            var nums = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                nums.Add(i);
            }

            foreach (var num in nums)
            {
                var current = new List<int>();
                current.Add(num);

                var rest = new List<int>(nums);
                rest.Remove(num);

                Permutate(current, rest);
            }

            foreach (var list in permutations)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        static void Permutate(List<int> current, List<int> rest)
        {
            if (current.Count == n)
            {
                return;
            }

            if (rest.Count == 1)
            {
                current.Add(rest[0]);
                permutations.Add(current);
                return;
            }

            foreach (var num in rest)
            {
                var newCurrent = new List<int>(current);
                newCurrent.Add(num);

                var newRest = new List<int>(rest);
                newRest.Remove(num);

                Permutate(newCurrent, newRest);
            }
        }
    }
}
