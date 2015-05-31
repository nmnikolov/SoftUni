namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class Salad : Meal, ISalad
    {
        public Salad(string name, int quantityPerServing, decimal price, int calories, int timeToPrepare, bool containPasta)
            : base(name, quantityPerServing, price, calories, timeToPrepare, true)
        {
            this.ContainsPasta = containPasta;
        }

        public bool ContainsPasta { get; private set; }

        public override void ToggleVegan()
        {
            throw new InvalidOperationException("A salad must always be vegan");
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.Append(string.Format("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no"));

            return output.ToString();
        }
    }
}