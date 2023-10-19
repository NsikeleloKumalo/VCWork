using System;
using System.Collections.Generic;

namespace Part_Three_POE
{
    internal class Recipe
    {
        // Declare a public property 'Ingredients' of type List<Ingredient> to store the ingredients of the recipe
        public List<Ingredient> Ingredients { get; set; }

        // Declare a public property 'Steps' of type List<RecipeStep> to store the steps of the recipe
        public List<RecipeStep> Steps { get; set; }
        private string recipeName;

        public Recipe(string recipeName)
        {
            this.recipeName = recipeName;
        }
        // Declare a public property 'Name' of type string to store the name of the recipe
        public string Name { get; set; }

        public double Scale { get; set; } = 1.0;
        public int Calories { get; internal set; }

        internal int CalculateTotalCalories()
        {
            int totalCalories = 0;

            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            return totalCalories;
        }


        //public static class RecipeStorage
        //{
        //    public static List<Recipe> Recipes { get; } = new List<Recipe>();
        //}
        //public object Steps { get; internal set; }
        //public object Ingredients { get; internal set; }
    }
}