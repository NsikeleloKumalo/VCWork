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
    /// Interaction logic for Add_Recipe.xaml
    /// </summary>
    public partial class Add_Recipe : Window
    {
        //private List<Recipe> recipeList = new List<Recipe>(); // Example data structure to store recipes

        public Add_Recipe()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Go back to dashboard
            MainWindow wah = new MainWindow();
            wah.Show();
            this.Close();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the entered recipe name from a TextBox control
            string recipeName = recipeNameTextBox.Text;

            // Create a new Recipe object with the provided name
            Recipe newRecipe = new Recipe(recipeName);

            // Retrieve the number of ingredients from a TextBox control
            int ingredientCount = int.Parse(ingredientCountTextBox.Text);

            // Loop through the ingredient count and gather ingredient information
            for (int i = 0; i < ingredientCount; i++)
            {
                // Retrieve the ingredient name and quantity from TextBox controls
                string name = ingredientNameTextBoxes[i].Text;
                double quantity = double.Parse(ingredientQuantityTextBoxes[i].Text);

                // Retrieve the selected unit from a ComboBox control
                string unit = (unitComboBoxes[i].SelectedItem as ComboBoxItem)?.Tag.ToString();

                // Retrieve the calories from a TextBox control
                int calories = int.Parse(caloriesTextBoxes[i].Text);

                // Retrieve the selected food group from a ComboBox control
                string foodGroup = (foodGroupComboBoxes[i].SelectedItem as ComboBoxItem)?.Content.ToString();

                // Create a new Ingredient object with the gathered information and add it to the recipe
                Ingredient newIngredient = new Ingredient(name, quantity, unit, calories, foodGroup);
                newRecipe.Ingredients.Add(newIngredient);
            }

            // Retrieve the number of recipe steps from a TextBox control
            int stepCount = int.Parse(stepCountTextBox.Text);

            // Loop through the step count and gather step descriptions
            for (int i = 0; i < stepCount; i++)
            {
                // Retrieve the step description from a TextBox control
                string description = stepDescriptionTextBoxes[i].Text;

                // Create a new RecipeStep object with the provided description and add it to the recipe
                RecipeStep newStep = new RecipeStep(description);
                newRecipe.Steps.Add(newStep);
            }

            // Add the completed recipe to the RecipeStorage
            RecipeStorage.Recipes.Add(newRecipe);

            // Calculate the total calories of the recipe
            int totalCalories = 0;
            foreach (Ingredient ingredient in newRecipe.Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            // Display the total calories or use it as needed
            MessageBox.Show($"Recipe added successfully!\nTotal Calories: {totalCalories}");
        }


        // List to store dynamically created ingredient input controls
        private List<TextBox> ingredientNameTextBoxes = new List<TextBox>();
        private List<TextBox> ingredientQuantityTextBoxes = new List<TextBox>();
        private List<ComboBox> unitComboBoxes = new List<ComboBox>();
        private List<TextBox> caloriesTextBoxes = new List<TextBox>();
        private List<ComboBox> foodGroupComboBoxes = new List<ComboBox>();

        // List to store dynamically created step input controls
        private List<TextBox> stepDescriptionTextBoxes = new List<TextBox>();

        private void ingredientCountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ingredientCount;
            if (int.TryParse(ingredientCountTextBox.Text, out ingredientCount))
            {
                CreateIngredientInputControls(ingredientCount);
            }
        }

        private void stepCountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int stepCount;
            if (int.TryParse(stepCountTextBox.Text, out stepCount))
            {
                CreateStepInputControls(stepCount);
            }
        }

        private void CreateIngredientInputControls(int count)
        {
            // Clear existing controls
            ClearIngredientInputControls();

            for (int i = 0; i < count; i++)
            {
                // Create TextBox for ingredient name
                TextBox nameTextBox = new TextBox();
                ingredientNameTextBoxes.Add(nameTextBox);
                ingredientStackPanel.Children.Add(nameTextBox);

                // Create TextBox for ingredient quantity
                TextBox quantityTextBox = new TextBox();
                ingredientQuantityTextBoxes.Add(quantityTextBox);
                ingredientStackPanel.Children.Add(quantityTextBox);

                // Create ComboBox for unit selection
                ComboBox unitComboBox = new ComboBox();
                unitComboBoxes.Add(unitComboBox);
                ingredientStackPanel.Children.Add(unitComboBox);

                // Create TextBox for calories
                TextBox caloriesTextBox = new TextBox();
                caloriesTextBoxes.Add(caloriesTextBox);
                ingredientStackPanel.Children.Add(caloriesTextBox);

                // Create ComboBox for food group selection
                ComboBox foodGroupComboBox = new ComboBox();
                foodGroupComboBoxes.Add(foodGroupComboBox);
                ingredientStackPanel.Children.Add(foodGroupComboBox);
            }
        }

        private void CreateStepInputControls(int count)
        {
            // Clear existing controls
            ClearStepInputControls();

            for (int i = 0; i < count; i++)
            {
                // Create TextBox for step description
                TextBox descriptionTextBox = new TextBox();
                stepDescriptionTextBoxes.Add(descriptionTextBox);
                stepStackPanel.Children.Add(descriptionTextBox);
            }
        }

        private void ClearIngredientInputControls()
        {
            foreach (TextBox textBox in ingredientNameTextBoxes)
            {
                ingredientStackPanel.Children.Remove(textBox);
            }
            ingredientNameTextBoxes.Clear();

            foreach (TextBox textBox in ingredientQuantityTextBoxes)
            {
                ingredientStackPanel.Children.Remove(textBox);
            }
            ingredientQuantityTextBoxes.Clear();

            foreach (ComboBox comboBox in unitComboBoxes)
            {
                ingredientStackPanel.Children.Remove(comboBox);
            }
            unitComboBoxes.Clear();

            foreach (TextBox textBox in caloriesTextBoxes)
            {
                ingredientStackPanel.Children.Remove(textBox);
            }
            caloriesTextBoxes.Clear();

            foreach (ComboBox comboBox in foodGroupComboBoxes)
            {
                ingredientStackPanel.Children.Remove(comboBox);
            }
            foodGroupComboBoxes.Clear();
        }

        private void ClearStepInputControls()
        {
            foreach (TextBox textBox in stepDescriptionTextBoxes)
            {
                stepStackPanel.Children.Remove(textBox);
            }
            stepDescriptionTextBoxes.Clear();
        }

        
    }
}