using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPart2_Test
{
    class RecipeManager
    {
        // Delegate to notify when a recipe exceeds 300 calories
        public delegate void RecipeCalorieExceededHandler(string recipeName, int totalCalories);

        // Event for recipe calorie exceeded notification
        public event RecipeCalorieExceededHandler RecipeCalorieExceeded;

        private List<Recipe> Recipes;
        private Recipe selectedRecipe;


        public RecipeManager()
        {
            Recipes = new List<Recipe>();
        }


        //public RecipeManager()
        //{
        //    recipes = new List<Recipe>();
        //}

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WELCOME TO BLESSING'S RECIPE APP!");
                Console.WriteLine("Would you like to go to the main menu or exit the program?");
                Console.WriteLine("1. Main menu");
                Console.WriteLine("2. Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Exiting the program.");
                    return;
                }

                switch (option)
                {
                    case 1:
                        ShowMainMenu();
                        break;
                    case 2:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a valid option.");
                        break;
                }
            }
        }

        private void ShowMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Main menu");
                Console.WriteLine("Enter a command:");
                Console.WriteLine("1. Add recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Choose a recipe to display");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset quantities of a recipe");
                Console.WriteLine("6. Clear a recipe");
                Console.WriteLine("7. Add ingredients to selected recipe");
                Console.WriteLine("8. Display selected recipe");
                Console.WriteLine("9. Scale selected recipe");
                Console.WriteLine("10. Reset quantities of selected recipe");
                Console.WriteLine("11. Clear selected recipe");
                Console.WriteLine("12. Exit Main Menu");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please enter a valid option.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        DisplayAllRecipes();
                        break;
                    case 3:
                        ChooseRecipeToDisplay();
                        break;
                    case 4:
                        ScaleRecipe();
                        break;
                    case 5:
                        ResetQuantities();
                        break;
                    case 6:
                        ClearRecipe();
                        break;
                    case 7:
                        AddIngredientsToSelectedRecipe();
                        break;
                    case 8:
                        DisplaySelectedRecipe();
                        break;
                    case 9:
                        ScaleSelectedRecipe();
                        break;
                    case 10:
                        ResetQuantitiesOfSelectedRecipe();
                        break;
                    case 11:
                        ClearSelectedRecipe();
                        break;
                    case 12:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a valid option.");
                        break;
                }
            }
        }



        private void ChooseRecipeToDisplay()
        {
            Console.WriteLine("Enter the name of the recipe to display:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipe.DisplayRecipe();
            }
        }
        private void ScaleRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to scale:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
            double scalingFactor;
            if (!double.TryParse(Console.ReadLine(), out scalingFactor))
            {
                Console.WriteLine("Invalid scaling factor. Recipe scaling not applied.");
                return;
            }

            switch (scalingFactor)
            {
                case 0.5:
                    recipe.Ingredients.ForEach(i => i.Quantity *= 0.5);
                    break;
                case 2:
                    recipe.Ingredients.ForEach(i => i.Quantity *= 2);
                    break;
                case 3:
                    recipe.Ingredients.ForEach(i => i.Quantity *= 3);
                    break;
                default:
                    Console.WriteLine("Invalid scaling factor. Recipe scaling not applied.");
                    return;
            }

            Console.WriteLine($"Recipe '{recipe.Name}' scaled successfully.");
            recipe.DisplayRecipe();
        }

        private void ResetQuantities()
        {
            Console.WriteLine("Enter the name of the recipe to reset quantities:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }

            Console.WriteLine($"Quantities reset for recipe '{recipe.Name}' successfully.");
            recipe.DisplayRecipe();
        }

        private void DisplayAllRecipes()
        {
            // Check if there are any recipes available
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("All Recipes:");

            // Iterate over each recipe in alphabetical order
            foreach (Recipe recipe in Recipes.OrderBy(r => r.Name))
            {
                // Display the name of the recipe
                Console.WriteLine($"Recipe: {recipe.Name}");

                // Display the ingredients of the recipe
                Console.WriteLine("Ingredients:");
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    // Display the ingredient details: name, quantity, unit, calories, food group
                    Console.WriteLine($"- {ingredient.Name}, Quantity: {ingredient.Quantity} {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
                }

                // Display the steps of the recipe
                Console.WriteLine("Steps:");
                int stepNumber = 1;
                foreach (RecipeStep step in recipe.Steps)
                {
                    // Display the step number and description
                    Console.WriteLine($"Step {stepNumber}: {step.Description}");
                    stepNumber++;
                }

                Console.WriteLine();
            }
            Console.ReadLine(); // Wait for user input before proceeding
        }



        private void ClearRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to clear:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            recipe.Name = string.Empty;
            recipe.Ingredients.Clear();
            recipe.Steps.Clear();

            Console.WriteLine($"Recipe '{recipeName}' cleared successfully.");
        }


        private void DisplaySelectedRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to display:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipe.DisplayRecipe();
            }
        }

        private void ScaleSelectedRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to scale:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
            double scalingFactor;
            if (!double.TryParse(Console.ReadLine(), out scalingFactor))
            {
                Console.WriteLine("Invalid scaling factor. Recipe scaling not applied.");
                return;
            }

            switch (scalingFactor)
            {
                case 0.5:
                    recipe.Ingredients.ForEach(i => i.Quantity *= 0.5);
                    break;
                case 2:
                    recipe.Ingredients.ForEach(i => i.Quantity *= 2);
                    break;
                case 3:
                    recipe.Ingredients.ForEach(i => i.Quantity *= 3);
                    break;
                default:
                    Console.WriteLine("Invalid scaling factor. Recipe scaling not applied.");
                    return;
            }

            Console.WriteLine($"Recipe '{recipe.Name}' scaled successfully.");
            recipe.DisplayRecipe();
        }

        private void ResetQuantitiesOfSelectedRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to reset quantities:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            recipe.Ingredients.ForEach(i => i.Quantity = 0);

            Console.WriteLine($"Quantities reset for recipe '{recipe.Name}' successfully.");
            recipe.DisplayRecipe();
        }

        private void ClearSelectedRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to clear:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            recipe.Ingredients.Clear();

            Console.WriteLine($"Recipe '{recipe.Name}' cleared successfully.");
        }
        private void AddIngredientsToSelectedRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to add ingredients:");
            string recipeName = Console.ReadLine();

            Recipe recipe = Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            Console.WriteLine("Enter the name of the ingredient:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the quantity of the ingredient:");
            double quantity = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose the unit:");
            Console.WriteLine("1. tablespoon (ttbsp)");
            Console.WriteLine("2. teaspoon (tsp)");
            Console.WriteLine("3. ounce (oz)");
            Console.WriteLine("4. fluid ounce (fl. oz)");
            Console.WriteLine("5. cup (c)");
            Console.WriteLine("6. quart (qt)");
            Console.WriteLine("7. pint (pt)");
            Console.WriteLine("8. gallon (gal)");
            Console.WriteLine("9. pound (lb)");
            Console.WriteLine("10. milliliter (ml)");
            Console.WriteLine("11. gram (g)");
            Console.WriteLine("12. milligram (mg)");
            Console.WriteLine("13. kilogram (kg)");
            Console.WriteLine("14. liter (l)");
            Console.Write("Enter the option number: ");

            string unit;
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    unit = "tablespoon";
                    break;
                case 2:
                    unit = "teaspoon";
                    break;
                case 3:
                    unit = "ounce";
                    break;
                case 4:
                    unit = "fluid ounce";
                    break;
                case 5:
                    unit = "cup";
                    break;
                case 6:
                    unit = "quart";
                    break;
                case 7:
                    unit = "pint";
                    break;
                case 8:
                    unit = "gallon";
                    break;
                case 9:
                    unit = "pound";
                    break;
                case 10:
                    unit = "milliliter";
                    break;
                case 11:
                    unit = "gram";
                    break;
                case 12:
                    unit = "milligram";
                    break;
                case 13:
                    unit = "kilogram";
                    break;
                case 14:
                    unit = "liter";
                    break;
                default:
                    Console.WriteLine("Invalid option. Using 'unit' as the default unit.");
                    unit = "unit";
                    break;
            }

            Console.WriteLine("Enter the number of calories:");
            int calories = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the food group:");
            string foodGroup = Console.ReadLine();

            recipe.Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));

            if (recipe.CalculateTotalCalories() > 300)
            {
                RecipeCalorieExceeded?.Invoke(recipe.Name, recipe.CalculateTotalCalories());
            }

            Console.WriteLine($"Ingredient '{name}' added to recipe '{recipe.Name}' successfully.");
        }

        // AddRecipe() method to add a new recipe
        public void AddRecipe()
        {
            // Prompt the user to enter the name of the recipe
            Console.WriteLine("Enter the name of the recipe:");
            // Read the recipe name from the user input
            string recipeName = Console.ReadLine();

            // Create a new Recipe object with the provided name
            Recipe newRecipe = new Recipe(recipeName);

            // Prompt the user to enter the number of ingredients
            Console.WriteLine("Enter the number of ingredients:");
            // Read the ingredient count from the user input
            int ingredientCount = int.Parse(Console.ReadLine());

            // Prompt the user to enter the ingredients one by one
            Console.WriteLine("Enter the ingredients (name, quantity) one by one:");
            Console.WriteLine("For each ingredient, enter the name and quantity separated by a comma.");
            Console.WriteLine("Example: 'IngredientName, Quantity'");

            // Loop through the ingredient count and gather ingredient information
            for (int i = 0; i < ingredientCount; i++)
            {
                // Prompt the user to enter the ingredient details
                Console.Write($"Ingredient {i + 1}: ");
                // Read the ingredient input from the user
                string ingredientInput = Console.ReadLine();
                // Split the ingredient input by comma to extract name and quantity
                string[] ingredientInfo = ingredientInput.Split(','); // Split the ingredient input into an array of strings using the comma as the separator

                // Validate if the input contains both name and quantity
                if (ingredientInfo.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please enter the ingredient name and quantity separated by a comma.");
                    i--;// Decrement the loop counter to repeat the current iteration
                    continue;// Continue to the next iteration of the loop
                }

                // Trim the ingredient name and parse the quantity
                string name = ingredientInfo[0].Trim();// Get the ingredient name and remove leading/trailing spaces
                double quantity;
                // Try parsing the quantity as a double
                if (!double.TryParse(ingredientInfo[1].Trim(), out quantity))
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid numerical value.");
                    i--;
                    continue;
                }

                // Prompt the user to choose the unit
                Console.WriteLine("Choose the unit:");
                // Display the available unit options
                Console.WriteLine("1. tablespoon (ttbsp)");
                Console.WriteLine("2. teaspoon (tsp)");
                Console.WriteLine("3. ounce (oz)");
                Console.WriteLine("4. fluid ounce (fl. oz)");
                Console.WriteLine("5. cup (c)");
                Console.WriteLine("6. quart (qt)");
                Console.WriteLine("7. pint (pt)");
                Console.WriteLine("8. gallon (gal)");
                Console.WriteLine("9. pound (lb)");
                Console.WriteLine("10. milliliter (ml)");
                Console.WriteLine("11. gram (g)");
                Console.WriteLine("12. milligram (mg)");
                Console.WriteLine("13. kilogram (kg)");
                Console.WriteLine("14. liter (l)");
                Console.Write("Enter the option number: ");

                // Read the unit option from the user input
                string unit;
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    // Map the option number to the corresponding unit
                    case 1:
                        unit = "tablespoon";
                        break;
                    case 2:
                        unit = "teaspoon";
                        break;
                    case 3:
                        unit = "ounce";
                        break;
                    case 4:
                        unit = "fluid ounce";
                        break;
                    case 5:
                        unit = "cup";
                        break;
                    case 6:
                        unit = "quart";
                        break;
                    case 7:
                        unit = "pint";
                        break;
                    case 8:
                        unit = "gallon";
                        break;
                    case 9:
                        unit = "pound";
                        break;
                    case 10:
                        unit = "milliliter";
                        break;
                    case 11:
                        unit = "gram";
                        break;
                    case 12:
                        unit = "milligram";
                        break;
                    case 13:
                        unit = "kilogram";
                        break;
                    case 14:
                        unit = "liter";
                        break;

                    default:
                        Console.WriteLine("Invalid option. Using 'unit' as the default unit.");
                        unit = "unit";
                        break;
                }

                // Prompt the user to enter the calories
                Console.WriteLine("Enter the calories:");
                // Read the calories from the user input

                int calories;
                if (!int.TryParse(Console.ReadLine(), out calories))
                {
                    Console.WriteLine("Invalid calories. Please enter a valid numerical value.");
                    i--;
                    continue;
                }

                if (calories > 300)
                {
                    Console.WriteLine("Warning: The entered calories exceed 300.");
                }
                //int calories;
                //if (!int.TryParse(Console.ReadLine(), out calories))
                //{
                //    Console.WriteLine("Invalid calories. Please enter a valid numerical value.");
                //    i--; // Decrement the loop counter to repeat the current iteration
                //    continue;// Continue to the next iteration of the loop
                //}

                // Prompt the user to enter the food group
                Console.WriteLine("Enter the food group:");
                // Read the food group from the user input
                string foodGroup = Console.ReadLine();

                // Create a new Ingredient object with the gathered information and add it to the recipe
                newRecipe.Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }

            // Prompt the user to enter the number of recipe steps
            Console.WriteLine("Enter the number of recipe steps:");
            // Read the step count from the user input
            int stepCount = int.Parse(Console.ReadLine());

            // Prompt the user to enter the recipe steps one by one
            Console.WriteLine("Enter the recipe steps one by one:");
            for (int i = 0; i < stepCount; i++)
            {
                // Prompt the user to enter the description of each step
                Console.Write($"Step {i + 1}: ");
                // Read the step description from the user input
                string description = Console.ReadLine();
                // Create a new RecipeStep object with the provided description and add it to the recipe
                newRecipe.Steps.Add(new RecipeStep { Description = description });
            }

            // Add the completed recipe to the list of recipes
            Recipes.Add(newRecipe);
            // Display a success message indicating the recipe has been added
            Console.WriteLine($"Recipe '{recipeName}' added successfully.");
        }
    }
}
