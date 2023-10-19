using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class RecipeApplication
    {
        // RecipeManager.cs
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public RecipeApplication()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit)
        {
            Ingredients.Add(new Ingredient(name, quantity, unit));
        }

        public void AddStep(string description)
        {
            Steps.Add(description);
        }

        public void Display()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            Console.WriteLine();
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void Reset()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        public void Clear()
        {
            Name = null;
            Ingredients.Clear();
            Steps.Clear();
        }

        public double TotalCalories()
        {
            double totalCalories = 0.0;
            foreach (var ingredient in Ingredients)
            {                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }

}

