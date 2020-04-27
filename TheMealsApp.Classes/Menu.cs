using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheMealsApp.Classes
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public MenuType MenuType { get; set; }

        public ICollection<MenuItem> Items { get; set; }
    }
}
