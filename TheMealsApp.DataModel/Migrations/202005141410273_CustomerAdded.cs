namespace TheMealsApp.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "MenuItem_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Customer_Id");
            CreateIndex("dbo.Orders", "MenuItem_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "MenuItem_Id", "dbo.MenuItems", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "MenuItem_Id", "dbo.MenuItems");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "MenuItem_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropColumn("dbo.Orders", "MenuItem_Id");
            DropColumn("dbo.Orders", "Customer_Id");
            DropTable("dbo.Customers");
        }
    }
}
