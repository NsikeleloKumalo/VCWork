using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_part_2_test
{
    internal class Program
    {
        private static List<Recipe> recipes = new List<Recipe>();
        private delegate void RecipeExceedsCaloriesHandler(string recipeName);

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Go to main menu");
                Console.WriteLine("2. Exit");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        MainMenu();
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }

        }
    }
}
