using System;

namespace _02.LaptopShop
{
    class Battery
    {
        private string batteryType;

        private double batteryLife;

        public string BatteryType
        {
            get { return this.batteryType; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new Exception("");
                }

                this.batteryType = value;
            }
        }

        public double BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("");
                }

                this.batteryLife = value;
            }
        }

        public Battery(string batteryType = null, double batteryLife = 0d)
        {
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
        }

        public override string ToString()
        {
            string result = String.Format("Battery: {0}\nBattery life: ", this.batteryType ?? "not provided");

            if (this.batteryLife == 0d)
            {
                result += "not provided";
            }
            else
            {
                result += this.batteryLife + " hours";
            }

            return result;
        }
    }
}
