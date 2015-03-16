namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnels", t => t.PersonnelId, cascadeDelete: true)
                .ForeignKey("dbo.BedServices", t => t.BedServiceId, cascadeDelete: true)
                .Index(t => t.BedServiceId)
                .Index(t => t.PersonnelId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beds", t => t.BedId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.BedId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Beds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BedId = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Duration = c.Int(),
                        Remain = c.Int(),
                        RoomId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 20),
                        Charge = c.Int(nullable: false),
                        Branch = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillMainId = c.Int(),
                        BillPackageId = c.Int(),
                        ServiceId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Tour = c.Int(nullable: false),
                        ServiceChargePercent = c.Int(nullable: false),
                        PromotionId = c.Int(),
                        PromotionPercent = c.Int(),
                        PromotionVND = c.Int(),
                        DiscountPercent = c.Int(),
                        DiscountVND = c.Int(),
                        RoomId = c.Int(nullable: false),
                        RoomChargePercent = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        CustomerDiscountPercent = c.Int(),
                        CustomerDiscountVND = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .ForeignKey("dbo.BillMains", t => t.BillMainId)
                .ForeignKey("dbo.BillPackages", t => t.BillPackageId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.BillMainId)
                .Index(t => t.BillPackageId)
                .Index(t => t.ServiceId)
                .Index(t => t.PromotionId)
                .Index(t => t.RoomId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.BillKTVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillServiceId = c.Int(nullable: false),
                        PersonnelId = c.Int(nullable: false),
                        ChargePercent = c.Int(),
                        IsCustomerOrder = c.Boolean(),
                        IsCompanyOrder = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillServices", t => t.BillServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Personnels", t => t.PersonnelId, cascadeDelete: true)
                .Index(t => t.BillServiceId)
                .Index(t => t.PersonnelId);
            
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        KTVId = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 20),
                        JoinDate = c.DateTime(nullable: false),
                        Position = c.Int(nullable: false),
                        Charge = c.Int(),
                        IdNumber = c.String(maxLength: 20),
                        MaritalStatus = c.Int(),
                        Address = c.String(maxLength: 500),
                        Status = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        BookingTime = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillMainId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        ServiceChargePercent = c.Int(nullable: false),
                        PromotionId = c.Int(),
                        PromotionPercent = c.Int(),
                        PromotionVND = c.Int(),
                        DiscountPercent = c.Int(),
                        DiscountVND = c.Int(),
                        CustomerId = c.Int(),
                        CustomerDiscountPercent = c.Int(),
                        CustomerDiscountVND = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .ForeignKey("dbo.BillMains", t => t.BillMainId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.BillMainId)
                .Index(t => t.PackageId)
                .Index(t => t.PromotionId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.BillMains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillNumber = c.Int(nullable: false),
                        Shift = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        CustomerName = c.String(),
                        NumberOfPerson = c.Int(nullable: false),
                        NumberOfService = c.Int(nullable: false),
                        USD = c.Int(nullable: false),
                        VND = c.Int(nullable: false),
                        Visa = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 500),
                        Status = c.Int(nullable: false),
                        DeleteBillReason = c.String(),
                        Branch = c.Int(nullable: false),
                        ServiceCharge = c.Int(nullable: false),
                        RawTotal = c.Int(nullable: false),
                        RawTotalDiscount = c.Int(nullable: false),
                        Voucher = c.Int(nullable: false),
                        BillDiscount = c.Int(nullable: false),
                        FinalTotal = c.Int(nullable: false),
                        VAT = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.BillCertificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillMainId = c.Int(nullable: false),
                        CertificateId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        PromotionId = c.Int(),
                        PromotionPercent = c.Int(),
                        PromotionVND = c.Int(),
                        DiscountPercent = c.Int(),
                        DiscountVND = c.Int(),
                        CustomerId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillMains", t => t.BillMainId, cascadeDelete: true)
                .ForeignKey("dbo.Certificates", t => t.CertificateId, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.BillMainId)
                .Index(t => t.CertificateId)
                .Index(t => t.PromotionId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CertificateSeris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillCertificateId = c.Int(),
                        Seri = c.Int(nullable: false),
                        CertificateId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillCertificates", t => t.BillCertificateId)
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .Index(t => t.BillCertificateId)
                .Index(t => t.CertificateId);
            
            CreateTable(
                "dbo.BillVoucherPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillMainId = c.Int(),
                        CertificateSeriId = c.Int(nullable: false),
                        Pay = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillMains", t => t.BillMainId)
                .ForeignKey("dbo.CertificateSeris", t => t.CertificateSeriId, cascadeDelete: true)
                .Index(t => t.BillMainId)
                .Index(t => t.CertificateSeriId);
            
            CreateTable(
                "dbo.Exports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExportedBy = c.String(nullable: false),
                        CertificateId = c.Int(),
                        OtherServiceId = c.Int(),
                        ExportAt = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 500),
                        Quantity = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .ForeignKey("dbo.OtherServices", t => t.OtherServiceId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.CertificateId)
                .Index(t => t.OtherServiceId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.OtherServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillOtherServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillMainId = c.Int(nullable: false),
                        OtherServiceId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        PromotionId = c.Int(),
                        PromotionPercent = c.Int(),
                        PromotionVND = c.Int(),
                        DiscountPercent = c.Int(),
                        DiscountVND = c.Int(),
                        CustomerId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillMains", t => t.BillMainId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.OtherServices", t => t.OtherServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .Index(t => t.BillMainId)
                .Index(t => t.OtherServiceId)
                .Index(t => t.PromotionId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        Gender = c.Int(),
                        DOB = c.DateTime(),
                        Phone = c.String(),
                        Email = c.String(),
                        Company = c.String(),
                        Address = c.String(),
                        TaxNumber = c.String(),
                        JobId = c.Int(),
                        NationalityId = c.Int(),
                        MemberId = c.Int(),
                        MemberCardSeri = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId)
                .Index(t => t.JobId)
                .Index(t => t.NationalityId)
                .Index(t => t.MemberId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillCertificates", t => t.BillCertificateId)
                .ForeignKey("dbo.BillOtherServices", t => t.BillOtherServiceId)
                .ForeignKey("dbo.BillPackages", t => t.BillPackageId)
                .ForeignKey("dbo.BillServices", t => t.BillServiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.BedServices", t => t.BedService_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.BillServiceId)
                .Index(t => t.BillPackageId)
                .Index(t => t.BillCertificateId)
                .Index(t => t.BillOtherServiceId)
                .Index(t => t.BedService_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Discount = c.Int(nullable: false),
                        Percent = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Discount = c.Int(nullable: false),
                        Percent = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Discount = c.Int(nullable: false),
                        Percent = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        Type = c.Int(nullable: false),
                        IssueDate = c.DateTime(),
                        ExpiryDate = c.DateTime(),
                        StartTime = c.DateTime(),
                        StopTime = c.DateTime(),
                        Note = c.String(maxLength: 500),
                        Discount = c.Int(nullable: false),
                        IsPercent = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Imports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImportedBy = c.String(nullable: false),
                        CertificateId = c.Int(),
                        OtherServiceId = c.Int(),
                        ImportAt = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 500),
                        Quantity = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .ForeignKey("dbo.OtherServices", t => t.OtherServiceId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.CertificateId)
                .Index(t => t.OtherServiceId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        WarehouseType = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        CertificateId = c.Int(),
                        OtherServiceId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .ForeignKey("dbo.OtherServices", t => t.OtherServiceId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.CertificateId)
                .Index(t => t.OtherServiceId);
            
            CreateTable(
                "dbo.BillDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Code = c.String(),
                        KTV = c.String(),
                        Price = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        BillMainId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillMains", t => t.BillMainId, cascadeDelete: true)
                .Index(t => t.BillMainId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        Name = c.String(maxLength: 20),
                        Password = c.String(maxLength: 20),
                        JobPosition = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserRole = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tour = c.Int(nullable: false),
                        NumberOfKTVNeeded = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        ExchangeRate = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        VND = c.Int(nullable: false),
                        USD = c.Int(nullable: false),
                        Visa = c.Int(nullable: false),
                        Giver = c.String(),
                        Receiver = c.String(),
                        Note = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonnelSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BonusPerCustomerOrder = c.Int(nullable: false),
                        BonusPerCompanyOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShiftReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Shift = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        VND = c.Int(nullable: false),
                        USD = c.Int(nullable: false),
                        Visa = c.Int(nullable: false),
                        Giver = c.String(),
                        Receiver = c.String(),
                        Note = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 200),
                        ContactPerson = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 20),
                        AccountNumber = c.String(maxLength: 50),
                        Address = c.String(maxLength: 400),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MailDB = c.String(maxLength: 100),
                        MailBill = c.String(maxLength: 100),
                        BackupFolder = c.String(maxLength: 400),
                        Period = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VIPSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Visit = c.Int(),
                        Account = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageBooks",
                c => new
                    {
                        Package_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Package_Id, t.Book_Id })
                .ForeignKey("dbo.Packages", t => t.Package_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Package_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.ServiceBooks",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Book_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.ServicePackages",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Package_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Package_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.Package_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.ServicePersonnels",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Personnel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Personnel_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personnels", t => t.Personnel_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Personnel_Id);
            
            CreateTable(
                "dbo.BookPersonnels",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Personnel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Personnel_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Personnels", t => t.Personnel_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Personnel_Id);
            
            CreateTable(
                "dbo.BookRooms",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Room_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Room_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Room_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillCustomers", "BedService_Id", "dbo.BedServices");
            DropForeignKey("dbo.BedKTVs", "BedServiceId", "dbo.BedServices");
            DropForeignKey("dbo.BillServices", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.BillServices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BookRooms", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.BookRooms", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookPersonnels", "Personnel_Id", "dbo.Personnels");
            DropForeignKey("dbo.BookPersonnels", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.ServicePersonnels", "Personnel_Id", "dbo.Personnels");
            DropForeignKey("dbo.ServicePersonnels", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServicePackages", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.ServicePackages", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.ServiceBooks", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.BillServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.BedServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.PackageBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.PackageBooks", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.BillPackages", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.BillPackages", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BillServices", "BillPackageId", "dbo.BillPackages");
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropForeignKey("dbo.BillMains", "UserId", "dbo.Users");
            DropForeignKey("dbo.BillServices", "BillMainId", "dbo.BillMains");
            DropForeignKey("dbo.BillPackages", "BillMainId", "dbo.BillMains");
            DropForeignKey("dbo.BillDetails", "BillMainId", "dbo.BillMains");
            DropForeignKey("dbo.BillCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Inventories", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Inventories", "OtherServiceId", "dbo.OtherServices");
            DropForeignKey("dbo.Inventories", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Imports", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Exports", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Imports", "OtherServiceId", "dbo.OtherServices");
            DropForeignKey("dbo.Imports", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Exports", "OtherServiceId", "dbo.OtherServices");
            DropForeignKey("dbo.BillServices", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.BillPackages", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.BillOtherServices", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.BillCertificates", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.BillOtherServices", "OtherServiceId", "dbo.OtherServices");
            DropForeignKey("dbo.BillOtherServices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Customers", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Customers", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.BillMains", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BillCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BillCustomers", "BillServiceId", "dbo.BillServices");
            DropForeignKey("dbo.BillCustomers", "BillPackageId", "dbo.BillPackages");
            DropForeignKey("dbo.BillCustomers", "BillOtherServiceId", "dbo.BillOtherServices");
            DropForeignKey("dbo.BillCustomers", "BillCertificateId", "dbo.BillCertificates");
            DropForeignKey("dbo.BillOtherServices", "BillMainId", "dbo.BillMains");
            DropForeignKey("dbo.Exports", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.CertificateSeris", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.BillVoucherPayments", "CertificateSeriId", "dbo.CertificateSeris");
            DropForeignKey("dbo.BillVoucherPayments", "BillMainId", "dbo.BillMains");
            DropForeignKey("dbo.CertificateSeris", "BillCertificateId", "dbo.BillCertificates");
            DropForeignKey("dbo.BillCertificates", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.BillCertificates", "BillMainId", "dbo.BillMains");
            DropForeignKey("dbo.BillKTVs", "PersonnelId", "dbo.Personnels");
            DropForeignKey("dbo.BedKTVs", "PersonnelId", "dbo.Personnels");
            DropForeignKey("dbo.BillKTVs", "BillServiceId", "dbo.BillServices");
            DropForeignKey("dbo.Beds", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.BedServices", "BedId", "dbo.Beds");
            DropIndex("dbo.BookRooms", new[] { "Room_Id" });
            DropIndex("dbo.BookRooms", new[] { "Book_Id" });
            DropIndex("dbo.BookPersonnels", new[] { "Personnel_Id" });
            DropIndex("dbo.BookPersonnels", new[] { "Book_Id" });
            DropIndex("dbo.ServicePersonnels", new[] { "Personnel_Id" });
            DropIndex("dbo.ServicePersonnels", new[] { "Service_Id" });
            DropIndex("dbo.ServicePackages", new[] { "Package_Id" });
            DropIndex("dbo.ServicePackages", new[] { "Service_Id" });
            DropIndex("dbo.ServiceBooks", new[] { "Book_Id" });
            DropIndex("dbo.ServiceBooks", new[] { "Service_Id" });
            DropIndex("dbo.PackageBooks", new[] { "Book_Id" });
            DropIndex("dbo.PackageBooks", new[] { "Package_Id" });
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.BillDetails", new[] { "BillMainId" });
            DropIndex("dbo.Inventories", new[] { "OtherServiceId" });
            DropIndex("dbo.Inventories", new[] { "CertificateId" });
            DropIndex("dbo.Inventories", new[] { "WarehouseId" });
            DropIndex("dbo.Imports", new[] { "WarehouseId" });
            DropIndex("dbo.Imports", new[] { "OtherServiceId" });
            DropIndex("dbo.Imports", new[] { "CertificateId" });
            DropIndex("dbo.BillCustomers", new[] { "BedService_Id" });
            DropIndex("dbo.BillCustomers", new[] { "BillOtherServiceId" });
            DropIndex("dbo.BillCustomers", new[] { "BillCertificateId" });
            DropIndex("dbo.BillCustomers", new[] { "BillPackageId" });
            DropIndex("dbo.BillCustomers", new[] { "BillServiceId" });
            DropIndex("dbo.BillCustomers", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "MemberId" });
            DropIndex("dbo.Customers", new[] { "NationalityId" });
            DropIndex("dbo.Customers", new[] { "JobId" });
            DropIndex("dbo.BillOtherServices", new[] { "CustomerId" });
            DropIndex("dbo.BillOtherServices", new[] { "PromotionId" });
            DropIndex("dbo.BillOtherServices", new[] { "OtherServiceId" });
            DropIndex("dbo.BillOtherServices", new[] { "BillMainId" });
            DropIndex("dbo.Exports", new[] { "WarehouseId" });
            DropIndex("dbo.Exports", new[] { "OtherServiceId" });
            DropIndex("dbo.Exports", new[] { "CertificateId" });
            DropIndex("dbo.BillVoucherPayments", new[] { "CertificateSeriId" });
            DropIndex("dbo.BillVoucherPayments", new[] { "BillMainId" });
            DropIndex("dbo.CertificateSeris", new[] { "CertificateId" });
            DropIndex("dbo.CertificateSeris", new[] { "BillCertificateId" });
            DropIndex("dbo.BillCertificates", new[] { "CustomerId" });
            DropIndex("dbo.BillCertificates", new[] { "PromotionId" });
            DropIndex("dbo.BillCertificates", new[] { "CertificateId" });
            DropIndex("dbo.BillCertificates", new[] { "BillMainId" });
            DropIndex("dbo.BillMains", new[] { "CustomerId" });
            DropIndex("dbo.BillMains", new[] { "UserId" });
            DropIndex("dbo.BillPackages", new[] { "CustomerId" });
            DropIndex("dbo.BillPackages", new[] { "PromotionId" });
            DropIndex("dbo.BillPackages", new[] { "PackageId" });
            DropIndex("dbo.BillPackages", new[] { "BillMainId" });
            DropIndex("dbo.BillKTVs", new[] { "PersonnelId" });
            DropIndex("dbo.BillKTVs", new[] { "BillServiceId" });
            DropIndex("dbo.BillServices", new[] { "CustomerId" });
            DropIndex("dbo.BillServices", new[] { "RoomId" });
            DropIndex("dbo.BillServices", new[] { "PromotionId" });
            DropIndex("dbo.BillServices", new[] { "ServiceId" });
            DropIndex("dbo.BillServices", new[] { "BillPackageId" });
            DropIndex("dbo.BillServices", new[] { "BillMainId" });
            DropIndex("dbo.Beds", new[] { "RoomId" });
            DropIndex("dbo.BedServices", new[] { "ServiceId" });
            DropIndex("dbo.BedServices", new[] { "BedId" });
            DropIndex("dbo.BedKTVs", new[] { "PersonnelId" });
            DropIndex("dbo.BedKTVs", new[] { "BedServiceId" });
            DropTable("dbo.BookRooms");
            DropTable("dbo.BookPersonnels");
            DropTable("dbo.ServicePersonnels");
            DropTable("dbo.ServicePackages");
            DropTable("dbo.ServiceBooks");
            DropTable("dbo.PackageBooks");
            DropTable("dbo.VIPSettings");
            DropTable("dbo.SystemDatas");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ShiftReports");
            DropTable("dbo.PersonnelSettings");
            DropTable("dbo.DailyReports");
            DropTable("dbo.Currencies");
            DropTable("dbo.Services");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.BillDetails");
            DropTable("dbo.Inventories");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Imports");
            DropTable("dbo.Promotions");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Members");
            DropTable("dbo.Jobs");
            DropTable("dbo.BillCustomers");
            DropTable("dbo.Customers");
            DropTable("dbo.BillOtherServices");
            DropTable("dbo.OtherServices");
            DropTable("dbo.Exports");
            DropTable("dbo.BillVoucherPayments");
            DropTable("dbo.CertificateSeris");
            DropTable("dbo.Certificates");
            DropTable("dbo.BillCertificates");
            DropTable("dbo.BillMains");
            DropTable("dbo.BillPackages");
            DropTable("dbo.Packages");
            DropTable("dbo.Books");
            DropTable("dbo.Personnels");
            DropTable("dbo.BillKTVs");
            DropTable("dbo.BillServices");
            DropTable("dbo.Rooms");
            DropTable("dbo.Beds");
            DropTable("dbo.BedServices");
            DropTable("dbo.BedKTVs");
        }
    }
}
