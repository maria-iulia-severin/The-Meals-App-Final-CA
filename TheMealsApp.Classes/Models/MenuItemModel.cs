using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealsApp.Classes.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public  string MenuName { get; set; }
        public string MenuMoniker { get; set; }
    }
}
