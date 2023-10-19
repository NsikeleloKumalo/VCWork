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
    /// Interaction logic for Choose_a_Recipe.xaml
    /// </summary>
    public partial class Choose_a_Recipe : Window
    {
        private Recipe selectedRecipe;

        public Choose_a_Recipe()
        {
            InitializeComponent();

            // Initialize selectedRecipe with a recipe instance or set it to null
            selectedRecipe = null;
            DisplayRecipe();
        }

        private void DisplayRecipe()
        {
            if (RecipeStorage.Recipes.Count == 0)
            {
                // No recipes found in RecipeStorage
                selectedRecipe = null;
            }
            else
            {
                // Retrieve a recipe from the RecipeStorage (you can modify the logic as per your requirements)
                selectedRecipe = (Recipe)RecipeStorage.Recipes[0];
            }

            // Update the displayed recipe
            if (selectedRecipe == null)
            {
                displayedRecipePanel.Children.Clear();

                // Recipe not found
                TextBlock recipeNotFoundTextBlock = new TextBlock
                {
                    Text = "Recipe not found.",
                    Foreground = Brushes.Red
                };
                displayedRecipePanel.Children.Add(recipeNotFoundTextBlock);
            }
            else
            {
                displayedRecipePanel.Children.Clear();

                TextBlock recipeNameTextBlock = new TextBlock
                {
                    Text = $"Recipe: {selectedRecipe.Name}",
                    Foreground = Brushes.Cyan,
                    FontWeight = FontWeights.Bold
                };
                displayedRecipePanel.Children.Add(recipeNameTextBlock);

                // Display the ingredients
                TextBlock ingredientsTitleTextBlock = new TextBlock
                {
                    Text = "Ingredients:",
                    Foreground = Brushes.Cyan,
                    FontWeight = FontWeights.Bold
                };
                displayedRecipePanel.Children.Add(ingredientsTitleTextBlock);

                foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                {
                    TextBlock ingredientTextBlock = new TextBlock
                    {
                        Text = $"- {ingredient.Name}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}"
                    };
                    displayedRecipePanel.Children.Add(ingredientTextBlock);
                }

                // Display the steps
                TextBlock stepsTitleTextBlock = new TextBlock
                {
                    Text = "Steps:",
                    Foreground = Brushes.Cyan,
                    FontWeight = FontWeights.Bold
                };
                displayedRecipePanel.Children.Add(stepsTitleTextBlock);

                foreach (RecipeStep step in selectedRecipe.Steps)
                {
                    TextBlock stepTextBlock = new TextBlock
                    {
                        Text = $"- {step.Description}"
                    };
                    displayedRecipePanel.Children.Add(stepTextBlock);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Call DisplayRecipe() method to update the displayed recipe
            DisplayRecipe();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {

            // Go back to dashboard
            MainWindow wah = new MainWindow();
            wah.Show();
            this.Close();
        }
    }
}