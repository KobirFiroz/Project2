namespace SBMSystemMVCApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all_Table_Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        ImageCustomer = c.String(),
                        LoyaltyPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ReorderLevel = c.Int(nullable: false),
                        ImageProduct = c.String(),
                        Description = c.String(),
                        AvailableQuantity = c.Int(nullable: false),
                        CurrentMRP = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        BillNo = c.String(),
                        SupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ManufacturedDate = c.String(),
                        ExpireDate = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        MRP = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        ImageLogo = c.String(),
                        ContactPerson = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
