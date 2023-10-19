using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Ingredient
    {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public double OriginalQuantity { get; set; }
            public double Calories { get; set; }
            public string FoodGroup { get; set; }

            public Ingredient(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                OriginalQuantity = quantity;
                Calories = 0.0;
                FoodGroup = null;
            }

            public void SetCalories(double calories)
            {
                Calories = calories;
            }

            public void SetFoodGroup(string foodGroup)
            {
                FoodGroup = foodGroup;
            }
        }
    }

