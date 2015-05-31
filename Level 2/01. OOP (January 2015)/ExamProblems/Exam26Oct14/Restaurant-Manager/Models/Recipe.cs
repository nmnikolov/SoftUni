namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Recipe : IRecipe
    {
        private const string RequiredErrorMessage = "The {0} is required.";
        private const string PositiveErrorMessage = "The {0} must be positive.";
        private string name;
        private decimal price;
        private int quantityPerServing;
        private int calories;
        private MetricUnit unit;
        private int timetoPrepare;

        protected Recipe(string name, int quantityPerServing, decimal price, int calories, MetricUnit unit, int timeToPrepare)
        {
            this.Name = name;
            this.QuantityPerServing = quantityPerServing;
            this.Price = price;
            this.Calories = calories;
            this.Unit = unit;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(RequiredErrorMessage, "name"));
                }

                this.name = value;
            }
        }

        public decimal Price 
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PositiveErrorMessage, "price"));
                }

                this.price = value;
            }
        }

        public int QuantityPerServing 
        {
            get
            {
                return this.quantityPerServing;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PositiveErrorMessage, "quantity per serving"));
                }

                this.quantityPerServing = value;
            }
        }

        public virtual int Calories 
        {
            get
            {
                return this.calories;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PositiveErrorMessage, "calories"));
                }

                this.calories = value;
            }
        }

        public MetricUnit Unit 
        {
            get
            {
                return this.unit;
            }

            private set
            {
                this.unit = value;
            }
        }

        public virtual int TimeToPrepare 
        {
            get
            {
                return this.timetoPrepare;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PositiveErrorMessage, "time to prepare"));
                }

                this.timetoPrepare = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format(
                "{0}  {1} {0} ${2}",
                new string('=', 2),
                this.Name,
                decimal.Round(this.Price, 2)));

            output.AppendLine(string.Format(
                "Per serving: {0} {1}, {2} kcal",
                this.QuantityPerServing,
                this.Unit == MetricUnit.Grams ? "g" : "ml",
                this.Calories));

            output.Append(string.Format(
                "Ready in {0} minutes",
                this.TimeToPrepare));

            return output.ToString();
        }
    }
}