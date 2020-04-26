namespace TheMealsApp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        AlcoholFree = c.Boolean(),
                        DrinkType = c.Int(),
                        Recipe = c.String(),
                        FoodType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Moniker = c.String(),
                        MenuType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus");
            DropIndex("dbo.MenuItems", new[] { "MenuId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuItems");
        }
    }
}
