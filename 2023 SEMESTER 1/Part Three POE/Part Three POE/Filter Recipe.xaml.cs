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
    /// Interaction logic for Filter_Recipe.xaml
    /// </summary>
    public partial class Filter_Recipe : Window
    {
        private static List<Recipe> recipeStorage = new List<Recipe>();

        internal Filter_Recipe()
        {
            InitializeComponent();
         
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientTextBox.Text;
            string foodGroup = FoodGroupComboBox.SelectedItem?.ToString();
            int maxCalories;

            if (!int.TryParse(MaxCaloriesTextBox.Text, out maxCalories))
            {
                MessageBox.Show("Invalid value for maximum calories. Please enter a valid integer.");
                return;
            }

            List<Recipe> filteredRecipes = FilterRecipes(ingredientName, foodGroup, maxCalories);
            DisplayFilteredRecipes(filteredRecipes);
        }

        private List<Recipe> FilterRecipes(string ingredientName, string foodGroup, int maxCalories)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();

            foreach (Recipe recipe in recipeStorage)
            {
                bool ingredientMatch = string.IsNullOrEmpty(ingredientName) || recipe.Ingredients.Any(i => i.Name.ToLower().Contains(ingredientName.ToLower()));
                bool foodGroupMatch = string.IsNullOrEmpty(foodGroup) || recipe.Ingredients.Any(i => i.FoodGroup.ToLower() == foodGroup.ToLower());
                bool caloriesMatch = recipe.Calories <= maxCalories;

                if (ingredientMatch && foodGroupMatch && caloriesMatch)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        private void DisplayFilteredRecipes(List<Recipe> recipes)
        {
            RecipeListBox.ItemsSource = recipes;
            int recipeCount = recipes.Count;
            ResultTextBlock.Text = $"Found {recipeCount} recipe(s) matching the filter.";
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            IngredientTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1;
            MaxCaloriesTextBox.Clear();
            RecipeListBox.ItemsSource = null;
            ResultTextBlock.Text = string.Empty;
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
