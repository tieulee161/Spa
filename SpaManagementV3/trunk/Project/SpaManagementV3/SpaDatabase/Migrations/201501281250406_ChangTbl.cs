namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangTbl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Beds", "EndTime");
            DropColumn("dbo.Beds", "Remain");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Beds", "Remain", c => c.Int());
            AddColumn("dbo.Beds", "EndTime", c => c.DateTime());
        }
    }
}
