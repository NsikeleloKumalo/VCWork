using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implement a menu-driven console application that allows the user to interact with the RecipeManager.
        List<RecipeApplication> recipes = new List<RecipeApplication>();

            while (true)
            {
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Clear all data");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RecipeApplication recipe = new RecipeApplication();
                        Console.Write("Enter recipe name: ");
                        recipe.Name = Console.ReadLine();

                        Console.Write("Enter number of ingredients: ");
                        int ingredientCount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < ingredientCount; i++)
                        {
                            Console.Write($"Enter name of ingredient {i + 1}: ");
                            string name = Console.ReadLine();

                            Console.Write($"Enter quantity of ingredient {i + 1}: ");
                            double quantity = double.Parse(Console.ReadLine());

                            Console.Write($"Enter unit of ingredient {i + 1}: ");
                            string unit = Console.ReadLine();
                        }
                        break;
                }
            }
        }
    }
}

