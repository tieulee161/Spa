namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTbl1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BedTransactions", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BedTransactions", "Status");
        }
    }
}
