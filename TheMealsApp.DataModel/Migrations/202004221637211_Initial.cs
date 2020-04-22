namespace TheMealsApp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeverageOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeverageId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beverages", t => t.BeverageId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.BeverageId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Beverages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        AlcoholFree = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.FoodOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Recipe = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodOrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.FoodOrderDetails", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Foods", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.BeverageOrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.BeverageOrderDetails", "BeverageId", "dbo.Beverages");
            DropForeignKey("dbo.Beverages", "MenuId", "dbo.Menus");
            DropIndex("dbo.Foods", new[] { "MenuId" });
            DropIndex("dbo.FoodOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.FoodOrderDetails", new[] { "FoodId" });
            DropIndex("dbo.Beverages", new[] { "MenuId" });
            DropIndex("dbo.BeverageOrderDetails", new[] { "OrderId" });
            DropIndex("dbo.BeverageOrderDetails", new[] { "BeverageId" });
            DropTable("dbo.Foods");
            DropTable("dbo.FoodOrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Menus");
            DropTable("dbo.Beverages");
            DropTable("dbo.BeverageOrderDetails");
        }
    }
}
