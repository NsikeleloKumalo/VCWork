using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTwo
{
      class Program
    {
        static List<Recipe> recipes;
        static void Main(string[] args)
        {
            recipes = new List<Recipe>();//obj
            bool exit = false; // loop control variable 

            while(!exit)
            {
                Console.WriteLine("1. Enter the recipe details");
                Console.WriteLine("2. Display the list of recipes");
                Console.WriteLine("3. Choose the recipe to diplay");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter your choice");
                string choice = Console.ReadLine();

                //if else or switch

                switch (choice)
                {
                    case "1": EnterDetails(); break;
                    case "2": DisplayRec();  break;
                    case "3": ChooseRec(); break;
                    case "4": break;
                    default: Console.WriteLine(); break;
                }
            }
        }

        private static void ChooseRec()
        {
            Console.WriteLine("Choose a rec to display");
            DisplayRec(); //pulls method with all the details
            Console.WriteLine("Enter the recipe name >>>");
            string recName = Console.ReadLine();

            Recipe rec = recipes.FirstOrDefault(r => r.Name == recName);

            if (rec != null)
            {
                DisplayRecipe(rec); //pull the method
            }
        }

        private static void DisplayRec()
        {
            Console.WriteLine("List of Recipes");
            List<string> recNames = recipes.Select(r => r.Name).OrderBy(name => name).ToList();

            //PRINTING OUT WHATS IN THE LISTS
            foreach (var item in recNames)
            {
                Console.WriteLine(item);
            }
        
        }

        static void DisplayRecipe (Recipe recipe)
        {
            Console.WriteLine("Recipe deatails: ");
            Console.WriteLine($"Name:  {recipe.Name}");
            Console.WriteLine("Ingredients: ");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity}" +
                    $"{ ingredient.Unit}" +
                    $"{ingredient.Name}" +
                    $"{ingredient.Calories}" +
                    $"{ingredient.FoodGroup}"
                    );
            }
            Console.WriteLine("Steps");
            foreach (var step in recipe.Steps)
            {
                Console.WriteLine(step.Description);
            }
            int totalCalories = recipe.Ingredients.Sum(Ingredient => Ingredient.Calories);
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: The recipe has exceeded 300 calories");
            }
        }

        private static void EnterDetails()
        {
            //object rec class
            Recipe rec = new Recipe();
            Console.WriteLine("Enter recipe name>>>");
            rec.Name = Console.ReadLine();


            Console.WriteLine("Enter the number of Ingredients>>>");
            int numInreds = int.Parse(Console.ReadLine());

            //what do you need for eas=ch ingredient??
            //name; quantity/units/cals/foodgroup

            for (int i = 0; i < numInreds; i++)
            {
                Console.WriteLine($"Ingredient {i +1}");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Quantiy: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine("Unit: ");
                string unit = Console.ReadLine();
                Console.WriteLine("Calories: ");
                int calories = int.Parse(Console.ReadLine());
                Console.WriteLine("FoodGroup: ");
                string foodgroup = Console.ReadLine();

                rec.Ingredients.Add(new Ingredient
                {
                    Name = name,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodgroup
                }); 
            }// for loop ends
            Console.WriteLine("Enter the number of step>>");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}");
                Console.WriteLine("Description");
                string description = Console.ReadLine();

                //now add it into the lists of steps
                rec.Steps.Add(new Step()
                    {
                    Description = description
                });
            }//loop ends
            recipes.Add(rec);
            Console.WriteLine("Recipe details captured successfully");
        }
    }
}
