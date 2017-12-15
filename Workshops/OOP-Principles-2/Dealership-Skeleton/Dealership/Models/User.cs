using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class User : IUser
    {
        private readonly string username;
        private readonly string firstName;
        private readonly string lastName;
        private readonly string password;
        private readonly Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("username", nameof(username));
            }

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("firstName", nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("lastName", nameof(lastName));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("password", nameof(password));
            }

            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentException("role", nameof(role));
            }

            if (username.Length < 2 || username.Length > 20)
            {
                throw new ArgumentException("Username must be between 2 and 20 characters long!");
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                throw new ArgumentException("Username contains invalid symbols!");
            }

            if (password.Length < 5 || password.Length > 30)
            {
                throw new ArgumentException("Password must be between 5 and 30 characters long!");
            }

            if (firstName.Length < 2 || firstName.Length > 20)
            {
                throw new ArgumentException("Firstname must be between 2 and 20 characters long!");

            }

            if (lastName.Length < 2 || lastName.Length > 20)
            {
                throw new ArgumentException("Lastname must be between 2 and 20 characters long!");

            }

            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.role = (Role)Enum.Parse(typeof(Role), role);
            this.vehicles = new List<IVehicle>();
        }

        public string Username => this.username;

        public string FirstName => this.firstName;

        public string LastName => this.lastName;

        public string Password => this.password;

        public Role Role => this.role;

        public IList<IVehicle> Vehicles => this.vehicles;

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            if (commentToAdd == null)
            {
                throw new ArgumentNullException(nameof(commentToAdd));
            }

            if (vehicleToAddComment == null)
            {
                throw new ArgumentNullException(nameof(vehicleToAddComment));
            }

            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            if (this.Role != Role.VIP && this.Vehicles.Count == 5)
            {
                throw new ArgumentException("You are not VIP and cannot add more than 5 vehicles!");
            }

            if (this.Role == Role.Admin)
            {
                throw new ArgumentException("You are an admin and therefore cannot add vehicles!");
            }

            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"--USER {Username}--"));

            if (this.Vehicles.Count < 1)
            {
                sb.AppendLine("--NO VEHICLES--");
            }
            else
            {
                int positionOfVehicle = 1;

                foreach (var vehicle in this.Vehicles)
                {
                    sb.Append(string.Format($"{positionOfVehicle}. "));
                    sb.AppendLine(vehicle.ToString());

                    if (vehicle.Comments.Count > 0)
                    {
                        sb.AppendLine("    --COMMENTS--");

                        foreach (var comment in vehicle.Comments)
                        {
                            sb.AppendLine(comment.ToString());
                        }

                        sb.AppendLine("    --COMMENTS--");
                    }
                    else
                    {
                        sb.AppendLine("    --NO COMMENTS--");
                    }

                    positionOfVehicle++;
                }
            }

            return sb.ToString().TrimEnd();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove == null)
            {
                throw new ArgumentNullException(nameof(commentToRemove));
            }

            if (vehicleToRemoveComment == null)
            {
                throw new ArgumentNullException(nameof(vehicleToRemoveComment));
            }

            if (commentToRemove.Author != this.username)
            {
                throw new ArgumentException("You are not the author!");
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            this.Vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return $"Username: {Username}, FullName: {FirstName} {LastName}, Role: {Role}";
        }
    }
}
