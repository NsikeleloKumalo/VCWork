using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPart2_Test
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeStep> Steps { get; set; }


        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<RecipeStep>(); // Initialize the Steps property as an empty list
           

        }

        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(i => i.Calories);
            return totalCalories;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");

            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
            }

            Console.WriteLine("Steps:");
            foreach (RecipeStep step in Steps)
            {
                Console.WriteLine($"- {step.Description}");
            }
        }
    }
}
