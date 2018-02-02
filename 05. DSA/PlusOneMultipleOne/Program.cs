using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusOneMultipleOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            var queue = new Queue<int>();

            queue.Enqueue(n);

            int current = 0;

            for (int i = 0; i < m; i++)
            {
                current = queue.Dequeue();
                
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }

            Console.WriteLine(current);
        }
    }
}
