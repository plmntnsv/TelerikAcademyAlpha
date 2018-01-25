using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace UnitsOfWork
{
    class Program
    {
        private static Dictionary<string, SortedSet<Unit>> unitsByType = new Dictionary<string, SortedSet<Unit>>();
        private static Dictionary<string, Unit> unitsByName = new Dictionary<string, Unit>();
        private static OrderedSet<Unit> unitsByPower = new OrderedSet<Unit>();
        private static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputParams = input.Split(' ');
                switch (inputParams[0])
                {
                    case "add":
                        AddUnit(inputParams[1], inputParams[2], int.Parse(inputParams[3]));
                        break;
                    case "remove":
                        RemoveUnit(inputParams[1]);
                        break;
                    case "find":
                        FindUnit(inputParams[1]);
                        break;
                    case "power":
                        GetPowerUnits(int.Parse(inputParams[1]));
                        break;
                }
            }

            Console.WriteLine(result);
        }

        static void AddUnit(string name, string type, int attack)
        {
            if (unitsByName.ContainsKey(name))
            {
                result.AppendLine(string.Format("FAIL: {0} already exists!", name));
                return;
            }

            var unit = new Unit(name, type, attack);

            if (!unitsByType.ContainsKey(type))
            {
                unitsByType.Add(type, new SortedSet<Unit>());
            }

            unitsByName.Add(name, unit);
            unitsByType[type].Add(unit);
            unitsByPower.Add(unit);

            result.AppendLine(string.Format("SUCCESS: {0} added!", name));
        }

        static void RemoveUnit(string name)
        {
            if (!unitsByName.ContainsKey(name))
            {
                result.AppendFormat("FAIL: {0} could not be found!", name);
                result.AppendLine();
                return;
            }

            var unit = unitsByName[name];

            unitsByName.Remove(name);
            unitsByType[unit.Type].Remove(unit);
            unitsByPower.Remove(unit);
            result.AppendFormat("SUCCESS: {0} removed!", name);
            result.AppendLine();
        }

        static void FindUnit(string type)
        {
            result.Append("RESULT: ");
            if (!unitsByType.ContainsKey(type) || !unitsByType[type].Any())
            {
                result.AppendLine();
                return;
            }

            var units = unitsByType[type].Take(10);

            foreach (var unit in units)
            {
                result.AppendFormat("{0}, ", unit);
            }

            result.Remove(result.Length - 2, 2);
            result.AppendLine();
        }

        static void GetPowerUnits(int count)
        {
            IEnumerable<Unit> range = unitsByPower.Take(count);
            result.Append("RESULT: ");

            foreach (var unit in range)
            {
                result.AppendFormat("{0}, ", unit);
            }

            if (unitsByPower.Any())
            {
                result.Remove(result.Length - 2, 2);
            }

            result.AppendLine();
        }
    }

    class Unit : IComparable<Unit>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Attack { get; set; }

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public override string ToString()
        {
            return $"{this.Name}[{this.Type}]({this.Attack})";
        }

        public int CompareTo(Unit other)
        {
            int compare = other.Attack.CompareTo(this.Attack);

            if (compare == 0)
            {
                compare = this.Name.CompareTo(other.Name);
            }

            return compare;
        }
    }
}
