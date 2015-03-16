namespace SpaDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SpaDatabase.Services;
    using SpaDatabase.Model.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaDatabase.Model.SpaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpaDatabase.Model.SpaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            DBAccess dbService = new DBAccess();
            User user = null;
            dbService.AddNewUser("admin", "admin", "noname", Model.Entities.JobPosition.Manager, out user);

            dbService.UpdateSystemData("hiepmk@gmail.com", "hiepmk@gmail.com", @"D:\", 1);

            dbService.UpdateCurrency(21000);

            Warehouse warehouse = null;
            dbService.AddNewWarehouse("Kho 1", "KH1", ServiceType.Certificate, out warehouse);
            dbService.AddNewWarehouse("Kho 2", "KH2", ServiceType.OtherService, out warehouse);

            #region customer
            Job job = null;
            dbService.AddNewJob("Sales", 0, true, out job);
            dbService.AddNewJob("Bussiness", 0, true, out job);
            dbService.AddNewJob("Director", 0, true, out job);
            dbService.AddNewJob("Accountant", 0, true, out job);
            dbService.AddNewJob("Others", 0, true, out job);

            Nationality nationality = null;
            dbService.AddNewNationality("Vietnam", 0, true, out nationality);
            dbService.AddNewNationality("Japan", 0, true, out nationality);
            dbService.AddNewNationality("Korea", 0, true, out nationality);
            dbService.AddNewNationality("Taiwan", 0, true, out nationality);
            dbService.AddNewNationality("Others", 0, true, out nationality);

            Member member = null;
            dbService.AddNewMember("Normal", 0, true, out member);
            dbService.AddNewMember("VIP", 10, true, out member);

            dbService.UpdateVIPSetting(100, 30000000);
            dbService.UpdatePeronnelSetting(20000, 15000);

            Customer cus = null;
            dbService.AddNewCustomer("Hiep", "KH000", Gender.Male, DateTime.Now, "123456", "", "", "", "", "", "", "Normal", out cus);
            dbService.AddNewCustomer("Tuan", "KH001", Gender.Male, DateTime.Now, "789101", "", "", "", "", "", "", "VIP", out cus);
            #endregion

            #region room
            Room room = null;
            dbService.AddNewRoom("BODY 1", "BODY1-9C", 0, Branch.MH9C, out room);
            dbService.AddNewRoom("BODY 2", "BODY2-9C", 0, Branch.MH9C, out room);
            dbService.AddNewRoom("BODY 3", "BODY3-9C", 0, Branch.MH9C, out room);
            dbService.AddNewRoom("BODY 4", "BODY4-9C", 0, Branch.MH9C, out room);
            dbService.AddNewRoom("THAI", "THAI-9C", 0, Branch.MH9C, out room);
            dbService.AddNewRoom("FOOT", "FOOT-9C", 0, Branch.MH9C, out room);
            dbService.AddNewRoom("VIP 1", "VIP1-9C", 30, Branch.MH9C, out room);
            dbService.AddNewRoom("VIP 2", "VIP2-9C", 30, Branch.MH9C, out room);

            dbService.AddNewRoom("BODY 1", "BODY1-2A", 0, Branch.MH2A, out room);
            dbService.AddNewRoom("BODY 2", "BODY2-2A", 0, Branch.MH2A, out room);
            dbService.AddNewRoom("BODY 3", "BODY3-2A", 0, Branch.MH2A, out room);
            dbService.AddNewRoom("FOOT", "FOOT-2A", 0, Branch.MH2A, out room);
            dbService.AddNewRoom("THAI", "THAI-2A", 0, Branch.MH2A, out room);


            Bed bed = null;
            for (int j = 0; j < 2; j++)
            {
                dbService.AddNewBed("VIP1-9C", j + 1, out bed);
                dbService.AddNewBed("VIP2-9C", j + 1, out bed);
            }

            for (int j = 0; j < 3; j++)
            {
                dbService.AddNewBed("BODY2-9C", j + 1, out bed);
                dbService.AddNewBed("BODY4-9C", j + 1, out bed);

                dbService.AddNewBed("BODY2-2A", j + 1, out bed);
                dbService.AddNewBed("THAI-2A", j + 1, out bed);
            }

            for (int j = 0; j < 4; j++)
            {
                dbService.AddNewBed("FOOT-9C", j + 1, out bed);

                dbService.AddNewBed("BODY1-2A", j + 1, out bed);
                dbService.AddNewBed("BODY3-2A", j + 1, out bed);
            }

            for (int j = 0; j < 5; j++)
            {
                dbService.AddNewBed("BODY1-9C", j + 1, out bed);
                dbService.AddNewBed("BODY3-9C", j + 1, out bed);
                dbService.AddNewBed("THAI-9C", j + 1, out bed);

            }

            for (int j = 0; j < 6; j++)
            {
                dbService.AddNewBed("FOOT-2A", j + 1, out bed);
            }

            #endregion

            #region KTV
            Personnel personnel = null;
            for (int j = 0; j < 40; j++)
            {
                dbService.AddNewPersonnel(string.Format("KTV{0}", (j + 1).ToString("000")),
                                          j + 1,
                                          Gender.Female, DateTime.Now,
                                          "",
                                          DateTime.Now,
                                          JobPosition.KTV,
                                          0,
                                          "",
                                          MaritalStatus.Single,
                                          "",
                                          out personnel);
            }
            #endregion

            #region service
            Service service = null;
            dbService.AddNewService("Head Massage 35'", "HE35", 200000, 30000, out service);

            dbService.AddNewService("Foot Massage 35'", "F35", 200000, 30000, out service);
            dbService.AddNewService("Foot Massage 45'", "F45", 250000, 40000, out service);
            dbService.AddNewService("Foot Relaxing Massage 60'", "F60", 300000, 60000, out service);
            dbService.AddNewService("Foot With Hot Stones 90'", "F90", 400000, 80000, out service);
            dbService.AddNewService("The Longest Foot 120'", "F120", 500000, 110000, out service);

            dbService.AddNewService("Swedish Massage 60'", "SWM60", 360000, 70000, out service);
            dbService.AddNewService("Swedish Massage 90'", "SWM90", 500000, 90000, out service);
            dbService.AddNewService("Swedish Massage 120'", "SWM120", 650000, 120000, out service);
            dbService.AddNewService("Thai Massage 60'", "TM60", 360000, 70000, out service);
            dbService.AddNewService("Thai Massage 90'", "TM90", 500000, 90000, out service);
            dbService.AddNewService("Thai Massage 120'", "TM120", 650000, 120000, out service);
            dbService.AddNewService("Shiatsu Massage 60'", "SHM60", 380000, 80000, out service);
            dbService.AddNewService("Shiatsu Massage 90'", "SHM90", 520000, 100000, out service);
            dbService.AddNewService("Shiatsu Massage 120'", "SHM120", 670000, 140000, out service);
            dbService.AddNewService("Aromatherapy 60'", "AT60", 360000, 70000, out service);
            dbService.AddNewService("Aromatherapy 90'", "AT90", 500000, 90000, out service);
            dbService.AddNewService("Aromatherapy 120'", "AT120", 650000, 120000, out service);
            dbService.AddNewService("Herbal Steam 90'", "HS90", 600000, 90000, out service);
            dbService.AddNewService("Herbal Steam 120'", "HS120", 800000, 120000, out service);
            dbService.AddNewService("Hot Stones Massage 90'", "HSM90", 500000, 90000, out service);
            dbService.AddNewService("Hot Stones Massage 120'", "HSM120", 650000, 120000, out service);
            dbService.AddNewService("Body 45'", "BD45", 250000, 40000, out service);
            dbService.AddNewService("Corn Cob Srub 70'", "CCS70", 700000, 90000, out service);
            dbService.AddNewService("Hawaiian Massage 60'", "HM60", 360000, 70000, out service);
            dbService.AddNewService("Hawaiian Massage 90'", "HM90", 500000, 90000, out service);
            dbService.AddNewService("Hawaiian Massage 120'", "HM120", 650000, 120000, out service);
            dbService.AddNewService("Speacial Moc Huong Massage 60'", "SMHM60", 360000, 70000, out service);
            dbService.AddNewService("Speacial Moc Huong Massage 90'", "SMHM90", 500000, 90000, out service);
            dbService.AddNewService("Speacial Moc Huong Massage 120'", "SMHM120", 650000, 120000, out service);
            dbService.AddNewService("Moc Huong Four Hands 60'", "4H60", 600000, 120000, out service);
            dbService.AddNewService("Moc Huong Four Hands 90'", "4H90", 800000, 160000, out service);
            dbService.AddNewService("Moc Huong Four Hands 120'", "4H120", 950000, 200000, out service);
            dbService.AddNewService("Moc Huong Six Hands 90'", "6H90", 1000000, 270000, out service);
            dbService.AddNewService("Moc Huong Six Hands 120'", "6H120", 1200000, 330000, out service);
            dbService.AddNewService("Sliming Massage 60'", "SLM60", 500000, 70000, out service);
            dbService.AddNewService("Sliming Massage 90'", "SLM90", 700000, 90000, out service);
            dbService.AddNewService("Sliming Massage 120'", "SLM120", 850000, 120000, out service);

            dbService.AddNewService("Moc Huong Relaxtion Facial 60'", "RF60", 550000, 70000, out service);
            dbService.AddNewService("Brightening Facial 70'", "BF70", 650000, 80000, out service);
            dbService.AddNewService("Anti-anging 90'", "AA90", 800000, 100000, out service);

            dbService.AddNewService("Menicure", "ME", 100000, 20000, out service);
            dbService.AddNewService("Pedicure", "PE", 100000, 20000, out service);
            dbService.AddNewService("Menicure & Polish", "MEPO", 150000, 30000, out service);
            dbService.AddNewService("Pedicure & Polish", "PEPO", 150000, 30000, out service);
            dbService.AddNewService("Menicure & Pedicure", "MEPE", 160000, 32000, out service);
            dbService.AddNewService("Polish", "PO", 60000, 12000, out service);
            dbService.AddNewService("Hand Scrub", "HS", 160000, 32000, out service);
            dbService.AddNewService("Foot Scrub", "FSCRUB", 180000, 36000, out service);
            dbService.AddNewService("Hand & Foot Scrub", "HFS", 300000, 60000, out service);
            dbService.AddNewService("Foot Scrape", "FSCRAPE", 120000, 24000, out service);
            dbService.AddNewService("Nail Package", "NP", 360000, 72000, out service);

            dbService.AddNewService("Waxing Bikini 30'", "WB30", 140000, 28000, out service);
            dbService.AddNewService("Waxing Half Arm 30'", "WHA30", 150000, 30000, out service);
            dbService.AddNewService("Waxing Full Arm 30'", "WFA30", 250000, 50000, out service);
            dbService.AddNewService("Waxing Eyebrow 15'", "WEB15", 60000, 12000, out service);
            dbService.AddNewService("Waxing Half Leg 30'", "WHL30", 150000, 30000, out service);
            dbService.AddNewService("Waxing Full Leg 45'", "WFL45", 270000, 54000, out service);
            dbService.AddNewService("Waxing Under Arm 20'", "WUA20", 100000, 20000, out service);
            dbService.AddNewService("Waxing Back 30'", "WB30", 270000, 54000, out service);
            dbService.AddNewService("Waxing Upper Lip & Chin 20'", "WULC20", 100000, 20000, out service);
            dbService.AddNewService("Waxing Brazilian", "WB", 150000, 30000, out service);

            dbService.AddNewService("Brow Tint 20'", "BT20", 120000, 24000, out service);
            dbService.AddNewService("Last Tint 30'", "LT30", 150000, 30000, out service);
            dbService.AddNewService("Tint Package 45'", "TP45", 250000, 50000, out service);
            #endregion

            #region package
            Package package = null;
            dbService.AddNewPackage("Relaxing Package", "RLPK", 850000, out package);
            dbService.AddNewPackage("Refreshing Package", "RFPK", 1500000, out package);
            dbService.AddNewPackage("Touch Of Heaven Package", "TOHPK", 1300000, out package);
            dbService.AddNewPackage("Sanctuary Package", "STPK", 1500000, out package);
            dbService.AddNewPackage("Performing With The Therapist Package", "PWTTPK", 1150000, out package);
            #endregion

            #region certificate
            Certificate certificate = null;
            dbService.AddNewCertificate("Gift Voucher 300K", "GV300K", 300000, 3, out certificate);
            dbService.AddNewCertificate("Gift Voucher 500K", "GV500K", 500000, 3, out certificate);
            dbService.AddNewCertificate("Gift Voucher 1000K", "GV1000K", 1000000, 3, out certificate);
            dbService.AddNewCertificate("Gift Voucher 5000K", "GV5000K", 5000000, 3, out certificate);

            #endregion

            #region other
            OtherService otherService = null;
            dbService.AddNewOtherService("Water", "WATER", 15000, out otherService);
            dbService.AddNewOtherService("Ginger", "GG", 100000, out otherService);
            #endregion

            #region promotion
            Promotion promotion = null;
            dbService.AddNewPromotion("10% off", "Off10", 10, true, PromotionCondition.NoCondition, null, null, null, null, "", out promotion);
            dbService.AddNewPromotion("20% off", "Off20", 20, true, PromotionCondition.NoCondition, null, null, null, null, "", out promotion);
            dbService.AddNewPromotion("50% off", "Off50", 50, true, PromotionCondition.NoCondition, null, null, null, null, "", out promotion);

            #endregion
        }
    }
}
