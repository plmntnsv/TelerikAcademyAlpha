using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] jedis = Console.ReadLine().Split(' ');

            var p = new List<string>();
            var k = new List<string>();
            var m = new List<string>();

            for (int i = 0; i < n; i++)
            {
                if (jedis[i][0] == 'P')
                {
                    p.Add(jedis[i]);
                }
                else if (jedis[i][0] == 'M')
                {
                    m.Add(jedis[i]);
                }
                else if (jedis[i][0] == 'K')
                {
                    k.Add(jedis[i]);
                }
            }

            m.AddRange(k);
            m.AddRange(p);

            Console.WriteLine(string.Join(" ", m));
        }
    }
}
