using System.Collections;
using System.Collections.Generic;

namespace TheMealsApp.Classes
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public MenuType MenuType { get; set; }

        public ICollection<MenuItem> Items;
    }
}
