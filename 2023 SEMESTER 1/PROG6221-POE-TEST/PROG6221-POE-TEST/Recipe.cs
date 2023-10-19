using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_TEST
{
    class Recipe
    {
        private List<Ingredient> ingredients;
        private List<string> steps;
        private Recipe recipe;
        public List<Ingredient> Ingredients { get; } = new List<Ingredient>();
        public List<string> Steps { get; } = new List<string>();
        public Recipe(List<Ingredient> ingredients)
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void EnterRecipe()
        {
            Recipe recipe = new Recipe();
            // code to enter recipe details
            Console.Write("Enter number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            List<Ingredient> ingredients = new List<Ingredient>();

            for (int i = 1; i <= numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i}:");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit of measurement: ");
                string unitOfMeasurement = Console.ReadLine();

                ingredients.Add(new Ingredient(name, quantity, unitOfMeasurement));
            }

            Console.Write("Enter number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            List<string> steps = new List<string>();

            for (int i = 1; i <= numSteps; i++)
            {
                Console.WriteLine($"Enter step {i}:");
                string step = Console.ReadLine();
                steps.Add(step);
            }

            Recipe recipe = new Recipe(ingredients, steps);
            this.recipe = recipe;

            Console.WriteLine("Recipe entered successfully.");
        }
    
    }

        public void DisplayRecipe()
        {
        // code to display recipe details
            if (Recipe == null)
            {
                Console.WriteLine("No recipe entered yet.");
                return;
            }

            Console.WriteLine("Recipe:");
            Console.WriteLine("-------");

            Console.WriteLine("Ingredients:");

            foreach (Ingredient ingredient in Recipe.Ingredient)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement}");
            }

            Console.WriteLine("Steps:");

            int stepNumber = 1;

            foreach (string step in Recipe.steps)
            {
                Console.WriteLine($"{stepNumber}. {step}");
                stepNumber++;
            }
        }

    

    public void ScaleRecipe(Recipe recipe, double scaleFactor)
        {
        // code to scale recipe quantities
        if (recipe == null)
        {
            Console.WriteLine("No recipe entered yet.");
            return;
        }

        if (scaleFactor <= 0)
        {
            Console.WriteLine("Invalid scale factor. Scale factor must be greater than zero.");
            return;
        }

        Console.WriteLine($"Scaling recipe by factor of {scaleFactor}...");

        foreach (Ingredient ingredient in recipe.Ingredients)
        {
            ingredient.Quantity *= scaleFactor;
        }

        Console.WriteLine("Recipe scaled successfully!");
    }

    public void ResetQuantities()
        {
        // code to reset recipe quantities to original values
        if (Recipe == null)
        {
            Console.WriteLine("No recipe entered yet.");
            return;
        }

        Console.WriteLine("Resetting recipe quantities to original values...");

        foreach (Ingredient ingredient in Recipe.Ingredient)
        {
            ingredient.Quantity = ingredient.OriginalQuantity;
        }

        Console.WriteLine("Quantities reset successfully!");
    }
    }
class Ingredient
{

    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public double OriginalQuantity { get; set; }

    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        OriginalQuantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name}: {Quantity} {Unit}";
    }
}



