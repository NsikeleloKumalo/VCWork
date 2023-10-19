using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Part_Three_POE
{
    internal class Ingredient
    {
        // Properties of an ingredient
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public int OriginalQuantity { get; set; } // Original quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement for the ingredient
        public int Calories { get; set; } // Calorie content of the ingredient
        public string FoodGroup { get; set; } // Food group that the ingredient belongs to

        //public Ingredient(string name, double quantity, TextBox nameTextBox, TextBox quantityTextBox, TextBox unitTextBox)
        //{
        //    NameTextBox = nameTextBox;
        //    QuantityTextBox = quantityTextBox;
        //    UnitTextBox = unitTextBox;
        //}

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }


        //props
        public TextBox NameTextBox { get; set; }
        public TextBox QuantityTextBox { get; set; }

        public TextBox UnitTextBox { get; set; }
       
    }
}
