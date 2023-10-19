using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2test
{
    // Delegate for notifying when a recipe exceeds 300 calories
    delegate void RecipeCaloriesExceededHandler(string recipeName, int totalCalories);
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        // Event to notify when a recipe exceeds 300 calories
        static event RecipeCaloriesExceededHandler RecipeCaloriesExceeded;
        static void Main(string[] args)
            {
           RecipeCaloriesExceeded += OnRecipeCaloriesExceeded;

            // Display a menu and prompt the user for a command until the user chooses to exit
            Console.Title = "BLESSING'S RECIPE APP!";
                Recipe recipe = new Recipe();
                //recipe.SetRecipeSize(); // prompt the user for recipe size
                //prompt the user to add a recipe or to exit the program
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WELCOME! TO BLESSING'S RECIPE APP!");
                Console.WriteLine("Would you like to add a recipe or exit the program?");
                Console.WriteLine("1. Add recipe");
                Console.WriteLine("2.Exit");
                //change text colour 
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    int command = int.Parse(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("Great! Let's get started!");
                        recipe.AddRecipe();
                        break;

                        case 2:
                            Console.WriteLine("Exiting the program...");
                            return;

                        default:
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            return;
                    }
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("\nEnter a command:");
                        Console.WriteLine("1. Add ingredients and/or steps");
                        Console.WriteLine("2. Display recipe");
                        Console.WriteLine("3. Scale recipe");
                        Console.WriteLine("4. Reset quantities");
                        Console.WriteLine("5. Clear recipe");
                        Console.WriteLine("6. Exit");

                        //added a try catch so that if the user makes a mistake it is easily solved and the prompt would reappear  
                        try
                        {
                            int choice;
                            while (true)
                            {
                                Console.Write("Please enter your choice: ");
                                if (int.TryParse(Console.ReadLine(), out choice))
                                {
                                    break;
                                }
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }

                            switch (choice)
                            {
                                // Prompt the user for information about the new ingredient/step and add it to the recipe
                                case 1:
                                    recipe.AddRecipe();
                                   // Call the AddStep method of the Recipe object, passing the user input as the step description
                                                     // Console.WriteLine("Step has been added successfully.");
                                                     // Prompt the user for a description of the new step and add it to the recipe
                                                     //Console.Write("Enter step description: ");
                                                     //string description = Console.ReadLine();

                                    // recipe.AddStep(description);// Call the AddStep method of the Recipe object, passing the user input as the step description
                                    //Console.WriteLine("Ingredients and / or steps have been added successfully.");
                                    //recipe.SetRecipeSize(); // prompt the user for recipe size
                                    break;

                                case 2:
                                    //prints the current recipe to the console using the DisplayRecipe method.
                                    recipe.DisplayRecipe();
                                    break;

                                case 3:
                                    recipe.ScaleRecipe();
                                    Console.WriteLine("Recipe has been scaled successfully.");
                                    break;

                                case 4:
                                    //divides the quantities of all ingredients in the recipe by 2 using the ResetQuantities method.
                                    recipe.ResetQuantities();
                                    Console.WriteLine("Quantities have been reset successfully.");
                                    break;

                                case 5:
                                    //removes all ingredients and steps from the recipe using the ClearRecipe method.
                                    recipe.ClearRecipe();
                                    Console.WriteLine("Recipe has been cleared successfully.");
                                    break;

                                case 6:
                                    //exits the program.
                                    Console.WriteLine("Exiting the program...");
                                    return;

                                default:
                                    //default
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                    break;
                            }
                        }
                        catch (FormatException)//close try
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }//close cathch
                    }

                }
                catch (FormatException)//close try
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }//close catch 
                Console.ReadLine();
                //end of code
            }

        private static void OnRecipeCaloriesExceeded(string recipeName, int totalCalories)
        {
            Console.WriteLine($"Warning: The recipe '{recipeName}' has {totalCalories} calories, which exceeds 300.");
        }
    }
    }

    