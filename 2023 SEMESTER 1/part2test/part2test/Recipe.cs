using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2test
{

    // Define a class for the recipe
    class Recipe
    {
        // The recipe has a list of ingredients and a list of steps
        public List<Ingredient> Ingredients = new List<Ingredient>();
        public List<RecipeStep> Steps = new List<RecipeStep>();
        public string Name { get; set; }
        public int TotalCalories
        {
            get { return Ingredients.Sum(i => i.Calories); }
        }
        // The original recipe is used to reset the quantities of the ingredients
        //private List<Ingredient> originalIngredients = new List<Ingredient>();

        // Static variable for the scale factor
        private static double _scaleFactor = 1.0;
        private double factor;
        private static string recipeName = "";
        private static object recipes;

        // Method to set the original recipe
        //public void SetOriginalRecipe()
        //{
        //    originalIngredients = new List<Ingredient>(Ingredients);
        //}


        //private object  recipeName;

        //public void SetRecipeSize()
        //{

        //    Console.Write("Enter the number of steps to add: ");
        //    int numSteps = int.Parse(Console.ReadLine());

        //    for (int i = 0; i < numSteps; i++)
        //    {
        //        Steps.Add(new RecipeStep());
        //    }
        //}

        // Method to add a recipe step to the Steps list
        //public void AddIngredient()
        //    {
        //        // Create a new instance of Ingredient and add it to the Ingredients list
        //        try
        //        {//  Block of code to try
        //            Console.Write("Enter the number of ingredients to add: ");
        //            int numIngredients = int.Parse(Console.ReadLine());

        //            for (int i = 0; i < numIngredients; i++)
        //            {
        //                Console.Write($"Enter ingredient {i + 1} name: ");
        //                string name = Console.ReadLine();

        //                Console.Write($"Enter quantity for ingredient {i + 1}: ");
        //                double quantity = double.Parse(Console.ReadLine());

        //                Console.Write($"Enter unit of measurement for ingredient {i + 1}: ");
        //                string unit = Console.ReadLine();

        //                Ingredients.Add(new Ingredient(name, quantity, unit) { OriginalQuantity = quantity });
        //                // Pass in the quantity value twice - once for Quantity and once for OriginalQuantity
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("An error occurred while adding the ingredient: " + ex.Message);
        //        }

        //    }
        //    // Method to add a recipe step to the Steps list
        //    public void AddStep()
        //    {
        //        // Create a new instance of RecipeStep and add it to the Steps list
        //        try
        //        {//  Block of code to try
        //            Console.Write("Enter the number of steps to add: ");
        //            int numSteps = int.Parse(Console.ReadLine());

        //            for (int i = 0; i < numSteps; i++)
        //            {
        //                Console.Write($"Enter step {i + 1} description: ");
        //                string description = Console.ReadLine();
        //                Steps.Add(new RecipeStep { Description = description });
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error adding step: " + ex.Message);
        //        }
        //    }

        public void AddRecipe()
        {
            Recipe recipe = new Recipe();

            try
            {
                Console.Write("Enter the recipe name: ");
                recipe.Name = Console.ReadLine();

                Console.Write("Enter the number of ingredients: ");
                int ingredientCount = int.Parse(Console.ReadLine());

                recipe.Ingredients = new List<Ingredient>();
                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.Write($"Enter the name of ingredient {i + 1}: ");
                    string name = Console.ReadLine();

                    Console.Write($"Enter the quantity of ingredient {i + 1}: ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.Write($"Enter the unit of measurement for ingredient {i + 1}: ");
                    string unit = Console.ReadLine();

                    Ingredient ingredient = new Ingredient(name, quantity, unit);

                    Console.Write($"Enter the calories for ingredient {i + 1}: ");
                    ingredient.Calories = int.Parse(Console.ReadLine());

                    Console.Write($"Enter the food group for ingredient {i + 1}: ");
                    ingredient.FoodGroup = Console.ReadLine();

                    recipe.Ingredients.Add(ingredient);
                }

                Console.Write("Enter the number of steps: ");
                int stepCount = int.Parse(Console.ReadLine());

                recipe.Steps = new List<RecipeStep>();
                for (int i = 0; i < stepCount; i++)
                {
                    RecipeStep step = new RecipeStep();

                    Console.Write($"Enter the description for step {i + 1}: ");
                    step.Description = Console.ReadLine();

                    recipe.Steps.Add(step);
                }

                Console.WriteLine("Recipe added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the recipe: " + ex.Message);
            }
        }


        // Method to display the recipe, including ingredients and steps
        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n\n======================================================");
            Console.WriteLine($"  Here are the deatails for a {recipeName} Recipe");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"\nThe ingredients for your {recipeName} Recipe are as follows:");
            Console.ResetColor();
            try
            {//  Block of code to try
                Console.WriteLine("Ingredients:");
                // Iterate through the list of ingredients and print each ingredient's properties
                foreach (Ingredient ingredient in Ingredients)
                {
                    Console.WriteLine("{0} {1} {2}", ingredient.Quantity, ingredient.Unit, ingredient.Name);
                    //Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity * _scaleFactor} {ingredient.Unit}");
                }

                Console.WriteLine("\nSteps:");
                // Iterate through the list of steps and print each step's description
                for (int i = 0; i < Steps.Count; i++)
                {
                    //Console.WriteLine("{0}. {1}", i + 1, Steps[i].Description);
                    Console.WriteLine($"{i + 1}. {Steps[i].Description}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying recipe: " + ex.Message);
            }
        }
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }




        // Scale the quantities of all ingredients in the recipe by a factor
        public void ScaleRecipe()
        {
            try
            {//  Block of code to try
                Console.Write("Enter scaling factor (0,5; 2; or 3): ");
                double factor = double.Parse(Console.ReadLine());
                // Iterate through the list of ingredients and multiply each ingredient's quantity by the factor
                switch (factor)
                { //prompts the user to enter a scaling factor(0.5, 2, or 3), and multiplies the quantities of all ingredients in the recipe by that factor using the ScaleRecipe method.
                    case 0.5:
                    case 2:
                    case 3:
                        _scaleFactor = factor;
                        foreach (Ingredient ingredient in Ingredients)
                        {
                            ingredient.Quantity *= factor;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid scaling factor. Please enter 0,5; 2; or 3.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error scaling recipe: " + ex.Message);
            }
        }
        //                foreach (Ingredient ingredient in Ingredients)
        //        {
        //            prompts the user to enter a scaling factor (0.5, 2, or 3), and multiplies the quantities of all ingredients in the recipe by that factor using the ScaleRecipe method.
        //           Console.Write("Enter scaling factor (0.5, 2, or 3): ");
        //            double factor = double.Parse(Console.ReadLine());
        //            ingredient.Quantity *= factor;
        //        }
        //    }catch(Exception ex)
        //    {
        //        Console.WriteLine("Error scaling recipe: " + ex.Message);
        //    }
        //}

        // Method to reset the quantities of the ingredients to their original values
        public void ResetQuantities()
        {
            try
            {//  Block of code to try
             // Ingredients = new List<Ingredient>(originalIngredients);
             //Console.WriteLine("Quantities have been reset to their original values.");
             // Iterate through the list of ingredients and divide each ingredient's quantity by 2
                foreach (Ingredient ingredient in Ingredients)
                {
                    ingredient.Quantity = ingredient.OriginalQuantity;
                    //ingredient.Quantity /= _scaleFactor;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error resetting quantities: " + ex.Message);
            }
        }
        // Method to clear the recipe (empty the Ingredients and Steps lists)
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
            _scaleFactor = 1.0;
        }

        public void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("All recipes:");
            List<string> recipeNames = recipes.Select(r => r.Name).OrderBy(name => name).ToList();
            foreach (string name in recipeNames)
            {
                Console.WriteLine(name);
            }
        }

        public void SelectRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Select a recipe to display:");
            int recipeIndex = 1;
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine($"{recipeIndex}. {recipe.Name}");
                recipeIndex++;
            }

            int selectedRecipeIndex;
            while (true)
            {
                Console.Write("Please enter the number of the recipe: ");
                if (int.TryParse(Console.ReadLine(), out selectedRecipeIndex) && selectedRecipeIndex > 0 && selectedRecipeIndex <= recipes.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Recipe selectedRecipe = recipes[selectedRecipeIndex - 1];
            Console.WriteLine();
            selectedRecipe.DisplayRecipe();

            int totalCalories = selectedRecipe.CalculateTotalCalories();
            Console.WriteLine($"Total calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING: This recipe exceeds 300 calories!");
                Console.ResetColor();
            }
        }
       //private static  void OnRecipeCaloriesExceeded(string recipeName, int totalCalories)
       // {
       //     Console.WriteLine($"Warning: The recipe '{recipeName}' has {totalCalories} calories, which exceeds 300.");
       // }

    }



}

