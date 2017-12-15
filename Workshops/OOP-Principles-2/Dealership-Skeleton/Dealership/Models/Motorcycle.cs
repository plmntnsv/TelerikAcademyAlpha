using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private readonly string category;
        private const int wheels = 2;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category cannot be null!");
            }

            if (category.Length < 3 || category.Length > 10)
            {
                throw new ArgumentException("Category must be between 3 and 10 characters long!");
            }

            this.category = category;
            this.Wheels = wheels;
        }

        public string Category => this.category;

        public override VehicleType Type => VehicleType.Motorcycle;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"{Type}:"));

            sb.AppendLine(base.ToString());

            sb.AppendLine(string.Format($"  Category: {Category}"));

            return sb.ToString().TrimEnd();
        }
    }
}
