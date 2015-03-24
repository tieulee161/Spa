namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTbl4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Location", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Location");
        }
    }
}
