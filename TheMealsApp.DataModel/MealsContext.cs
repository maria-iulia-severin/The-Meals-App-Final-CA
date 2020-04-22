using System.Data.Entity;
using TheMealsApp.Classes;

namespace TheMealsApp.DataModel
{
    public class MealsContext:DbContext
    {
        public DbSet <Menu> Menus { get; set; }
    }
}
