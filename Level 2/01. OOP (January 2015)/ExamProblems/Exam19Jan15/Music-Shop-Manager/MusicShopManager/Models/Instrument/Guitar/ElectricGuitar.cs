namespace MusicShopManager.Models.Instrument.Guitar
{
    using System;
    using System.Text;
    using Interfaces;

    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets) 
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
            this.IsElectronic = true;
        }

        public int NumberOfAdapters 
        {
            get
            {
                return this.numberOfAdapters;
            }

            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of adapters must be non-negative");
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets 
        {
            get
            {
                return this.numberOfFrets;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(DefaultPositiveMessage, "number of frets"));
                }

                this.numberOfFrets = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendLine(string.Format("{0}Adapters: {1}", Environment.NewLine, this.NumberOfAdapters));
            output.Append(string.Format("Frets: {0}", this.NumberOfFrets));

            return output.ToString();
        }
    }
}