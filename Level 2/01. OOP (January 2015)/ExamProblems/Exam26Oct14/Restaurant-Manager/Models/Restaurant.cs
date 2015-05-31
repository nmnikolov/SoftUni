namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Restaurant : IRestaurant
    {
        private const int DelimiterLength = 5;
        private const char RestaurantDelimiterSymbol = '*';
        private const char MenuDelimiterSymbol = '~';
        private const string RequiredErrorMessage = "The {0} is required.";
        private string name;
        private string location;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
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

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(RequiredErrorMessage, "location"));
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes { get; private set; }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("{0} {1} - {2} {0}", new string(RestaurantDelimiterSymbol, DelimiterLength), this.Name, this.Location));

            if (this.Recipes.Any())
            {
                var menu = new List<string>();

                var drinks = this.Recipes.Where(r => r is IDrink).ToList();
                var salads = this.Recipes.Where(r => r is ISalad).ToList();
                var mainCourses = this.Recipes.Where(r => r is IMainCourse).ToList();
                var desserts = this.Recipes.Where(r => r is IDessert).ToList();

                this.AddTomenu(menu, "DRINKS", drinks);
                this.AddTomenu(menu, "SALADS", salads);
                this.AddTomenu(menu, "MAIN COURSES", mainCourses);
                this.AddTomenu(menu, "DESSERTS", desserts);

                output.Append(string.Join(Environment.NewLine, menu));
            }
            else
            {
                output.Append("No recipes... yet");
            }

            return output.ToString();
        }

        private void AddTomenu(List<string> menu, string type, List<IRecipe> recipes)
        {
            if (recipes.Any())
            {
                var orderedRecipes = recipes.OrderBy(r => r.Name);
                var recipe = string.Format(
                    "{0} {1} {0}{2}{3}",
                    new string(MenuDelimiterSymbol, DelimiterLength),
                    type,
                    Environment.NewLine,
                    string.Join(Environment.NewLine, orderedRecipes));

                menu.Add(recipe);
            }
        }
    }
}