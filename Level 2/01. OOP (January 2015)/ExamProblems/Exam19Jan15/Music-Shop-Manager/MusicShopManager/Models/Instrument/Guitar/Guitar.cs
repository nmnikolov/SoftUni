namespace MusicShopManager.Models.Instrument.Guitar
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Guitar : Instrument, IGuitar
    {
        private const int DefaultNumberOfStrings = 6;
        private string bodyWood;
        private string fingerboardWood;

        protected Guitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood) 
            : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
        }

        public string BodyWood 
        {
            get
            {
                return this.bodyWood;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(DefaultRequiredMessage, "body wood"));
                }

                this.bodyWood = value;
            }
        }

        public string FingerboardWood 
        {
            get
            {
                return this.fingerboardWood;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(DefaultRequiredMessage, "fingetboard wood"));
                }

                this.fingerboardWood = value;
            }
        }

        public virtual int NumberOfStrings 
        {
            get
            {
                return DefaultNumberOfStrings;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendLine(string.Format("Strings: {0}", this.NumberOfStrings));
            output.AppendLine(string.Format("Body wood: {0}", this.BodyWood));
            output.Append(string.Format("Fingerboard wood: {0}", this.FingerboardWood));

            return output.ToString();
        }
    }
}