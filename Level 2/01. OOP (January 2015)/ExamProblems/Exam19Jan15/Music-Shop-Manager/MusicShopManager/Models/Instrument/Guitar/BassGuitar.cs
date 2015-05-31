namespace MusicShopManager.Models.Instrument.Guitar
{
    using Interfaces;

    public class BassGuitar : Guitar, IBassGuitar
    {
        private const int DefaultBassNumberOfStrings = 4;

        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood) 
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.IsElectronic = true;
        }

        public override int NumberOfStrings
        {
            get
            {
                return DefaultBassNumberOfStrings;
            }
        }
    }
}