namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, int quantityPerServing, decimal price, int calories, int timeToPrepare, bool isVegan, MainCourseType type) 
            : base(name, quantityPerServing, price, calories, timeToPrepare, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString());
            output.Append(string.Format("Type: {0}", this.Type));

            return output.ToString();
        }
    }
}