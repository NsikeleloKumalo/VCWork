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
    /// Interaction logic for Clear_Recipe.xaml
    /// </summary>
    public partial class Clear_Recipe : Window
    {
        public Clear_Recipe()
        {
            InitializeComponent();
        }

        private void ClearRecipe_Click(object sender, RoutedEventArgs e)
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

            resultPanel.Children.Clear();

            TextBlock confirmationTextBlock = new TextBlock
            {
                Text = $"Are you sure you want to clear the recipe '{recipeName}'? (YES/NO)"
            };
            resultPanel.Children.Add(confirmationTextBlock);

            TextBox confirmationTextBox = new TextBox
            {
                Width = 100,
                Margin = new Thickness(0, 5, 0, 0)
            };
            resultPanel.Children.Add(confirmationTextBox);

            Button confirmButton = new Button
            {
                Content = "Confirm",
                Margin = new Thickness(0, 5, 0, 0)
            };
            confirmButton.Click += (confirmSender, confirmArgs) =>
            {
                string confirmation = confirmationTextBox.Text.ToUpper().Trim();

                resultPanel.Children.Clear();

                switch (confirmation)
                {
                    case "YES":
                        RecipeStorage.Recipes.Remove(recipe);

                        TextBlock successTextBlock = new TextBlock
                        {
                            Text = $"Recipe '{recipeName}' cleared successfully.",
                            Foreground = Brushes.DarkCyan
                        };
                        resultPanel.Children.Add(successTextBlock);
                        break;
                    case "NO":
                        TextBlock canceledTextBlock = new TextBlock
                        {
                            Text = "Clear operation canceled.",
                            Foreground = Brushes.Magenta
                        };
                        resultPanel.Children.Add(canceledTextBlock);
                        break;
                    default:
                        TextBlock invalidInputTextBlock = new TextBlock
                        {
                            Text = "Invalid input. Clear operation canceled.",
                            Foreground = Brushes.Red
                        };
                        resultPanel.Children.Add(invalidInputTextBlock);
                        break;
                }
            };
            resultPanel.Children.Add(confirmButton);
        }

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Go back to dashboard
            MainWindow wah = new MainWindow();
            wah.Show();
            this.Close();
        }
    }
}
