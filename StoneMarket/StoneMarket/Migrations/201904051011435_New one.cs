namespace StoneMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
            CreateTable(
                "dbo.tradeItems",
                c => new
                    {
                        TradeItemId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        PurchaseModel_PurchaseId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TradeItemId)
                .ForeignKey("dbo.Purchases", t => t.PurchaseModel_PurchaseId)
                .Index(t => t.PurchaseModel_PurchaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tradeItems", "PurchaseModel_PurchaseId", "dbo.Purchases");
            DropIndex("dbo.tradeItems", new[] { "PurchaseModel_PurchaseId" });
            DropTable("dbo.tradeItems");
            DropTable("dbo.Purchases");
        }
    }
}
