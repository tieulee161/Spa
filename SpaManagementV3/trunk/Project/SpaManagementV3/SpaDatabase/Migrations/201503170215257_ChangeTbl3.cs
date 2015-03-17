namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTbl3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Status");
        }
    }
}
