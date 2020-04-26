using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes
{
    public class DrinkItem : MenuItem
    {
        public bool AlcoholFree { get; set; }
        public BeverageType DrinkType { get; set; }
    }
}
