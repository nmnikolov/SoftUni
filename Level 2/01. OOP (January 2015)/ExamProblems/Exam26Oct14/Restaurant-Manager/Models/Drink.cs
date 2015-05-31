namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class Drink : Recipe, IDrink
    {
        private const int MaxDrinkCalories = 100;
        private const int MaxDrinkTimeToPrepare = 20;

        public Drink(string name, int quantityPerServing, decimal price, int calories, int timeToPrepare, bool isCarbonated) 
            : base(name, quantityPerServing, price, calories, MetricUnit.Milliliters, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated { get; private set; }

        public override int Calories
        {
            get
            {
                return base.Calories;
            }

            protected set
            {
                if (value <= 0 || value > MaxDrinkCalories)
                {
                    throw new ArgumentException(string.Format("The calories in a drink must be possitive and less than or equal to {0}.", MaxDrinkCalories));
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }

            protected set
            {
                if (value < 0 || value > MaxDrinkTimeToPrepare)
                {
                    throw new ArgumentException(string.Format("The time to prepare a dring must be possitive and less than or qeual to {0}", MaxDrinkTimeToPrepare));
                }

                base.TimeToPrepare = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.Append(string.Format("Carbonated: {0}", this.IsCarbonated ? "yes" : "no"));

            return output.ToString();
        }
    }
}