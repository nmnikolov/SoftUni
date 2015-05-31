namespace MusicShopManager.Models.Instrument
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected Instrument(string make, string model, decimal price, string color) 
            : base(make, model, price)
        {
            this.Color = color;
        }

        public bool IsElectronic { get; protected set; }

        public string Color 
        {
            get
            {
                return this.color;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(DefaultRequiredMessage, "color"));
                }

                this.color = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendLine(string.Format("Color: {0}", this.Color));
            output.AppendLine(string.Format("Electronic: {0}", this.IsElectronic ? "yes" : "no"));

            return output.ToString();
        }
    }
}