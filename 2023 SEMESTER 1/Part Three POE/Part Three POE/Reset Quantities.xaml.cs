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
    /// Interaction logic for Reset_Quantities.xaml
    /// </summary>
    public partial class Reset_Quantities : Window
    {
        public Reset_Quantities()
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

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{

        //}

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            // go back to dashboard
            MainWindow wah = new MainWindow();
            wah.Show();
            this.Close();
        }

        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = recipeNameTextBox.Text;

            Recipe recipe = RecipeStorage.Recipes.FirstOrDefault(r => r.Name == recipeName);

            if (recipe != null)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity = 0;
                }

                resultPanel.Children.Clear();
                resultPanel.Children.Add(new TextBlock { Text = "Quantities reset successfully." });
            }
            else
            {
                resultPanel.Children.Clear();
                resultPanel.Children.Add(new TextBlock { Text = "Recipe not found." });
            }
        }

    }
}
