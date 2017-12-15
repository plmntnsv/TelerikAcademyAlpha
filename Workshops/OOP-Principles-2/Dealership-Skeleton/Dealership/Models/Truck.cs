using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private readonly int weightCapacity;
        private const int wheels = 8;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base (make, model, price)
        {
            if (100 < weightCapacity || weightCapacity < 1)
            {
                throw new ArgumentException("Weight capacity must be between 1 and 100!");
            }

            this.weightCapacity = weightCapacity;
            this.Wheels = wheels;
        }

        public int WeightCapacity => this.weightCapacity;

        public override VehicleType Type => VehicleType.Truck;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"{Type}:"));

            sb.AppendLine(base.ToString());

            sb.AppendLine(string.Format($"  Weight capacity: {WeightCapacity}t"));

            return sb.ToString().TrimEnd();
        }
    }
}
