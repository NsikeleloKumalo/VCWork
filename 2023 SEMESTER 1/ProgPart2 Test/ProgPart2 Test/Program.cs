using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPart2_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            recipeManager.RecipeCalorieExceeded += HandleRecipeCalorieExceeded;

            recipeManager.Run();

        }

        private static void HandleRecipeCalorieExceeded(string recipeName, int totalCalories)
        {
            Console.WriteLine($"Recipe '{recipeName}' has exceeded 300 calories. Total calories: {totalCalories}.");
        }
    }
}
   
