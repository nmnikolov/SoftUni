namespace MusicShopManager.Models.Microphone
{
    using System.Text;
    using Interfaces;

    public class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable) 
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append(string.Format("Cable: {0}", this.HasCable ? "yes" : "no"));

            return output.ToString();
        }
    }
}