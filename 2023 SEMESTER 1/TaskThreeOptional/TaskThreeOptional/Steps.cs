using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskThreeOptional
{
   public class Steps
    {
        public Steps(TextBox stepsTextBox)
        {
            StepsTextBox = stepsTextBox;
        }

        public TextBox StepsTextBox { get; set; }
    }
}
