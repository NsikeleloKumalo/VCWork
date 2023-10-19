using System;
using System.Collections.Generic;

namespace POE_PROG_TEST_SEMESTER1
{
    // Define a class for the recipe
    class Recipe
    {
        // The recipe has a list of ingredients and a list of steps
        public List<Ingredient> Ingredients = new List<Ingredient>();
        public List<RecipeStep> Steps = new List<RecipeStep>();

        // Method to add a recipe step to the Steps list
        public void AddIngredient(string name, double quantity, string unit)
        {
            // Create a new instance of Ingredient and add it to the Ingredients list
            Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
        }
        // Method to add a recipe step to the Steps list
        public void AddStep(string description)
        {
            // Create a new instance of RecipeStep and add it to the Steps list
            Steps.Add(new RecipeStep { Description = description });
        }
        // Method to display the recipe, including ingredients and steps
        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            // Iterate through the list of ingredients and print each ingredient's properties
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine("{0} {1} {2}", ingredient.Quantity, ingredient.Unit, ingredient.Name);
            }

            Console.WriteLine("\nSteps:");
            // Iterate through the list of steps and print each step's description
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Steps[i].Description);
            }
        }
        // Scale the quantities of all ingredients in the recipe by a factor
        public void ScaleRecipe(double factor)
        {
            // Iterate through the list of ingredients and multiply each ingredient's quantity by the factor
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
        // Method to reset the quantities of all ingredients to half their original values
        public void ResetQuantities()
        {
            // Iterate through the list of ingredients and divide each ingredient's quantity by 2
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity /= 2;
            }
        }
        // Method to clear the recipe (empty the Ingredients and Steps lists)
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
        }
    }
    class Ingredient
    {
        public string Name;
        public double Quantity;
        public string Unit;
    }

    class RecipeStep
    {
        public string Description;
    }


}