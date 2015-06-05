namespace VehicleParkSystem.Models.Vehicle
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Engine;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private string licensePlate;
        private string owner;
        private int reservedHours;
        private decimal overtimeRate;
        private decimal regularRate;

        protected Vehicle(string licensePlate, string owner, int reservedHours, decimal regularRate, decimal overtimeRate)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reservedHours;
            this.RegularRate = regularRate;
            this.OvertimeRate = overtimeRate;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2}$"))
                {
                    throw new ArgumentException(Messages.InvalidLicensePlate);
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException(string.Format(Messages.Required, "owner"));
                }

                this.owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Messages.NonNegative, "regular rate"));
                }

                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Messages.NonNegative, "overtime rate"));
                }

                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Messages.Possitive, "reserved hours"));
                }

                this.reservedHours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", this.GetType().Name, this.LicensePlate, this.Owner);

            return vehicle.ToString();
        }
    }
}