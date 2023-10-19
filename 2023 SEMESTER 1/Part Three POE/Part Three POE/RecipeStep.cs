using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Part_Three_POE
{
    internal class RecipeStep
    {
        public RecipeStep(TextBox stepsTextBox)
        {
            StepsTextBox = stepsTextBox;
        }

        public RecipeStep(string description)
        {
            Description = description;
        }

        public TextBox StepsTextBox { get; set; }
        public string Description { get; set; }
    }
}
