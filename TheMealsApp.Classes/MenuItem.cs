using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheMealsApp.Classes
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

    }
}
