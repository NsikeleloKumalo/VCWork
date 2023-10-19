using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_TEST
{
    class Program
    {
        static Recipe recipe = new Recipe();
        static void Main(string[] args)
        {
           

            while (true)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display the current recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Reset the quantities");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipe();
                        break;
                    case 2:
                        recipe.DisplayRecipe(recipe);
                        break;
                    case 3:
                        recipe.ScaleRecipe();
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
                }


    }
}
