using System;

namespace _02.LaptopShop
{
    class Laptop
    {
        private string model;

        private string manufacturer;

        private string processor;

        private int? ram = null;

        private string graphicCard;

        private int? hdd = null;

        private string screen;

        private Battery battery;

        private decimal price;

        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be empty.");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value != null && String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufacturer cannot be empty.");
                }

                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Processor cannot be empty.");
                }

                this.processor = value;
            }
        }

        public int? Ram
        {
            get { return this.ram; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ram", "Ram cannot be negative.");
                }

                this.ram = value;
            }
        }

        public string GraphicCard
        {
            get { return this.graphicCard; }
            set
            {
                if (value != null && String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Graphic card cannot be empty.");
                }

                this.graphicCard = value;
            }
        }

        public int? Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("hdd", "Hdd cannot be negative.");
                }

                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value != null && String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Screen cannot be empty.");
                }

                this.screen = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price cannot be negative.");
                }
                this.price = value;
            }
        }

        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, int? ram = null, string graphicCard = null, int? hdd = null, string screen = null, string batteryType = null, double? batteryLife = null)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicCard = graphicCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.battery = new Battery(batteryType, batteryLife);
        }

        public override string ToString()
        {
            string output = String.Format("Model: {0}\n", this.model);
            output += String.Format("Manufacturer: {0}\n", this.manufacturer ?? "not provided");
            output += String.Format("Processor: {0}\n", this.processor ?? "not provided");
            output += String.Format("RAM: {0}\n", this.ram != null ? this.ram + " GB" : "not provided");
            output += String.Format("Graphic card: {0}\n", this.graphicCard ?? "not provided");
            output += String.Format("HDD: {0}\n", this.hdd != null ? this.hdd + " GB" : "not provided");
            output += String.Format("Screen: {0}\n", this.screen ?? "not provided");
            output += String.Format("{0}\n", this.battery);
            output += String.Format("Price: {0:N2} lv.\n", this.price);
            return output;
        }
    }
}