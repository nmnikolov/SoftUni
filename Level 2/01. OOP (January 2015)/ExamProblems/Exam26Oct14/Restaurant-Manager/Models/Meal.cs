namespace RestaurantManager.Models
{
    using Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        protected Meal(string name, int quantityPerServing, decimal price, int calories, int timeToPrepare, bool isVegan) 
            : base(name, quantityPerServing, price, calories, MetricUnit.Grams, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; protected set; }

        public virtual void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            string output = (this.IsVegan ? "[VEGAN] " : string.Empty) + base.ToString();

            return output;
        }
    }
}