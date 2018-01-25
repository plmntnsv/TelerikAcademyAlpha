using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int actions = input[0];
            int preferences = input[1];

            Dictionary<int, List<int>> allNodes = new Dictionary<int, List<int>>();

            for (int i = 0; i < actions; i++)
            {
                allNodes.Add(i, new List<int>());
            }

            for (int i = 0; i < preferences; i++)
            {
                int[] preference = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int a = preference[0];
                int b = preference[1];

                allNodes[b].Add(a);
            }

            var parentNodes = new SortedList<int, int>();
            Queue<int> sortedResult = new Queue<int>();

            while (allNodes.Count > 0)
            {
                parentNodes = new SortedList<int, int>();

                foreach (var node in allNodes)
                {
                    if (node.Value.Count == 0)
                    {
                        parentNodes.Add(node.Key, node.Key);
                    }
                }

                var smallest = parentNodes.First();
                sortedResult.Enqueue(smallest.Key);
                allNodes.Remove(smallest.Key);

                foreach (var node in allNodes)
                {
                    if (node.Value.Contains(smallest.Key))
                    {
                        node.Value.Remove(smallest.Key);
                    }
                }
            }

            for (int i = 0; i < actions; i++)
            {
                Console.WriteLine(sortedResult.Dequeue());
            }
        }
    }
}
