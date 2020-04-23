using System.Data.Entity;
using TheMealsApp.Classes;
using TheMealsApp.DataModel.Migrations;

namespace TheMealsApp.DataModel
{
    public class MealsContext : DbContext
    {
        public MealsContext() : base("MealsConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MealsContext, Configuration>());
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Beverage> Beverages{get; set;}
        public DbSet<BeverageOrderDetails> BeverageOrders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodOrderDetails> FoodOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
