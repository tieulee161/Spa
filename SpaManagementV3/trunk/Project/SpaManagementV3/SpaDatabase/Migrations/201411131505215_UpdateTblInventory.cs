namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTblInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "WarehouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventories", "WarehouseId");
            AddForeignKey("dbo.Inventories", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "WarehouseId", "dbo.Warehouses");
            DropIndex("dbo.Inventories", new[] { "WarehouseId" });
            DropColumn("dbo.Inventories", "WarehouseId");
        }
    }
}
