using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_part_2_test
{
    internal class Recipe_Manager
    {
        private List<Recipe> recipes;
        private Recipe selectedRecipe;

        public Recipe_Manager()
        {
            recipes = new List<Recipe>();
            selectedRecipe = null;
        }

        private static List<Recipe> GetRecipes()
        {
            return recipes;
        }

        private static Recipe GetSelectedRecipe()
        {
            return selectedRecipe;
        }

        private static Recipe GetSelectedRecipe(Recipe selectedRecipe)
        {
            return selectedRecipe;
        }

        static void AddRecipe(List<Recipe> recipes, Recipe selectedRecipe)
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            Recipe newRecipe = new Recipe(recipeName);
            recipes.Add(newRecipe);
            selectedRecipe = newRecipe;

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                switch (unit.ToLower())
                {
                    case "ttbsp":
                        unit = "tablespoon";
                        break;
                    case "tsp":
                        unit = "teaspoon";
                        break;
                    case "oz":
                        unit = "ounce";
                        break;
                    case "fl. oz":
                        unit = "fluid ounce";
                        break;
                    case "c":
                        unit = "cup";
                        break;
                    case "qt":
                        unit = "quart";
                        break;
                    case "pt":
                        unit = "pint";
                        break;
                    case "gal":
                        unit = "gallon";
                        break;
                    case "lb":
                        unit = "pound";
                        break;
                    case "ml":
                        unit = "milliliter";
                        break;
                    case "g":
                        unit = "grams";
                        break;
                    case "kg":
                        unit = "kilogram";
                        break;
                    case "l":
                        unit = "liter";
                        break;
                    default:
                        break;
                }

                selectedRecipe.Ingredients.Add(new Ingredient(name, quantity, unit));
            }

            Console.Write("\nEnter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nStep {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();
                selectedRecipe.Steps.Add(description);
            }

            Console.WriteLine("\nRecipe added successfully.\n");
        }

        public void DisplayRecipes()
        {
            Console.WriteLine("List of Recipes:");
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
            Console.WriteLine();
        }

        public void SelectRecipe()
        {
            Console.Write("Enter the name of the recipe to select: ");
            string recipeName = Console.ReadLine();
            selectedRecipe = recipes.FirstOrDefault(recipe => recipe.Name == recipeName);

            if (selectedRecipe != null)
            {
                Console.WriteLine($"Selected recipe: {selectedRecipe.Name}\n");
            }
            else
            {
                Console.WriteLine("Recipe not found.\n");
            }
        }

        public void AddIngredientsToSelectedRecipe()
        {
            if (selectedRecipe == null)
            {
                Console.WriteLine("No recipe selected.\n");
                return;
            }

            Console.Write("Enter the number of ingredients to add: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                selectedRecipe.AddIngredient(name, quantity, unit);
            }

            Console.WriteLine("Ingredients added to the selected recipe.\n");
        }

        public void DisplaySelectedRecipe()
        {
            if (selectedRecipe == null)
            {
                Console.WriteLine("No recipe selected.\n");
                return;
            }

            Console.WriteLine($"Selected recipe: {selectedRecipe.Name}");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in selectedRecipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }
            Console.WriteLine("Steps:");
            foreach (RecipeStep step in selectedRecipe.Steps)
            {
                Console.WriteLine(step.Description);
            }
            Console.WriteLine();
        }

        public void ScaleSelectedRecipe()
        {
            if (selectedRecipe == null)
            {
                Console.WriteLine("No recipe selected.\n");
                return;
            }

            Console.Write("Enter the scaling factor: ");
            double scalingFactor = double.Parse(Console.ReadLine());

            selectedRecipe.ScaleRecipe(scalingFactor);

            Console.WriteLine("Recipe scaled.\n");
        }

        public void ResetQuantities()
        {
            if (selectedRecipe == null)
            {
                Console.WriteLine("No recipe selected.\n");
                return;
            }

            selectedRecipe.ResetQuantities();

            Console.WriteLine("Quantities reset.\n");
        }

        public void ClearSelectedRecipe()
        {
            selectedRecipe = null;

            Console.WriteLine("Selected recipe cleared.\n");
        }

        public void MainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nEnter a command:");
                Console.WriteLine("1. Add recipe");
                Console.WriteLine("2. Display recipes");
                Console.WriteLine("3. Select recipe");
                Console.WriteLine("4. Add ingredients to selected recipe");
                Console.WriteLine("5. Display selected recipe");
                Console.WriteLine("6. Scale selected recipe");
                Console.WriteLine("7. Reset quantities of selected recipe");
                Console.WriteLine("8. Clear selected recipe");
                Console.WriteLine("9. Exit");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        AddRecipe(GetRecipes(), GetSelectedRecipe(GetSelectedRecipe()));
                        break;
                    case "2":
                        DisplayRecipes();
                        break;
                    case "3":
                        SelectRecipe();
                        break;
                    case "4":
                        AddIngredientsToSelectedRecipe();
                        break;
                    case "5":
                        DisplaySelectedRecipe();
                        break;
                    case "6":
                        ScaleSelectedRecipe();
                        break;
                    case "7":
                        ResetQuantities();
                        break;
                    case "8":
                        ClearSelectedRecipe();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }

        public void Start()
        {
            MainMenu();
        }
    
}
}
