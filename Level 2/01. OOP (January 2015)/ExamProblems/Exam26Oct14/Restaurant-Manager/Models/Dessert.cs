namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class Dessert : Meal, IDessert
    {
        public Dessert(string name, int quantityPerServing, decimal price, int calories, int timeToPrepare, bool isVegan) 
            : base(name, quantityPerServing, price, calories, timeToPrepare, isVegan)
        {
            this.WithSugar = true;
        }

        public bool WithSugar { get; private set; }
        
        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(this.WithSugar ? string.Empty : "[NO SUGAR] ");
            output.Append(base.ToString());

            return output.ToString();
        }
    }
}