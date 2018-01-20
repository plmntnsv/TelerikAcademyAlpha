using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Program
    {
        private static BigList<Player> ranklist = new BigList<Player>();
        private static Dictionary<string, OrderedSet<Player>> sortedTypes = new Dictionary<string, OrderedSet<Player>>();
        private static StringBuilder resultBuilder = new StringBuilder();

        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');

                switch (input[0])
                {
                    case "add":
                        string name = input[1];
                        string type = input[2];
                        int age = int.Parse(input[3]);
                        int position = int.Parse(input[4]);

                        Add(name, type, age, position);

                        resultBuilder.AppendFormat($"Added player {name} to position {position}");
                        resultBuilder.AppendLine();
                        break;
                    case "find":
                        string findType = input[1];
                        resultBuilder.Append(Find(findType));
                        resultBuilder.AppendLine();
                        break;
                    case "ranklist":
                        int start = int.Parse(input[1]);
                        int end = int.Parse(input[2]);
                        resultBuilder.Append(GetRanklist(start, end));
                        resultBuilder.AppendLine();
                        break;
                    default:
                        Console.WriteLine(resultBuilder.ToString().Trim());
                        return;
                }
            }
        }

        static void Add(string name, string type, int age, int position)
        {
            var player = new Player(name, type, age);
            ranklist.Insert(position - 1, player);

            if (!sortedTypes.ContainsKey(type))
            {
                sortedTypes.Add(type, new OrderedSet<Player>());
            }

            if (sortedTypes[type].Count == 5)
            {
                Player lastPlayer = sortedTypes[type][4];
                if (lastPlayer.CompareTo(player) > 0)
                {
                    sortedTypes[type].Remove(lastPlayer);
                    sortedTypes[type].Add(player);
                }
            }
            else
            {
                sortedTypes[type].Add(player);
            }
        }

        static string Find(string type)
        {
            var sb = new StringBuilder();
            sb.Append($"Type {type}: ");

           
            if (sortedTypes.ContainsKey(type))
            {
                //for (int i = 0; i < sortedTypes[type].Count; i++)
                //{
                //    sb.Append($"{sortedTypes[type].ElementAt(i)} ");
                //}
                var players = sortedTypes[type];
                foreach (Player player in players)
                {
                    sb.AppendFormat(" {0}", player);
                }

                return sb.ToString().TrimEnd(new char[] { ' ', ';' });
            }
            else
            {
                return sb.ToString();
            }
        }

        static string GetRanklist(int start, int end)
        {
            var sb = new StringBuilder();

            //for (int i = start - 1, j = 1; i < end; i++, j++)
            //{
            //    sb.AppendFormat(string.Format("{0}. {1} ", i + 1, ranklist[i]));
            //}

            int count = end - start + 1;
            var rankedPlayers = ranklist.Range(start - 1, count);

            int playerPosition = start;
            foreach (Player player in rankedPlayers)
            {
                sb.AppendFormat("{0}. {1} ", playerPosition++, player);
            }

            return sb.ToString().TrimEnd(new char[] { ' ', ';' });
        }
    }

    class Player : IComparable<Player>
    {
        private string name;
        private string type;
        private int age;

        public Player(string name, string type, int age)
        {
            this.name = name;
            this.type = type;
            this.age = age;
        }

        public int CompareTo(Player other)
        {
            if (this.name.CompareTo(other.name) == 0)
            {
                return other.age.CompareTo(this.age);
            }

            return this.name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return string.Format("{0}({1});", this.name, this.age);
        }
    }
}
