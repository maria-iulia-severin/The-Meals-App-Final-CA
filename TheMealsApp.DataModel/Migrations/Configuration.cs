namespace TheMealsApp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using TheMealsApp.Classes;

    internal sealed class Configuration : DbMigrationsConfiguration<TheMealsApp.DataModel.MealsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheMealsApp.DataModel.MealsContext context)
        {
            using (var reader = new StreamReader(@"C:\Users\iulia\source\repos\rad302finalca2020-S00201400\TheMealsApp.DataModel\App_Data\Menu.csv.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(',');
                    context.Menus.AddOrUpdate(x => x.Id,
                        new Menu()
                        {
                            Name = line[0],
                            Moniker = line[1],
                            MenuType = (MenuType)Enum.ToObject(typeof(MenuType), int.Parse(line[2]))
                        });
                }
            }

            using (var reader = new StreamReader(@"C:\Users\iulia\source\repos\rad302finalca2020-S00201400\TheMealsApp.DataModel\App_Data\MenuItem.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(',');
                    if (line[7] == "food")
                    {
                        context.MenuItems.AddOrUpdate(f => f.Id,
                        new FoodItem()
                        {
                            MenuId = int.Parse(line[0]),
                            Name = line[1],
                            Price = float.Parse(line[2]),
                            Recipe = line[5],
                            FoodType = (FoodType)Enum.ToObject(typeof(FoodType), int.Parse(line[6]))

                        });
                    }
                    else
                    {

                        context.MenuItems.AddOrUpdate(d => d.Id,
                            new DrinkItem()
                            {
                                MenuId = int.Parse(line[0]),
                                Name = line[1],
                                Price = (float)Convert.ToDouble(line[2]),
                                //in case of update - comment next line
                                AlcoholFree = bool.Parse(line[3]),
                                DrinkType = (BeverageType)Enum.ToObject(typeof(BeverageType), int.Parse(line[4]))
                            });

                    }


                }
            }

        }

    }
}
