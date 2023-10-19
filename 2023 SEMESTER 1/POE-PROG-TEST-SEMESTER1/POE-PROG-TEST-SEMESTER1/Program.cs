using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PROG_TEST_SEMESTER1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display a menu and prompt the user for a command until the user chooses to exit

            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("\nEnter a command:");
                Console.WriteLine("1. Add ingredient");
                Console.WriteLine("2. Add step");
                Console.WriteLine("3. Display recipe");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Reset quantities");
                Console.WriteLine("6. Clear recipe");
                Console.WriteLine("7. Exit");

                try {
                    int command = int.Parse(Console.ReadLine());

                    switch (command)
                    {
                        // Prompt the user for information about the new ingredient and add it to the recipe
                        case 1:
                            Console.Write("Enter ingredient name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter quantity: ");
                            double quantity = double.Parse(Console.ReadLine());

                            Console.Write("Enter unit of measurement: ");
                            string unit = Console.ReadLine();

                            recipe.AddIngredient(name, quantity, unit);
                            break;

                        case 2:
                            // Prompt the user for a description of the new step and add it to the recipe
                            Console.Write("Enter step description: ");
                            string description = Console.ReadLine();

                            recipe.AddStep(description);// Call the AddStep method of the Recipe object, passing the user input as the step description
                            break;

                        case 3:
                            //prints the current recipe to the console using the DisplayRecipe method.
                            recipe.DisplayRecipe();
                            break;

                        case 4:
                            //prompts the user to enter a scaling factor (0.5, 2, or 3), and multiplies the quantities of all ingredients in the recipe by that factor using the ScaleRecipe method.
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                            double factor = double.Parse(Console.ReadLine());

                            recipe.ScaleRecipe(factor);
                            break;

                        case 5:
                            //divides the quantities of all ingredients in the recipe by 2 using the ResetQuantities method.
                            recipe.ResetQuantities();
                            break;

                        case 6:
                            //removes all ingredients and steps from the recipe using the ClearRecipe method.
                            recipe.ClearRecipe();
                            break;

                        case 7:
                            //exits the program.
                            return;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            }
       
    }
    }
