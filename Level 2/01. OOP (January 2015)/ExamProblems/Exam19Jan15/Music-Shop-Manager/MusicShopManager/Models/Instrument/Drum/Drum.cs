namespace MusicShopManager.Models.Instrument.Drum
{
    using System;
    using System.Text;
    using Interfaces;

    public class Drum : Instrument, IDrums
    {
        private int width;
        private int height;

        public Drum(string make, string model, decimal price, string color, int width, int height) 
            : base(make, model, price, color)
        {
            this.Width = width;
            this.Height = height;
            this.IsElectronic = false;
        }

        public int Width 
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(DefaultPositiveMessage, "width"));
                }

                this.width = value;
            }
        }

        public int Height 
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(DefaultPositiveMessage, "height"));
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append(string.Format("Size: {0}cm x {1}cm", this.Width, this.Height));

            return output.ToString();
        }
    }
}