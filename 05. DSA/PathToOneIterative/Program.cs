using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathToOneIterative
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<Num>();

            queue.Enqueue(new Num(n, 0));

            while (true)
            {
                var current = queue.Dequeue();

                if (current.number == 1)
                {
                    Console.WriteLine(current.count);
                    break;
                }

                if (current.number % 2 == 0)
                {
                    queue.Enqueue(new Num((current.number / 2), (current.count + 1)));
                }
                else
                {
                    queue.Enqueue(new Num((current.number - 1), (current.count + 1)));
                    queue.Enqueue(new Num((current.number + 1), (current.count + 1)));
                }
            }
        }
    }

    struct Num
    {
        public int number;
        public int count;

        public Num(int num, int count)
        {
            this.number = num;
            this.count = count;
        }
    }
}
