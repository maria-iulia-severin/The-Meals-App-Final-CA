using System.Data.Entity;
using TheMealsApp.Classes;

namespace TheMealsApp.DataModel
{
    public class MealsContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Beverage> Beverages{get; set;}
        public DbSet<BeverageOrderDetails> BeverageOrders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodOrderDetails> FoodOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
