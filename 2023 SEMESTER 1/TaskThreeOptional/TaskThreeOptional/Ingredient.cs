using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskThreeOptional
{
    public class Ingredient
    {
        public Ingredient(TextBox nameTextBox, TextBox quantityTextBox, TextBox unitTextBox)
        {
            NameTextBox = nameTextBox;
            QuantityTextBox = quantityTextBox;
            UnitTextBox = unitTextBox;
        }

        //props
        public TextBox NameTextBox { get; set; }
        public TextBox QuantityTextBox { get; set; }

        public TextBox UnitTextBox { get; set; }

    }
}
