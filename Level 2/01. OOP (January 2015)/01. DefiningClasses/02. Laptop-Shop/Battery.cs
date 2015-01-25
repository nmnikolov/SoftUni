using System;

namespace _02.LaptopShop
{
    class Battery
    {
        private string batteryType;

        private double? batteryLife;

        public string BatteryType
        {
            get { return this.batteryType; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Battery type cannot be empty.");
                }

                this.batteryType = value;
            }
        }

        public double? BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("batteryLife", "Battery life cannot be negative.");
                }

                this.batteryLife = value;             
            }
        }

        public Battery(string batteryType = null, double? batteryLife = null)
        {
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
        }

        public override string ToString()
        {
            string result = String.Format("Battery: {0}\n", this.batteryType ?? "not provided");
            result += String.Format("Battery life: {0}", this.batteryLife != null ? this.batteryLife + " hours" : "not provided");

            return result;
        }
    }
}
