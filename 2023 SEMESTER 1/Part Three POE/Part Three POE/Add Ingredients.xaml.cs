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
    /// Interaction logic for Add_Ingredients.xaml
    /// </summary>
    public partial class Add_Ingredients : Window
    {
        public Add_Ingredients()
        {
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Go back to dashboard
            MainWindow wah = new MainWindow();
            wah.Show();
            this.Close();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = recipeNameTextBox.Text;

            Recipe recipe = RecipeStorage.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                resultPanel.Children.Clear();

                TextBlock recipeNotFoundTextBlock = new TextBlock
                {
                    Text = "Recipe not found.",
                    Foreground = Brushes.Red
                };
                resultPanel.Children.Add(recipeNotFoundTextBlock);
                return;
            }

            // Get the entered ingredient details
            string ingredientName = ingredientNameTextBox.Text;
            double quantity = double.Parse(quantityTextBox.Text);
            string unit = ((ComboBoxItem)unitComboBox.SelectedItem)?.Content.ToString();
            int calories = int.Parse(caloriesTextBox.Text);
            string foodGroup = ((ComboBoxItem)foodGroupComboBox.SelectedItem)?.Content.ToString();

            // Perform the necessary logic based on the entered ingredient details
            Ingredient newIngredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);

            recipe.Ingredients.Add(newIngredient);

            // Update the UI with the result
            resultPanel.Children.Clear();

            TextBlock successTextBlock = new TextBlock
            {
                Text = $"Ingredient '{ingredientName}' added to recipe '{recipeName}' successfully."
            };
            resultPanel.Children.Add(successTextBlock);
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = recipeNameTextBox.Text;

            Recipe recipe = RecipeStorage.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                resultPanel.Children.Clear();

                TextBlock recipeNotFoundTextBlock = new TextBlock
                {
                    Text = "Recipe not found.",
                    Foreground = Brushes.Red
                };
                resultPanel.Children.Add(recipeNotFoundTextBlock);
                return;
            }

            // Get the entered step description
            string stepDescription = stepDescriptionTextBox.Text;

            // Perform the necessary logic based on the entered step description
            RecipeStep newStep = new RecipeStep(stepDescription);

            recipe.Steps.Add(newStep);

            // Update the UI with the result
            resultPanel.Children.Clear();

            TextBlock successTextBlock = new TextBlock
            {
                Text = $"Step '{stepDescription}' added to recipe '{recipeName}' successfully."
            };
            resultPanel.Children.Add(successTextBlock);
        }
    }
}
