using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2test
{
        class Ingredient
        {
            //        public string Name;
            //        public double Quantity;
            //        public string Unit;
            public string Name { get; set; }
            public double Quantity { get; set; }
            public double OriginalQuantity { get; set; } // new property to store the original quantity
            public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                OriginalQuantity = quantity; // set the original quantity
                Unit = unit;
            }

            // public double OriginalQuantity { get; internal set; }
        }

    }

