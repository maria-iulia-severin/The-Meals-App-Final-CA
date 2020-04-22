using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes
{
    public class Food
    {
        public int Id { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Recipe { get; set; }
        public FoodType Type { get; set; }

    }
}
