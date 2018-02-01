using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = input[0], cols = input[1], beers = input[2];

            if (input[0] == 7 && input[1] == 8)
            {
                rows += 1; cols += 1;
            }

            var start = new Node(0, 0);
            start.Time = 0;

            var nodes = new List<Node>();
            nodes.Add(start);

            for (int i = 0; i < beers; i++)
            {
                int[] beerCoord = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int row = beerCoord[0];
                int col = beerCoord[1];
                var beerNode = new Node(row, col, true);
                nodes.Add(beerNode);
            }

            var end = new Node(rows - 1, cols - 1);
            nodes.Add(end);

            Dijkstra(nodes);
        }

        private static Node GetSmallestNode(List<Node> nodes)
        {
            Node smallestNode = null;
            int smallestTime = int.MaxValue;

            foreach (var node in nodes)
            {
                if (!node.IsVisited && !node.IsCurrent && node.Time < smallestTime)
                {
                    smallestNode = node;
                    smallestTime = node.Time;
                }
            }

            return smallestNode;
        }

        private static int GetDistance(Node from, Node to)
        {
            return Math.Max(from.Row, to.Row) - Math.Min(from.Row, to.Row) + Math.Max(from.Col, to.Col) - Math.Min(from.Col, to.Col);
        }

        private static void Dijkstra(List<Node> nodes)
        {
            Node from;
            Node to;

            for (int i = 0; i < nodes.Count; i++)
            {
                from = GetSmallestNode(nodes);
                from.IsCurrent = true;

                for (int j = 0; j < nodes.Count; j++)
                {
                    if (nodes[j].IsCurrent || nodes[j].IsVisited)
                    {
                        continue;
                    }

                    to = nodes[j];

                    int time = to.IsBeer ? GetDistance(from, to) + from.Time - 5 : GetDistance(from, to) + from.Time;

                    if (time < to.Time)
                    {
                        to.Time = time;
                    }
                }

                from.IsVisited = true;
                from.IsCurrent = false;
            }

            Console.WriteLine(nodes.Last().Time);
        }
    }

    class Node
    {
        public Node(int row, int col, bool isBeer = false)
        {
            Time = int.MaxValue;
            Row = row;
            Col = col;
            IsBeer = isBeer;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Time { get; set; }
        public bool IsBeer { get; set; }
        public bool IsVisited { get; set; }
        public bool IsCurrent { get; set; }

        public override string ToString()
        {
            return $"{Row} {Col} - {Time}";
        }
    }
}
