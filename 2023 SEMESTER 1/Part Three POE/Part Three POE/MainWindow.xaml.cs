using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Part_Three_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    internal static class RecipeStorage
    {
        public static List<Recipe> Recipes { get; } = new List<Recipe>();
    }


    public partial class MainWindow : Window
    {
        //global declarations
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<RecipeStep> steps = new List<RecipeStep>();
        public double scalingFactor = 1.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_addRecipe.Visibility = Visibility.Collapsed;
                tt_displayRecipe.Visibility = Visibility.Collapsed;
                tt_chooseRecipe.Visibility = Visibility.Collapsed;
                tt_scaleRecipe.Visibility = Visibility.Collapsed;
                tt_resetQuantities.Visibility = Visibility.Collapsed;
                tt_clearRecipe.Visibility = Visibility.Collapsed;
                tt_addIngredients.Visibility = Visibility.Collapsed;
                tt_filterRecipe.Visibility = Visibility.Collapsed;
                //tt_recipePieChart.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_addRecipe.Visibility = Visibility.Visible;
                tt_displayRecipe.Visibility = Visibility.Visible;
                tt_chooseRecipe.Visibility = Visibility.Visible;
                tt_scaleRecipe.Visibility = Visibility.Visible;
                tt_resetQuantities.Visibility = Visibility.Visible;
                tt_clearRecipe.Visibility = Visibility.Visible;
                tt_addIngredients.Visibility = Visibility.Visible;
                tt_filterRecipe.Visibility = Visibility.Visible;
                //tt_recipePieChart.Visibility = Visibility.Visible;
            }
        
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            //home 
            Home wah = new Home();
            wah.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            //Scale
            Scale_Recipe wah = new Scale_Recipe();
            wah.Show();
            this.Close();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            //Reset
           Reset_Quantities wah = new Reset_Quantities();
            wah.Show();
            this.Close();
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            // Get the selected recipe from the RecipeStorage.Recipes list
            Recipe selectedRecipe = GetSelectedRecipe();

            // Create a new instance of the Display_Recipes window and pass the selected recipe
            Display_Recipes displayRecipesWindow = new Display_Recipes(selectedRecipe);

            // Show the Display_Recipes window
            displayRecipesWindow.Show();

            // Close the current window
            this.Close();
        }

        private Recipe GetSelectedRecipe()
        {// Add your logic here to get the selected recipe from the RecipeStorage.Recipes list
         // For example, you can use an index or any other method to identify the selected recipe.
         // Return the selected recipe or null if no recipe is selected.
         // For demonstration purposes, I'm assuming the first recipe in the list is selected.
            if (RecipeStorage.Recipes.Count > 0)
            {
                return RecipeStorage.Recipes[0];
            }
            else
            {
                return null;
            }
        }


        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {

            //Add Recipes
            Add_Recipe wah = new Add_Recipe();
            wah.Show();
            this.Close();
        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {
            //choose a recipe 
            Choose_a_Recipe wah = new Choose_a_Recipe();
            wah.Show(); 
            this.Close();

        }

        //private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //clear a recipe 
        //}

        private void ListViewItem_Selected_6(object sender, RoutedEventArgs e)
        {
            //clear a recipe 
            Clear_Recipe wah = new Clear_Recipe();
            wah.Show();
            this.Close();
        }

        private void ListViewItem_Selected_7(object sender, RoutedEventArgs e)
        {
            //add ingredients
            Add_Ingredients wah = new Add_Ingredients();
            wah.Show();
            this.Close();
        }

        private void ListViewItem_Selected_8(object sender, RoutedEventArgs e)
        {
            //filter recipes 
            Filter_Recipe wah = new Filter_Recipe();
            wah.Show();
            this.Close();   
        }
    }
}
