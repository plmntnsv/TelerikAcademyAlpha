using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private readonly string name;
        private readonly string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;
        private IList<IFurniture> orderedCatalog;

        public Company(string name, string registrationNumber)
        {
            Guard.WhenArgument(name, "Company name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Company name length").IsLessThan(5).Throw();

            if (!Regex.IsMatch(registrationNumber, "[0-9]{10}"))
            {
                throw new ArgumentException("Registration number is not valid");
            }


            this.name = name;
            this.registrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
            this.orderedCatalog = new List<IFurniture>();
        }

        public string Name => this.name;

        public string RegistrationNumber => this.registrationNumber;

        public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
            Guard.WhenArgument(furniture, "Furniture to add").IsNull().Throw();
            this.Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            this.orderedCatalog = this.Furnitures.OrderBy(f => f.Price).ThenBy(x => x.Model).ToList();

            var strBuilder = new StringBuilder();

            strBuilder.Append($"{this.Name} - {this.registrationNumber} - ");

            if (furnitures.Count > 0)
            {
                strBuilder.Append($"{this.orderedCatalog.Count} ");

                if (orderedCatalog.Count == 1)
                {
                    strBuilder.AppendLine("furniture");
                }
                else
                {
                    strBuilder.AppendLine("furnitures");
                }

                foreach (var furniture in orderedCatalog)
                {
                    strBuilder.AppendLine(furniture.ToString());
                }
            }
            else
            {
                strBuilder.AppendLine("no furnitures");
            }

            return strBuilder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            Guard.WhenArgument(model, "Find model").IsNullOrEmpty().Throw();
            return this.furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public void Remove(IFurniture furniture)
        {
            Guard.WhenArgument(furniture, "Furniture to remove").IsNull().Throw();
            this.furnitures.Remove(furniture);
        }
    }
}
