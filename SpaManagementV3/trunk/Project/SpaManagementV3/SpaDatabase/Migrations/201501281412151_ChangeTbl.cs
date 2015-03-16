namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTbl : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookRooms", newName: "RoomBooks");
            RenameTable(name: "dbo.PackageBooks", newName: "BookPackages");
            DropForeignKey("dbo.BedServices", "BedId", "dbo.Beds");
            DropForeignKey("dbo.BedKTVs", "PersonnelId", "dbo.Personnels");
            DropForeignKey("dbo.BillCustomers", "BillCertificateId", "dbo.BillCertificates");
            DropForeignKey("dbo.BillCustomers", "BillOtherServiceId", "dbo.BillOtherServices");
            DropForeignKey("dbo.BillCustomers", "BillPackageId", "dbo.BillPackages");
            DropForeignKey("dbo.BillCustomers", "BillServiceId", "dbo.BillServices");
            DropForeignKey("dbo.BillCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BedServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.BedKTVs", "BedServiceId", "dbo.BedServices");
            DropForeignKey("dbo.BillCustomers", "BedService_Id", "dbo.BedServices");
            DropIndex("dbo.BedKTVs", new[] { "BedServiceId" });
            DropIndex("dbo.BedKTVs", new[] { "PersonnelId" });
            DropIndex("dbo.BedServices", new[] { "BedId" });
            DropIndex("dbo.BedServices", new[] { "ServiceId" });
            DropIndex("dbo.BillCustomers", new[] { "CustomerId" });
            DropIndex("dbo.BillCustomers", new[] { "BillServiceId" });
            DropIndex("dbo.BillCustomers", new[] { "BillPackageId" });
            DropIndex("dbo.BillCustomers", new[] { "BillCertificateId" });
            DropIndex("dbo.BillCustomers", new[] { "BillOtherServiceId" });
            DropIndex("dbo.BillCustomers", new[] { "BedService_Id" });
            DropPrimaryKey("dbo.RoomBooks");
            DropPrimaryKey("dbo.BookPackages");
            CreateTable(
                "dbo.BedTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        BedId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beds", t => t.BedId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.BedId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.PersonnelBedTransactions",
                c => new
                    {
                        Personnel_Id = c.Int(nullable: false),
                        BedTransaction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Personnel_Id, t.BedTransaction_Id })
                .ForeignKey("dbo.Personnels", t => t.Personnel_Id, cascadeDelete: true)
                .ForeignKey("dbo.BedTransactions", t => t.BedTransaction_Id, cascadeDelete: true)
                .Index(t => t.Personnel_Id)
                .Index(t => t.BedTransaction_Id);
            
            AddPrimaryKey("dbo.RoomBooks", new[] { "Room_Id", "Book_Id" });
            AddPrimaryKey("dbo.BookPackages", new[] { "Book_Id", "Package_Id" });
            DropColumn("dbo.Beds", "StartTime");
            DropColumn("dbo.Beds", "Duration");
            DropTable("dbo.BedKTVs");
            DropTable("dbo.BedServices");
            DropTable("dbo.BillCustomers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BillCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BillServiceId = c.Int(),
                        BillPackageId = c.Int(),
                        BillCertificateId = c.Int(),
                        BillOtherServiceId = c.Int(),
                        Discount = c.Int(nullable: false),
                        DiscountNote = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                        BedService_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BedServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BedId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        StartAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BedKTVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BedServiceId = c.Int(nullable: false),
                        PersonnelId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Beds", "Duration", c => c.Int());
            AddColumn("dbo.Beds", "StartTime", c => c.DateTime());
            DropForeignKey("dbo.BedTransactions", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.PersonnelBedTransactions", "BedTransaction_Id", "dbo.BedTransactions");
            DropForeignKey("dbo.PersonnelBedTransactions", "Personnel_Id", "dbo.Personnels");
            DropForeignKey("dbo.BedTransactions", "BedId", "dbo.Beds");
            DropIndex("dbo.PersonnelBedTransactions", new[] { "BedTransaction_Id" });
            DropIndex("dbo.PersonnelBedTransactions", new[] { "Personnel_Id" });
            DropIndex("dbo.BedTransactions", new[] { "ServiceId" });
            DropIndex("dbo.BedTransactions", new[] { "BedId" });
            DropPrimaryKey("dbo.BookPackages");
            DropPrimaryKey("dbo.RoomBooks");
            DropTable("dbo.PersonnelBedTransactions");
            DropTable("dbo.BedTransactions");
            AddPrimaryKey("dbo.BookPackages", new[] { "Package_Id", "Book_Id" });
            AddPrimaryKey("dbo.RoomBooks", new[] { "Book_Id", "Room_Id" });
            CreateIndex("dbo.BillCustomers", "BedService_Id");
            CreateIndex("dbo.BillCustomers", "BillOtherServiceId");
            CreateIndex("dbo.BillCustomers", "BillCertificateId");
            CreateIndex("dbo.BillCustomers", "BillPackageId");
            CreateIndex("dbo.BillCustomers", "BillServiceId");
            CreateIndex("dbo.BillCustomers", "CustomerId");
            CreateIndex("dbo.BedServices", "ServiceId");
            CreateIndex("dbo.BedServices", "BedId");
            CreateIndex("dbo.BedKTVs", "PersonnelId");
            CreateIndex("dbo.BedKTVs", "BedServiceId");
            AddForeignKey("dbo.BillCustomers", "BedService_Id", "dbo.BedServices", "Id");
            AddForeignKey("dbo.BedKTVs", "BedServiceId", "dbo.BedServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BedServices", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BillCustomers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BillCustomers", "BillServiceId", "dbo.BillServices", "Id");
            AddForeignKey("dbo.BillCustomers", "BillPackageId", "dbo.BillPackages", "Id");
            AddForeignKey("dbo.BillCustomers", "BillOtherServiceId", "dbo.BillOtherServices", "Id");
            AddForeignKey("dbo.BillCustomers", "BillCertificateId", "dbo.BillCertificates", "Id");
            AddForeignKey("dbo.BedKTVs", "PersonnelId", "dbo.Personnels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BedServices", "BedId", "dbo.Beds", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.BookPackages", newName: "PackageBooks");
            RenameTable(name: "dbo.RoomBooks", newName: "BookRooms");
        }
    }
}
