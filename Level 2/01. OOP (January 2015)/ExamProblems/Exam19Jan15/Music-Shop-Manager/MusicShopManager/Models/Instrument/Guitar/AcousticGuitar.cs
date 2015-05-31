namespace MusicShopManager.Models.Instrument.Guitar
{
    using System;
    using System.Text;
    using Interfaces;

    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial) 
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
            this.IsElectronic = false;
        }

        public bool CaseIncluded { get; private set; }

        public StringMaterial StringMaterial { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendLine(string.Format("{0}Case included: {1}", Environment.NewLine, this.CaseIncluded ? "yes" : "no"));
            output.Append(string.Format("String material: {0}", this.StringMaterial));

            return output.ToString();
        }
    }
}