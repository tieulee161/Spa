using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using SpaDatabase.Model.Entities;

namespace SpaDatabase.Model
{
    public class SpaDbContext : DbContext
    {
        public SpaDbContext()
            : base("SpaDatabaseConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Service> Services { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateSeri> CertificateSeries { get; set; }
        public DbSet<OtherService> OtherServices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VIPSetting> VIPSettings { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<Export> Exports { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<SystemData> SystemData { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BillMain> BillMains { get; set; }
        public DbSet<BillVoucherPayment> BillVoucherPayments { get; set; }
        public DbSet<BillService> BillServices { get; set; }
        public DbSet<BillPackage> BillPackages { get; set; }
        public DbSet<BillKTV> BillKTVs { get; set; }
        public DbSet<BillCertificate> BillCertificates { get; set; }
        public DbSet<BillOtherService> BillOtherServices { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<ShiftReport> ShiftReports { get; set; }
        public DbSet<PersonnelSetting> PersonnelSettings { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BedTransaction> BedTransaction { get; set; }
    }
}
