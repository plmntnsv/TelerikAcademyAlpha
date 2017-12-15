using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private readonly string make;
        private readonly string model;
        private readonly decimal price;
        private int wheels;
        private IList<IComment> comments;

        public Vehicle(string make, string model, decimal price)
        {
            this.make = make ?? throw new ArgumentNullException("Make cannot be null!");
            this.model = model ?? throw new ArgumentNullException("Make cannot be null!");

            if (make.Length < 2 || make.Length > 15)
            {
                throw new ArgumentException("Make length must be between 2 and 15 characters long");
            }

            if (model.Length < 1 || model.Length > 15)
            {
                throw new ArgumentException("Model length must be between 2 and 15 characters long");
            }

            if (price < 0 || price > 100000)
            {
                throw new ArgumentException("Price must be between 0.0 and 100000.0!");
            }

            this.price = price;
            comments = new List<IComment>();
        }

        public abstract VehicleType Type { get; }

        public string Make => this.make;

        public string Model => this.model;

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            set
            {
                this.wheels = value;
            }
        }

        public IList<IComment> Comments => this.comments;

        public decimal Price => this.price;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"  Make: {Make}"));
            sb.AppendLine(string.Format($"  Model: {Model}"));
            sb.AppendLine(string.Format($"  Wheels: {Wheels}"));
            sb.AppendLine(string.Format($"  Price: ${Price}"));

            return sb.ToString().TrimEnd();
        }
    }
}
