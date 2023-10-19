using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_part_2_test
{
    internal class Recipe
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        public string RecipeName { get; }
       public event RecipeExceedsCaloriesHandler RecipeExceedsCalories;

        public Recipe(string recipeName)
        {
            RecipeName = recipeName;
            RecipeExceedsCalories += NotifyRecipeExceedsCalories;
        }

        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            ingredients.Add(ingredient);

            double totalCalories = CalculateTotalCalories();

            if (totalCalories > 300)
            {
                RecipeExceedsCalories?.Invoke(RecipeName);
            }
        }

        public void DisplayIngredients()
        {
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit}");
            }
        }

        public double CalculateTotalCalories()
        {
            return ingredients.Sum(i => i.Calories);
        }

        public void ScaleRecipe(double scaleFactor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = 0;
            }
        }

        private void NotifyRecipeExceedsCalories(string recipeName)
        {
            Console.WriteLine($"Warning: Recipe '{recipeName}' exceeds 300 calories.\n");
        }
    
}
}
