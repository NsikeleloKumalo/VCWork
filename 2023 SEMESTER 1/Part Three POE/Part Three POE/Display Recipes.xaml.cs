using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Part_Three_POE
{
    /// <summary>
    /// Interaction logic for Display_Recipes.xaml
    /// </summary>
    public partial class Display_Recipes : Window
    {
        private Recipe recipe;

        internal Display_Recipes(Recipe selectedRecipe)
        {
            InitializeComponent();
            recipe = selectedRecipe;
            DataContext = recipe;
        }

        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the result panel
            resultPanel.Children.Clear();

            // Set the console color to yellow for the recipe name
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Display the recipe name
            Console.WriteLine($"Recipe: {recipe.Name}");

            //// Reset the console color back to the default
            //Console.ResetColor();

            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
            }

            Console.WriteLine("Steps:");
            foreach (RecipeStep step in recipe.Steps)
            {
                // Set the console color to green for the steps
                Console.ForegroundColor = ConsoleColor.Green;

                // Display each recipe step
                Console.WriteLine($"- {step.Description}");

                // Reset the console color back to the default
                Console.ResetColor();
            }

            // Update the UI with the result
            TextBlock successTextBlock = new TextBlock
            {
                Text = "Recipe displayed successfully.",
                Foreground = Brushes.Green
            };
            resultPanel.Children.Add(successTextBlock);
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            // go back to dashboard
            MainWindow wah = new MainWindow();
            wah.Show();
            this.Close();
        }
    }
}
