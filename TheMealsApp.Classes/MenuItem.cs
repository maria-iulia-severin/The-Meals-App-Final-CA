using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

    }
}
