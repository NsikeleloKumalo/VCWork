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
    /// Interaction logic for Scale_Recipe.xaml
    /// </summary>
    public partial class Scale_Recipe : Window
    {
        public Scale_Recipe()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    // go back to dashboard
        //    MainWindow wah = new MainWindow();
        //    wah.Show();
        //    this.Close();
        //}

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = recipeNameTextBox.Text;

            Recipe recipe = RecipeStorage.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                scaledRecipePanel.Children.Clear();

                TextBlock recipeNotFoundTextBlock = new TextBlock
                {
                    Text = "Recipe not found."
                };
                scaledRecipePanel.Children.Add(recipeNotFoundTextBlock);
                return;
            }

            double scalingFactor;
            if (!double.TryParse(scalingFactorTextBox.Text, out scalingFactor))
            {
                scaledRecipePanel.Children.Clear();

                TextBlock invalidScalingFactorTextBlock = new TextBlock
                {
                    Text = "Invalid scaling factor. Recipe scaling not applied.",
                    Foreground = Brushes.Red
                };
                scaledRecipePanel.Children.Add(invalidScalingFactorTextBlock);
                return;
            }

            scaledRecipePanel.Children.Clear();

            switch (scalingFactor)
            {
                case 0.5:
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.Quantity = ingredient.OriginalQuantity * 0.5;

                        TextBlock ingredientTextBlock = new TextBlock
                        {
                            Text = $"- {ingredient.Name}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}"
                        };
                        scaledRecipePanel.Children.Add(ingredientTextBlock);
                    }
                    break;
                case 2:
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.Quantity = ingredient.OriginalQuantity * 2;

                        TextBlock ingredientTextBlock = new TextBlock
                        {
                            Text = $"- {ingredient.Name}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}"
                        };
                        scaledRecipePanel.Children.Add(ingredientTextBlock);
                    }
                    break;
                case 3:
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        ingredient.Quantity = ingredient.OriginalQuantity * 3;

                        TextBlock ingredientTextBlock = new TextBlock
                        {
                            Text = $"- {ingredient.Name}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}"
                        };
                        scaledRecipePanel.Children.Add(ingredientTextBlock);
                    }
                    break;
                default:
                    TextBlock invalidScalingFactorTextBlock = new TextBlock
                    {
                        Text = "Invalid scaling factor. Recipe scaling not applied.",
                        Foreground = Brushes.Red
                    };
                    scaledRecipePanel.Children.Add(invalidScalingFactorTextBlock);
                    return;
            }

            TextBlock recipeScaledTextBlock = new TextBlock
            {
                Text = $"Recipe '{recipe.Name}' scaled successfully."
            };
            scaledRecipePanel.Children.Insert(0, recipeScaledTextBlock);
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
