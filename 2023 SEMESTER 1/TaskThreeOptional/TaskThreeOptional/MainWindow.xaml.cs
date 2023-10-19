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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace TaskThreeOptional
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {//global declarations
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<Steps> steps = new List<Steps>();    
        public double scalingFactor = 1.0;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void AddIngredients()
        {
            //create a new StackPanel
            StackPanel ingredPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0,0,0,10)
            };
            //set the new textboxes that will gett generated 
            TextBox nameTextBox = new TextBox() { Width = 150, Margin = new Thickness(0,0,0,10)};
            TextBox quantityTextBox = new TextBox() { Width = 150, Margin = new Thickness(0, 0, 0, 10) };
            TextBox unitTextBox = new TextBox() { Width = 150, Margin = new Thickness(0, 0, 0, 10) };
            
            // .add method 
           ingredPanel.Children.Add(new TextBlock(){ Text = "Name" , VerticalAlignment = VerticalAlignment.Center});
            ingredPanel.Children.Add(nameTextBox);

            ingredPanel.Children.Add(new TextBlock() { Text = "Quantity", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(quantityTextBox);

            ingredPanel.Children.Add(new TextBlock() { Text = "Units", VerticalAlignment = VerticalAlignment.Center });
            ingredPanel.Children.Add(unitTextBox);

            ingredients.Add(new Ingredient(nameTextBox,quantityTextBox, unitTextBox));
            recipeDetails.Children.Add(ingredPanel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ingredCount;
            if (int.TryParse(IngredientCountTb.Text, out ingredCount))
            {
                for (int i = 0; i < ingredCount; i++)
                {
                    AddIngredients();
                }

                //reset add ingredients box 
                IngredientCountTb.Text = string.Empty;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //add Steps button
            int StepCount;
            if (int.TryParse(stepCountTb.Text, out StepCount))
            {
                for (int i = 0; i < StepCount; i++)
                {
                   //add step count method an pull
                   AddStep();
                }

                //reset add ingredients box 
                stepCountTb.Text = string.Empty;
            }

        }

        public void AddStep()
        {
            //create new Stackpanel 
            //create a new StackPanel
            StackPanel stepPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 10)
            };
            //set the new textboxes that will gett generated 
            TextBox stepTextBox = new TextBox() { Width = 150, Margin = new Thickness(0, 0, 0, 10) };

            // .add method 
            stepPanel.Children.Add(new TextBlock() { Text = "Step:", VerticalAlignment = VerticalAlignment.Center });
            stepPanel.Children.Add(stepTextBox);

            //add onto the list 
            steps.Add(new Steps(stepTextBox));
            recipeDetails.Children.Add(stepPanel);

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //scale button
            scalingFactor = 1.0;
            //calc the scaled amount 
            if (double.TryParse(scaleTb.Text, out double factor))
            {
                scalingFactor = factor;
                scaleTb.Text = string.Empty;


            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //reset button 
            recipeRichTextBox.Document.Blocks.Clear();
            recipeRichTextBox.AppendText("Ingredients:");

            //ingredient list first
            foreach (Ingredient ingredient in ingredients)
            {
                string name = ingredient.NameTextBox.Text;
                string quantity = ingredient.QuantityTextBox.Text;
                string unit = ingredient.UnitTextBox.Text;


                //CREATE A NEW STRING
                string ingredientText = $"\nName: {name} Quantity: {quantity} Units: {unit}";
                recipeRichTextBox.AppendText(ingredientText);
                recipeRichTextBox.AppendText(Environment.NewLine);
            }
            //loop ends

            //handle the steps info
            string heading = "Steps\n";
            recipeRichTextBox.AppendText(heading);
            foreach (Steps step in steps)
            {
                string stepText = step.StepsTextBox.Text;
                recipeRichTextBox.AppendText(stepText);
                recipeRichTextBox.AppendText(Environment.NewLine);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //clear btn
            //clear the 2 list<t>
                 ingredients.Clear();
            steps.Clear();

            //reset the scale
            scalingFactor = 1.0;
           //panesl
           recipeDetails.Children.Clear();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Display Recipe 
            //clear the richtextbox first 
            recipeRichTextBox.AppendText("Ingredients:" );
            recipeRichTextBox.Document.Blocks.Clear();

            //ingredient list first
            foreach ( Ingredient ingredient in ingredients)
            {
                string name = ingredient.NameTextBox.Text;
                string quantity = ingredient.QuantityTextBox.Text;
                string unit = ingredient.UnitTextBox.Text;

                //try to bring in scaling
                //scale the quantity
                double scaledQuantity = double.Parse(quantity) * scalingFactor;
                //CREATE A NEW STRING 
                string ingredientText = $"\n{name} : Quantity: {scaledQuantity} Units:{unit}";
                recipeRichTextBox.AppendText(ingredientText);
                recipeRichTextBox.AppendText(Environment.NewLine);
            }//after the loop

            //handle the steps info
            string heading = "Steps \n";
            recipeRichTextBox.AppendText(heading);
            foreach (Steps step in steps)
            {
                //CREATE A NEW STRING 
                string stepText = step.StepsTextBox.Text;
                recipeRichTextBox.AppendText(stepText);
                recipeRichTextBox.AppendText(Environment.NewLine);
            }
        }
    }
}
