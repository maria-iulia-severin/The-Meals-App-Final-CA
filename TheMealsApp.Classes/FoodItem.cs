using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes
{
    class FoodItem : MenuItem
    {
        public string Recipe { get; set; }
        public FoodType FoodType { get; set; }
    }
}
