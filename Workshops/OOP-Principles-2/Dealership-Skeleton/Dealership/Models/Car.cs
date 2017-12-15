using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Text;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private readonly int seats;
        private const int wheels = 4;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            if (seats < 1 || seats > 10)
            {
                throw new ArgumentException("Seats must be between 1 and 10!");
            }

            this.seats = seats;
            this.Wheels = wheels;
        }

        public int Seats => this.seats;

        public override VehicleType Type => VehicleType.Car;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"{Type}:"));

            sb.AppendLine(base.ToString());

            sb.AppendLine(string.Format($"  Seats: {Seats}"));

            return sb.ToString().TrimEnd();
        }
    }
}
