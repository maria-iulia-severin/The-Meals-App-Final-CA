using System.Data.Entity;
using TheMealsApp.Classes;
using TheMealsApp.DataModel.Migrations;

namespace TheMealsApp.DataModel
{
    public class MealsContext : DbContext
    {
        //public MealsContext() : base("MealsConnectionString")
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<MealsContext, Configuration>());
        //}
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
