namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTbl2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BedTransactions", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BedTransactions", "Status", c => c.Int(nullable: false));
        }
    }
}
