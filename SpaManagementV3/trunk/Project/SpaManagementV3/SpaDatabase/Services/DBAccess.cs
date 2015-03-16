using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

//using MySql.Data.MySqlClient;
//using MySql.Data;
using System.IO;
using System.Threading;
using SpaDatabase.Model;
using SpaDatabase.Model.Entities;
using SpaDatabase.Repositories;
using SpaCommon;
using System.Data.Objects;


namespace SpaDatabase.Services
{
    public class DBAccess : MarshalByRefObject
    {
        public static bool SubmitToDatabase(SpaDbContext db)
        {
            bool res = false;
            // try
            {
                db.SaveChanges();
                res = true;
            }
            //catch (OptimisticConcurrencyException)
            //{
            //    db.Refresh(System.Data.Objects.RefreshMode.ClientWins, db);
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    string info = ex.Message;
            //    if (ex.InnerException != null)
            //    {
            //        info += "\r\n" + ex.InnerException;
            //    }
            //    MessageBox.Show(info);
            //}
            return res;
        }

        #region bill
        public BillMain GetBill(int billNumber)
        {
            BillMain res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billMainService = new Repository<BillMain>(db);
                res = billMainService.Get(q => q.BillNumber == billNumber, null, "User,BillDetails,BillVoucherPayments.CertificateSeri.Certificate").FirstOrDefault();
            }
            return res;
        }

        public List<BillMain> GetBills(DateTime date)
        {
            List<BillMain> res = new List<BillMain>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billMainService = new Repository<BillMain>(db);
                DateTime fromDate = new DateTime(date.Year, date.Month, 1);
                DateTime toDate = new DateTime(date.Year, date.Month + 1, 1);

                var query = billMainService.Get(q => (q.Date >= fromDate) && (q.Date <= toDate), null, "User,BillDetails,BillVoucherPayments.CertificateSeri.Certificate");
                res = query.ToList();
            }
            return res;
        }

        public Dictionary<BillStatus, List<BillMain>> GetClassifiedBills(DateTime date)
        {
            Dictionary<BillStatus, List<BillMain>> res = new Dictionary<BillStatus, List<BillMain>>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billMainService = new Repository<BillMain>(db);
                DateTime fromDate = new DateTime(date.Year, date.Month, 1);
                DateTime toDate = new DateTime(date.Year, date.Month + 1, 1);

                var query = billMainService.Get(q => (q.Date >= fromDate) && (q.Date <= toDate) && (q.Status == BillStatus.NotPayed), null, "User,BillDetails,BillVoucherPayments.CertificateSeri.Certificate");
                res.Add(BillStatus.NotPayed, query.ToList());

                var query1 = billMainService.Get(q => (q.Date >= fromDate) && (q.Date <= toDate) && (q.Status == BillStatus.Payed), null, "User,BillDetails,BillVoucherPayments.CertificateSeri.Certificate");
                res.Add(BillStatus.Payed, query1.ToList());

                var query2 = billMainService.Get(q => (q.Date >= fromDate) && (q.Date <= toDate) && (q.Status == BillStatus.Bad), null, "User,BillDetails,BillVoucherPayments.CertificateSeri.Certificate");
                res.Add(BillStatus.Bad, query2.ToList());
            }
            return res;
        }

        public int GetNumberOfNotPayedBill()
        {
            int res = 0;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billMainService = new Repository<BillMain>(db);
                res = billMainService.Get(q => q.Status == BillStatus.NotPayed).Count();
            }
            return res;
        }

        public int GetNewBillNumber(Branch branch)
        {
            int res = 0;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billService = new Repository<BillMain>(db);
                BillMain bill = billService.Get(q => q.Branch == branch, q => q.OrderByDescending(order => order.Id)).FirstOrDefault();
                if (bill == null)
                {
                    res = ((int)branch) * 100000;
                }
                else
                {
                    res = bill.BillNumber + 1;
                }
            }
            return res;
        }

        public ErrorCode AddNewBillMain(int billNumber, int shift, int userId, int? customerId, string customerName, int persons, int services, string note,
                                        Branch branch, int serviceCharge, int rawTotal, int rawTotalDiscount, int voucher, int billDiscount,
                                        int finalTotal, int VAT, BillStatus status, out int billId)
        {
            ErrorCode res = ErrorCode.N_OK;
            billId = -1;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billService = new Repository<BillMain>(db);
                BillMain bill = new BillMain();
                bill.BillNumber = billNumber;
                bill.Shift = shift;
                bill.UserId = userId;
                bill.CustomerId = customerId;
                bill.CustomerName = customerName;
                bill.NumberOfPerson = persons;
                bill.NumberOfService = services;
                bill.USD = 0;
                bill.VND = 0;
                bill.Visa = 0;
                bill.Date = DateTime.Now;
                bill.Note = note;
                bill.Status = status;
                bill.Branch = branch;
                bill.ServiceCharge = serviceCharge;
                bill.RawTotal = rawTotal;
                bill.RawTotalDiscount = rawTotalDiscount;
                bill.Voucher = voucher;
                bill.BillDiscount = billDiscount;
                bill.FinalTotal = finalTotal;
                bill.VAT = VAT;
                billService.Insert(bill);
                if (billService.SaveChanges())
                {
                    billId = bill.Id;
                    res = ErrorCode.OK;
                }


            }

            return res;
        }

        public ErrorCode DeleteBillMain(int billNumber, bool IsRemoveFromDatabase)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billService = new Repository<BillMain>(db);
                IRepository<BillService> billServiceService = new Repository<BillService>(db);
                IRepository<BillPackage> billPackageService = new Repository<BillPackage>(db);
                BillMain bill = billService.Get(q => q.BillNumber == billNumber).FirstOrDefault();
                if (bill != null)
                {
                    if (IsRemoveFromDatabase == true)
                    {
                        for (int j = bill.BillServices.Count; j >= 0; j--)
                        {
                            billServiceService.Delete(bill.BillServices.ToList()[j], true);
                        }

                        for (int j = bill.BillPackages.Count; j >= 0; j--)
                        {
                            BillPackage billPackage = bill.BillPackages.ToList()[j];
                            for (int i = billPackage.BillServices.Count; i >= 0; i--)
                            {
                                billServiceService.Delete(billPackage.BillServices.ToList()[i], true);
                            }
                            billPackageService.Delete(billPackage, true);
                        }
                    }
                    billService.Delete(bill, IsRemoveFromDatabase);
                    if (billService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }
            return res;

        }

        public ErrorCode AddNewBillService(int? billMainId, int? billPackageId, int serviceId, int price, int qty, int serviceChargePercent,
                                           int? promotionId, int? promotionPercent, int? promotionVND,
                                           int? discountPercent, int? discountVND,
                                           int roomId, int roomChargePercent,
                                           int? customerId, int? customerDiscountPercent, int? customerDiscountVND, out int billServiceId)
        {
            ErrorCode res = ErrorCode.N_OK;
            billServiceId = -1;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillService> billServiceService = new Repository<BillService>(db);
                BillService billService = new BillService();
                billService.BillMainId = billMainId;
                billService.BillPackageId = billPackageId;
                billService.ServiceId = serviceId;
                billService.Price = price;
                billService.Qty = qty;
                billService.ServiceChargePercent = serviceChargePercent;
                billService.PromotionId = promotionId;
                billService.PromotionPercent = promotionPercent;
                billService.PromotionVND = promotionVND;
                billService.DiscountPercent = discountPercent;
                billService.DiscountVND = discountVND;
                billService.RoomId = roomId;
                billService.RoomChargePercent = roomChargePercent;
                billService.CustomerId = customerId;
                billService.CustomerDiscountPercent = customerDiscountPercent;
                billService.CustomerDiscountVND = customerDiscountVND;
                billServiceService.Insert(billService);
                if (billServiceService.SaveChanges())
                {
                    billServiceId = billService.Id;
                    res = ErrorCode.OK;
                }
            }
            return res;
        }

        public ErrorCode AddNewBillKTV(int billServiceId, int ktvId, int? chargePercent, int tour, bool? isCustomerOrder, bool? isCompanyOrder, out int billKTVId)
        {
            ErrorCode res = ErrorCode.N_OK;
            billKTVId = -1;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillKTV> billKTVService = new Repository<BillKTV>(db);
                BillKTV billKTV = new BillKTV();
                billKTV.BillServiceId = billServiceId;
                billKTV.PersonnelId = ktvId;
                billKTV.ChargePercent = chargePercent;
                billKTV.IsCompanyOrder = isCompanyOrder;
                billKTV.IsCustomerOrder = isCustomerOrder;
                billKTVService.Insert(billKTV);
                if (billKTVService.SaveChanges())
                {
                    billKTVId = billKTV.Id;
                    res = ErrorCode.OK;
                }
            }
            return res;
        }

        public ErrorCode AddNewBillDetail(string description, string code, string ktv, int price, int qty, int total, int discount, int billMainId)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                Repository<BillDetail> billDetailService = new Repository<BillDetail>(db);
                BillDetail detail = new BillDetail();
                detail.BillMainId = billMainId;
                detail.Description = description;
                detail.Code = code;
                detail.KTV = ktv;
                detail.Price = price;
                detail.Qty = qty;
                detail.Total = total;
                detail.Discount = discount;
                billDetailService.Insert(detail);
                if (billDetailService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }

            }
            return res;
        }

        public ErrorCode AddNewBillPackage(int billMainId, int packageId, int price, int qty, int serviceChargePercent,
                                           int? promotionId, int? promotionPercent, int? promotionVND,
                                           int? discountPercent, int? discountVND,
                                           int? customerId, int? customerDiscountPercent, int? customerDiscountVND, out int billPackageId)
        {
            ErrorCode res = ErrorCode.N_OK;
            billPackageId = 1;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillPackage> billPackageService = new Repository<BillPackage>(db);
                BillPackage billPackage = new BillPackage();
                billPackage.BillMainId = billMainId;
                billPackage.PackageId = packageId;
                billPackage.Price = price;
                billPackage.Qty = qty;
                billPackage.ServiceChargePercent = serviceChargePercent;
                billPackage.PromotionId = promotionId;
                billPackage.PromotionPercent = promotionPercent;
                billPackage.PromotionVND = promotionVND;
                billPackage.DiscountPercent = discountPercent;
                billPackage.DiscountVND = discountVND;
                billPackage.CustomerId = customerId;
                billPackage.CustomerDiscountPercent = customerDiscountPercent;
                billPackage.CustomerDiscountVND = customerDiscountVND;
                billPackageService.Insert(billPackage);
                if (billPackageService.SaveChanges())
                {
                    billPackageId = billPackage.Id;
                    res = ErrorCode.OK;
                }
            }

            return res;
        }

        public ErrorCode AddNewBillCertificate(int billMainId, int certificateId, int price,
                                               int? promotionId, int? promotionPercent, int? promotionVND,
                                               int? discountPercent, int? discountVND,
                                               int? customerId, List<int> series, out int billCertificateId)
        {
            ErrorCode res = ErrorCode.N_OK;
            billCertificateId = -1;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillCertificate> billCertificateService = new Repository<BillCertificate>(db);
                IRepository<CertificateSeri> certificateSeriService = new Repository<CertificateSeri>(db);
                BillCertificate billCertificate = new BillCertificate();
                billCertificate.CertificateSeries = new List<CertificateSeri>();
                billCertificate.BillMainId = billMainId;
                billCertificate.CertificateId = certificateId;
                billCertificate.Price = price;
                billCertificate.PromotionId = promotionId;
                billCertificate.PromotionPercent = promotionPercent;
                billCertificate.PromotionVND = promotionVND;
                billCertificate.DiscountPercent = discountPercent;
                billCertificate.DiscountVND = discountVND;
                billCertificate.CustomerId = customerId;
                foreach (int seri in series)
                {
                    CertificateSeri certificateSeri = certificateSeriService.Get(q => (q.Certificate.Id == certificateId) && (q.Seri == seri)).FirstOrDefault();
                    if (certificateSeri != null)
                    {
                        certificateSeri.BillCertificate = billCertificate;
                        certificateSeriService.Update(certificateSeri);
                    }
                }
                billCertificateService.Insert(billCertificate);
                if (billCertificateService.SaveChanges())
                {
                    billCertificateId = billCertificate.Id;
                    res = ErrorCode.OK;
                }

            }
            return res;
        }

        public ErrorCode AddNewBillOtherService(int billMainId, int otherServiceId, int price, int qty,
                                                int? promotionId, int? promotionPercent, int? promotionVND,
                                                int? discountPercent, int? discountVND,
                                                int? customerId, out int billOtherServiceId)
        {
            ErrorCode res = ErrorCode.N_OK;
            billOtherServiceId = -1;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillOtherService> billOthersService = new Repository<BillOtherService>(db);
                BillOtherService billOtherService = new BillOtherService();
                billOtherService.BillMainId = billMainId;
                billOtherService.OtherServiceId = otherServiceId;
                billOtherService.Price = price;
                billOtherService.Qty = qty;
                billOtherService.PromotionId = promotionId;
                billOtherService.PromotionPercent = promotionPercent;
                billOtherService.PromotionVND = promotionVND;
                billOtherService.DiscountPercent = discountPercent;
                billOtherService.DiscountVND = discountVND;
                billOtherService.CustomerId = customerId;
                billOthersService.Insert(billOtherService);
                if (billOthersService.SaveChanges())
                {
                    billOtherServiceId = billOtherService.Id;
                    res = ErrorCode.OK;
                }

            }
            return res;
        }

        public ErrorCode AddNewBillVoucherPayment(int billMainId, string certificateCode, int seri, int pay)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillVoucherPayment> billVoucherPaymentService = new Repository<BillVoucherPayment>(db);
                CertificateSeri certificateSeri = GetCertificateSeri(certificateCode, seri);

                BillVoucherPayment billVoucherPayment = new BillVoucherPayment();
                billVoucherPayment.BillMainId = billMainId;
                billVoucherPayment.CertificateSeriId = certificateSeri.Id;
                billVoucherPayment.Pay = pay;
                billVoucherPaymentService.Insert(billVoucherPayment);
                if (billVoucherPaymentService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }

            return res;
        }

        public ErrorCode UpdateBillPayment(int billNumber, int vnd, int usd, int visa)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billService = new Repository<BillMain>(db);
                BillMain bill = billService.Get(q => q.BillNumber == billNumber).FirstOrDefault();
                if (bill != null)
                {
                    bill.VND = vnd;
                    bill.USD = usd;
                    bill.Visa = visa;
                    int temp = bill.Voucher + bill.VND + bill.USD * GetExchangeRate() + bill.Visa - bill.FinalTotal;
                    if (temp >= 0) bill.Status = BillStatus.Payed;
                    else bill.Status = BillStatus.NotPayed;

                    if (billService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }
            return res;
        }

        public ErrorCode DestroyBill(int billNumber, string reason)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BillMain> billService = new Repository<BillMain>(db);
                BillMain bill = billService.Get(q => q.BillNumber == billNumber).FirstOrDefault();
                if (bill != null)
                {
                    bill.Status = BillStatus.Bad;
                    bill.DeleteBillReason = reason;
                    if (billService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }
            return res;
        }

        #endregion

        #region user
        private Dictionary<JobPosition, List<UserRole>> _PositionRole = new Dictionary<JobPosition, List<UserRole>>() 
        {
             {JobPosition.Accountant, new List<UserRole>() 
                                        {
                                            UserRole.AddNewBill,
                                        }},
             {JobPosition.Cashier, new List<UserRole>() 
                                        {
                                             UserRole.AddNewBill,
                                        }},
             {JobPosition.Director, new List<UserRole>() 
                                        {
                                             UserRole.AddNewBill,
                                        }},
             {JobPosition.KTV, new List<UserRole>() 
                                        {
                                            UserRole.ReadOnly,
                                        }},
             {JobPosition.ViceDirector, new List<UserRole>() 
                                        {
                                             UserRole.AddNewBill,
                                        }},
             {JobPosition.Manager, new List<UserRole>() 
                                        {
                                            UserRole.AddNewUser,
                                            UserRole.AddNewBill,
                                        }},
                                       
        };

        public ErrorCode AddNewUser(string fullName, string userName, string pass, JobPosition position, out User user)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                bool temp = false;
                IRepository<User> userService = new Repository<User>(db);
                user = null;
                if (userService.Get(q => q.Name == userName).Any())
                {
                    res = ErrorCode.EXISTED_NAME;
                }
                else
                {
                    user = new User();
                    user.FullName = fullName;
                    user.Name = userName;
                    user.Password = pass;
                    user.JobPosition = (int)position;
                    userService.Insert(user);
                    temp = userService.SaveChanges();
                    if (temp == true)
                    {
                        if (_PositionRole.ContainsKey(position))
                        {
                            if (_PositionRole[position].Count > 0)
                            {
                                IRepository<Role> roleService = new Repository<Role>(db);
                                foreach (UserRole role in _PositionRole[position])
                                {
                                    Role r = new Role();
                                    r.UserRole = role;
                                    r.UserId = user.Id;
                                    roleService.Insert(r);
                                }
                                temp = roleService.SaveChanges();
                                if (temp == true)
                                {
                                    res = ErrorCode.OK;
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode UpdateUser(int id, string fullName, string userName, string pass, JobPosition position)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<User> userService = new Repository<User>(db);
                IRepository<Role> roleService = new Repository<Role>(db);
                User user = userService.GetById(id);
                bool temp = false;
                if (user != null)
                {
                    user.Password = pass;
                    user.FullName = fullName;
                    if (user.JobPosition != (int)position)
                    {
                        user.JobPosition = (int)position;
                        foreach (Role role in user.Roles)
                        {
                            roleService.Delete(role.Id);
                        }
                        temp = userService.SaveChanges();
                        if (temp == true)
                        {

                            if (_PositionRole.ContainsKey(position))
                            {
                                if (_PositionRole[position].Count > 0)
                                {
                                    foreach (UserRole role in _PositionRole[position])
                                    {
                                        Role r = new Role();
                                        r.UserRole = role;
                                        r.UserId = user.Id;
                                        roleService.Insert(r);
                                    }
                                    temp = roleService.SaveChanges();
                                }
                            }

                        }
                    }
                    else
                    {
                        temp = userService.SaveChanges();
                    }

                }
                if (temp) res = ErrorCode.OK;
            }
            return res;
        }
        public ErrorCode DeleteUser(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<User> userService = new Repository<User>(db);
                userService.Delete(id);
                if (userService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public List<User> GetUsers()
        {
            List<User> res = new List<User>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<User> userService = new Repository<User>(db);
                res = userService.GetAll().ToList();
            }
            return res;
        }
        public User GetUser(string userName, string pass)
        {
            User res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<User> userService = new Repository<User>(db);
                res = userService.Get(q => (q.Name == userName) && (q.Password == pass)).FirstOrDefault();
            }
            return res;
        }

        public ErrorCode ChangePassword(string userName, string oldPassword, string newPassword)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<User> userService = new Repository<User>(db);
                User user = userService.Get(q => (q.Name == userName) && (q.Password == oldPassword)).FirstOrDefault();
                if (user != null)
                {
                    user.Password = newPassword;
                    if (userService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }
            return res;
        }
        #endregion

        #region data
        public ErrorCode UpdateSystemData(string mailDatabase, string mailBill, string backupFolder, int period)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<SystemData> dataService = new Repository<SystemData>(db);
                SystemData dt;
                if (dataService.Table.Count() == 0)
                {
                    dt = new SystemData();
                    dt.MailDB = mailDatabase;
                    dt.MailBill = mailBill;
                    dt.BackupFolder = backupFolder;
                    dt.Period = period;
                    dataService.Insert(dt);
                }
                else
                {
                    dt = dataService.Table.FirstOrDefault();
                    dt.MailDB = mailDatabase;
                    dt.MailBill = mailBill;
                    dt.BackupFolder = backupFolder;
                    dt.Period = period;
                    dataService.Update(dt);
                }
                if (dataService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public string GetBackupFolder()
        {
            string res = "";
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<SystemData> dataService = new Repository<SystemData>(db);
                if (dataService.Table.Count() > 0)
                {
                    res = dataService.Table.FirstOrDefault().BackupFolder;
                }
            }
            return res;
        }
        public string GetEmailDatabase()
        {
            string res = "";
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<SystemData> dataService = new Repository<SystemData>(db);
                if (dataService.Table.Count() > 0)
                {
                    res = dataService.Table.FirstOrDefault().MailDB;
                }
            }
            return res;
        }
        public string GetEmailBill()
        {
            string res = "";
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<SystemData> dataService = new Repository<SystemData>(db);
                if (dataService.Table.Count() > 0)
                {
                    res = dataService.Table.FirstOrDefault().MailBill;
                }
            }
            return res;
        }
        public int GetBackupPeriod()
        {
            int res = 0;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<SystemData> dataService = new Repository<SystemData>(db);
                if (dataService.Table.Count() > 0)
                {
                    res = dataService.Table.FirstOrDefault().Period;
                }
            }
            return res;
        }
        public SystemData GetSystemData()
        {
            SystemData res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<SystemData> dataService = new Repository<SystemData>(db);
                res = dataService.Table.FirstOrDefault();
            }
            return res;
        }
        #endregion

        #region supplier
        public ErrorCode AddNewSupplier(string supplierName, string code, string contactPerson, string phone, string accountNumber, string address, out Supplier sup)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Supplier> supplierService = new Repository<Supplier>(db);
                sup = null;
                if (supplierService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else
                {
                    sup = new Supplier();
                    sup.AccountNumber = accountNumber;
                    sup.Address = address;
                    sup.Code = code;
                    sup.ContactPerson = contactPerson;
                    sup.Name = supplierName;
                    sup.Phone = phone;
                    supplierService.Insert(sup);
                    if (supplierService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateSupplier(int id, string supplierName, string code, string contactPerson, string phone, string accountNumber, string address)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Supplier> supplierService = new Repository<Supplier>(db);
                Supplier sup = supplierService.GetById(id);
                bool temp = true;
                if (sup != null)
                {
                    if (sup.Code != code)
                    {
                        if (supplierService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        sup.Name = supplierName;
                        sup.Code = code;
                        sup.ContactPerson = contactPerson;
                        sup.AccountNumber = accountNumber;
                        sup.Phone = phone;
                        sup.Address = address;
                        supplierService.Update(sup);
                        if (supplierService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteSupplier(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Supplier> supplierService = new Repository<Supplier>(db);
                supplierService.Delete(id);
                if (supplierService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Supplier GetSupplier(int id)
        {
            Supplier res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Supplier> supplierService = new Repository<Supplier>(db);
                res = supplierService.GetById(id);
            }
            return res;
        }
        public List<Supplier> GetSuppliers()
        {
            List<Supplier> res = new List<Supplier>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Supplier> supplierService = new Repository<Supplier>(db);
                res = supplierService.GetAll().ToList();
            }
            return res;
        }
        #endregion

        #region warehouse
        public ErrorCode AddNewWarehouse(string warehouseName, string code, ServiceType warehouseType, out Warehouse warehouse)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);
                warehouse = null;
                if (warehouseService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else if (warehouseService.Get(q => q.Name == warehouseName).Any())
                {
                    res = ErrorCode.EXISTED_NAME;
                }
                else
                {
                    warehouse = new Warehouse();
                    warehouse.Name = warehouseName;
                    warehouse.Code = code;
                    warehouse.WarehouseType = warehouseType;
                    warehouseService.Insert(warehouse);
                    if (warehouseService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }

            }

            return res;
        }
        public ErrorCode UpdateWarehouse(int id, string warehouseName, string code, ServiceType warehouseType)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);
                Warehouse warehouse = warehouseService.GetById(id);
                if (warehouse != null)
                {
                    bool temp = true;
                    if (warehouse.Code != code)
                    {
                        if (warehouseService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if ((temp == true) && (warehouse.Name != warehouseName))
                    {
                        if (warehouseService.Get(q => q.Name == warehouseName).Any())
                        {
                            res = ErrorCode.EXISTED_NAME;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        warehouse.Name = warehouseName;
                        warehouse.Code = code;
                        warehouse.WarehouseType = warehouseType;
                        warehouseService.Update(warehouse);
                        if (warehouseService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }

                }
            }

            return res;
        }
        public ErrorCode DeleteWarehouse(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);
                warehouseService.Delete(id);
                if (warehouseService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }

            }
            return res;
        }
        public List<Warehouse> GetWarehouses()
        {
            List<Warehouse> res = new List<Warehouse>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);
                res = warehouseService.GetAll().ToList();
            }
            return res;
        }
        public Warehouse GetWarehouse(int id)
        {
            Warehouse res = new Warehouse();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);
                res = warehouseService.GetById(id);
            }
            return res;
        }


        #endregion

        #region service
        public ErrorCode AddNewService(string name, string code, int price, int tour, out Service service, int numberOfKTVNeeded = 1)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Service> serviceService = new Repository<Service>(db);
                service = null;
                if (serviceService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else
                {
                    service = new Service();
                    service.Name = name;
                    service.Code = code;
                    service.Price = price;
                    service.Tour = tour;
                    service.NumberOfKTVNeeded = numberOfKTVNeeded;
                    serviceService.Insert(service);
                    if (serviceService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateService(int id, string name, string code, int price, int tour)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Service> serviceService = new Repository<Service>(db);
                Service service = serviceService.GetById(id);
                bool temp = true;
                if (service != null)
                {
                    if (service.Code != code)
                    {
                        if (serviceService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        service.Name = name;
                        service.Code = code;
                        service.Price = price;
                        service.Tour = tour;
                        serviceService.Update(service);
                        if (serviceService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteService(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Service> serviceService = new Repository<Service>(db);
                serviceService.Delete(id);
                if (serviceService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Service GetService(int id)
        {
            Service res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Service> serviceService = new Repository<Service>(db);
                res = serviceService.GetById(id);
            }
            return res;
        }
        public List<Service> GetServices()
        {
            List<Service> res = new List<Service>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Service> serviceService = new Repository<Service>(db);
                res = serviceService.Get(null, null, "Personnels").ToList();
            }
            return res;
        }
        public List<Service> GetServices(string packageCode)
        {
            List<Service> res = new List<Service>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                Package package = packageService.Get(q => q.Code == packageCode).FirstOrDefault();
                if (package != null)
                {
                    res = package.Services.ToList();
                }
            }
            return res;
        }

        #endregion

        #region package
        public ErrorCode AddNewPackage(string name, string code, int price, out Package package)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                package = null;
                if (packageService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else
                {
                    package = new Package();
                    package.Name = name;
                    package.Code = code;
                    package.Price = price;
                    packageService.Insert(package);
                    if (packageService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdatePackage(int id, string name, string code, int price)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                Package package = packageService.GetById(id);
                bool temp = true;
                if (package != null)
                {
                    if (package.Code != code)
                    {
                        if (packageService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        package.Name = name;
                        package.Code = code;
                        package.Price = price;
                        packageService.Update(package);
                        if (packageService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeletePackage(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                packageService.Delete(id);
                if (packageService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Package GetPackage(int id)
        {
            Package res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                res = packageService.Get(q => q.Id == id, null, "Services").FirstOrDefault();
            }
            return res;
        }
        public List<Package> GetPackages()
        {
            List<Package> res = new List<Package>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                res = packageService.Get(null, null, "Services").ToList();
            }
            return res;
        }
        public ErrorCode AddServiceToPackage(int packageId, string serviceCode, out Service service)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                IRepository<Service> serviceService = new Repository<Service>(db);
                service = null;
                Package package = packageService.GetById(packageId);
                bool temp = true;
                if (package != null)
                {
                    service = serviceService.Get(q => q.Code == serviceCode).FirstOrDefault();
                    if (service != null)
                    {
                        if (package.Services == null)
                        {
                            package.Services = new List<Service>();
                        }

                        if (package.Services.Contains(service))
                        {
                            res = ErrorCode.EXISTED_SERVICE;
                            temp = false;
                        }

                        if (temp == true)
                        {
                            package.Services.Add(service);
                            if (packageService.SaveChanges())
                            {
                                res = ErrorCode.OK;
                            }
                        }

                    }
                }

            }
            return res;
        }
        public ErrorCode RemoveServiceFromPackage(int packageId, int serviceId)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Package> packageService = new Repository<Package>(db);
                IRepository<Service> serviceService = new Repository<Service>(db);
                Service service = null;
                Package package = packageService.GetById(packageId);

                if (package != null)
                {
                    service = serviceService.GetById(serviceId);
                    if (service != null)
                    {
                        if (package.Services != null)
                        {
                            if (package.Services.Contains(service))
                            {
                                package.Services.Remove(service);
                                if (packageService.SaveChanges())
                                {
                                    res = ErrorCode.OK;
                                }
                            }
                        }
                    }
                }

            }
            return res;

        }


        #endregion

        #region certificate
        public ErrorCode AddNewCertificate(string name, string code, int price, int duration, out Certificate certificate)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                certificate = null;
                if (cerService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else
                {
                    certificate = new Certificate();
                    certificate.Name = name;
                    certificate.Code = code;
                    certificate.Price = price;
                    certificate.Duration = duration;
                    cerService.Insert(certificate);
                    if (cerService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateCertificate(int id, string name, string code, int price, int duration)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                Certificate certificate = cerService.GetById(id);
                bool temp = true;
                if (certificate != null)
                {
                    if (certificate.Code != code)
                    {
                        if (cerService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        certificate.Name = name;
                        certificate.Code = code;
                        certificate.Price = price;
                        certificate.Duration = duration;
                        cerService.Update(certificate);
                        if (cerService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteCertificate(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                cerService.Delete(id);
                if (cerService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Certificate GetCertificate(int id)
        {
            Certificate res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                res = cerService.Get(q => q.Id == id, null, "Inventories.Warehouse,CertificateSeries.BillCertificate.BillMain,CertificateSeries.BillVoucherPayments.BillMain").FirstOrDefault();
            }
            return res;
        }
        public List<Certificate> GetCertificates()
        {
            List<Certificate> res = new List<Certificate>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                res = cerService.Get(null, null, "Inventories.Warehouse,CertificateSeries.BillCertificate.BillMain,CertificateSeries.BillVoucherPayments.BillMain").ToList();
            }
            return res;
        }
        public List<Certificate> GetCertificates(CertificateStatus status)
        {
            List<Certificate> res = new List<Certificate>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                var query = from q in cerService.Table
                            where
                            (
                              (from q1 in q.CertificateSeries
                               where q1.Status == status
                               select q1).Any()
                            )
                            select q;
                res = query.ToList();
            }
            return res;
        }
        public Dictionary<Certificate, int> GetCertificates(string warehouseName)
        {
            Dictionary<Certificate, int> res = new Dictionary<Certificate, int>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                IRepository<Inventory> inventoryService = new Repository<Inventory>(db);
                List<Certificate> cers = GetCertificates();
                for (int j = cers.Count - 1; j >= 0; j--)
                {
                    Certificate cer = cers[j];
                    Inventory inv = (inventoryService.Get(q => (q.Certificate.Code == cer.Code) && (q.Warehouse.Name == warehouseName))).OrderByDescending(q => q.Id).FirstOrDefault();
                    if ((inv == null) || inv.Quantity <= 0)
                    {
                        cers.Remove(cer);
                    }
                    else
                    {
                        res.Add(cer, inv.Quantity);
                    }
                }
            }
            return res;
        }
        public ErrorCode AddNewCertificateSeri(string certificateCode, int seri, out CertificateSeri certificateSeri)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                IRepository<CertificateSeri> cerSeriService = new Repository<CertificateSeri>(db);

                certificateSeri = null;
                Certificate certificate = cerService.Get(q => q.Code == certificateCode).FirstOrDefault();
                if (certificate != null)
                {
                    certificateSeri = new CertificateSeri();
                    certificateSeri.CertificateId = certificate.Id;
                    certificateSeri.Seri = seri;
                    cerSeriService.Insert(certificateSeri);
                    if (cerSeriService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode AddNewCertificateSeries(string certificateCode, List<int> series, out List<CertificateSeri> certificateSeries)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Certificate> cerService = new Repository<Certificate>(db);
                IRepository<CertificateSeri> cerSeriService = new Repository<CertificateSeri>(db);

                certificateSeries = new List<CertificateSeri>();
                Certificate certificate = cerService.Get(q => q.Code == certificateCode).FirstOrDefault();
                if (certificate != null)
                {
                    for (int j = 0; j < series.Count; j++)
                    {
                        CertificateSeri certificateSeri = new CertificateSeri();
                        certificateSeri.CertificateId = certificate.Id;
                        certificateSeri.Seri = series[j];
                        cerSeriService.Insert(certificateSeri);
                        certificateSeries.Add(certificateSeri);
                    }

                    if (cerSeriService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }

        public CertificateSeri GetCertificateSeri(string certificateCode, int seri)
        {
            CertificateSeri res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<CertificateSeri> certificateSeriService = new Repository<CertificateSeri>(db);
                res = certificateSeriService.Get(q => (q.Certificate.Code == certificateCode) && (q.Seri == seri), null, "Certificate").FirstOrDefault();
            }
            return res;
        }
        #endregion

        #region other services
        public ErrorCode AddNewOtherService(string name, string code, int price, out OtherService otherService)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<OtherService> othersService = new Repository<OtherService>(db);
                otherService = null;
                if (othersService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else
                {
                    otherService = new OtherService();
                    otherService.Name = name;
                    otherService.Code = code;
                    otherService.Price = price;
                    othersService.Insert(otherService);
                    if (othersService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateOtherService(int id, string name, string code, int price)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<OtherService> othersService = new Repository<OtherService>(db);
                OtherService other = othersService.GetById(id);
                bool temp = true;
                if (other != null)
                {
                    if (other.Code != code)
                    {
                        if (othersService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        other.Name = name;
                        other.Code = code;
                        other.Price = price;
                        othersService.Update(other);
                        if (othersService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteOtherService(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<OtherService> othersService = new Repository<OtherService>(db);
                othersService.Delete(id);
                if (othersService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public OtherService GetOtherService(int id)
        {
            OtherService res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<OtherService> othersService = new Repository<OtherService>(db);
                res = othersService.GetById(id);
            }
            return res;
        }
        public List<OtherService> GetOtherServices()
        {
            List<OtherService> res = new List<OtherService>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<OtherService> othersService = new Repository<OtherService>(db);
                res = othersService.GetAll().ToList();
            }
            return res;
        }
        public Dictionary<OtherService, int> GetOtherServices(string warehouseName)
        {
            Dictionary<OtherService, int> res = new Dictionary<OtherService, int>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<OtherService> othersService = new Repository<OtherService>(db);
                IRepository<Inventory> inventoryService = new Repository<Inventory>(db);
                List<OtherService> others = GetOtherServices();
                for (int j = others.Count - 1; j >= 0; j--)
                {
                    OtherService other = others[j];
                    Inventory inv = (inventoryService.Get(q => (q.OtherService.Code == other.Code) && (q.Warehouse.Name == warehouseName))).OrderByDescending(q => q.Id).FirstOrDefault();
                    if ((inv == null) || inv.Quantity <= 0)
                    {
                        others.Remove(other);
                    }
                    else
                    {
                        res.Add(other, inv.Quantity);
                    }
                }
            }
            return res;
        }
        #endregion

        #region room
        public ErrorCode AddNewRoom(string name, string code, int charge, Branch branch, out Room room)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Room> roomService = new Repository<Room>(db);
                room = null;
                if (roomService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else
                {
                    room = new Room();
                    room.Name = name;
                    room.Code = code;
                    room.Branch = branch;
                    room.Charge = charge;
                    roomService.Insert(room);
                    if (roomService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateRoom(int id, string name, string code, int charge, Branch branch)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Room> roomService = new Repository<Room>(db);
                Room room = roomService.GetById(id);
                bool temp = true;
                if (room != null)
                {
                    if (room.Code != code)
                    {
                        if (roomService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        room.Name = name;
                        room.Charge = charge;
                        room.Code = code;
                        room.Branch = branch;
                        roomService.Update(room);
                        if (roomService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteRoom(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Room> roomService = new Repository<Room>(db);
                roomService.Delete(id);
                if (roomService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Room GetRoom(int id)
        {
            Room res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Room> roomService = new Repository<Room>(db);
                res = roomService.GetById(id);
                res.Beds = res.Beds.Where(q => q.IsActive == true).ToList();
            }
            return res;
        }
        public List<Room> GetRooms()
        {
            List<Room> res = new List<Room>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Room> roomService = new Repository<Room>(db);
                res = roomService.GetAll().ToList();
            }
            return res;
        }

        public List<Room> GetRooms(Branch branch)
        {
            List<Room> res = new List<Room>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Room> roomService = new Repository<Room>(db);
                res = roomService.Get(q => q.Branch == branch).ToList();
            }
            return res;
        }
        #endregion

        #region bed
        public ErrorCode AddNewBed(string roomCode, int bedId, out Bed bed)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Room> roomService = new Repository<Room>(db);
                bed = null;
                Room room = roomService.Get(q => q.Code == roomCode).FirstOrDefault();
                if (room != null)
                {
                    IRepository<Bed> bedService = new Repository<Bed>(db);
                    if (bedService.Get(q => (q.Room.Code == roomCode) && (q.BedId == bedId)).Any())
                    {
                        res = ErrorCode.EXISTED_BED;
                    }
                    else
                    {
                        bed = new Bed();
                        bed.BedId = bedId;
                        bed.RoomId = room.Id;
                        bedService.Insert(bed);
                        if (bedService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }

                }

            }

            return res;
        }
        public ErrorCode DeleteBed(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Bed> bedService = new Repository<Bed>(db);
                bedService.Delete(id);
                if (bedService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Bed GetBed(int id)
        {
            Bed res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Bed> roomService = new Repository<Bed>(db);
                res = roomService.GetById(id);
            }
            return res;
        }
        public Bed GetBed(string roomName, Branch branch, int bedId)
        {
            Bed res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Bed> bedService = new Repository<Bed>(db);
                res = bedService.Get(q => (q.Room.Name == roomName) && (q.Room.Branch == branch) && (q.BedId == bedId)).FirstOrDefault();
            }
            return res;
        }
        public List<Bed> GetBeds(int roomID)
        {
            List<Bed> res = new List<Bed>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Bed> bedService = new Repository<Bed>(db);
                res = bedService.Get(q => q.RoomId == roomID).ToList();
            }
            return res;
        }
        #endregion

        #region bed transaction
        public ErrorCode AddNewBedTransaction(string roomName, Branch branch, int bedId, DateTime startTime, int duration, string serviceCode, List<string> ktvCodes, out BedTransaction bedTransaction)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BedTransaction> bedTransactionService = new Repository<BedTransaction>(db);
                IRepository<Bed> bedService = new Repository<Bed>(db);
                bedTransaction = null;
                Bed bed = bedService.Get(q => (q.Room.Name == roomName) && (q.Room.Branch == branch) && (q.BedId == bedId)).FirstOrDefault();
                if (bed != null)
                {
                    bedTransaction = new BedTransaction();
                    bedTransaction.Bed = bed;
                    bedTransaction.StartTime = startTime;
                    bedTransaction.Duration = duration;
                    bedTransaction.KTVs = new List<Personnel>();

                    IRepository<Service> serviceService = new Repository<Service>(db);
                    Service service = serviceService.Get(q => q.Code == q.Code).FirstOrDefault();
                    bedTransaction.Service = service;

                    IRepository<Personnel> personelService = new Repository<Personnel>(db);
                    foreach (string ktvCode in ktvCodes)
                    {
                        Personnel ktv = personelService.Get(q => q.Code == ktvCode).FirstOrDefault();
                        bedTransaction.KTVs.Add(ktv);
                    }

                    bedTransactionService.Insert(bedTransaction);
                    if (bedTransactionService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }

        public ErrorCode StopBedTransaction(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BedTransaction> bedTransactionService = new Repository<BedTransaction>(db);
                bedTransactionService.Delete(id);
                if (bedTransactionService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;

        }

        public BedTransaction GetCurrentBedTransacation(string roomName, Branch branch, int bedId)
        {
            BedTransaction res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BedTransaction> bedTransactionService = new Repository<BedTransaction>(db);
                res = bedTransactionService.Get(q => (q.Bed.Room.Name == roomName) && (q.Bed.Room.Branch == branch) && (q.Bed.BedId == bedId), q => q.OrderByDescending(order => order.Id), "Bed.Room,Service,KTVs").FirstOrDefault();
            }
            return res;
        }

        public void FixBadBedTransaction()
        {
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<BedTransaction> bedTransactionService = new Repository<BedTransaction>(db);
                var query = bedTransactionService.GetAll();
                foreach (BedTransaction trans in query.ToList())
                {
                    DateTime startTime = trans.StartTime;
                    DateTime endTime = trans.StartTime.AddMinutes(trans.Duration);
                    DateTime now = DateTime.Now;

                    if ((now < startTime) || (now > endTime))
                    {
                        trans.IsActive = false; // deactive this row in database
                    }
                }
                db.SaveChanges();
            }
        }
        #endregion

        #region currency
        public ErrorCode UpdateCurrency(int exchangeRate)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Currency> currencyService = new Repository<Currency>(db);
                Currency cur = null;
                if (currencyService.Table.Count() == 0)
                {
                    cur = new Currency();
                    cur.ExchangeRate = exchangeRate;
                    currencyService.Insert(cur);
                }
                else
                {
                    cur = currencyService.Table.FirstOrDefault();
                    cur.ExchangeRate = exchangeRate;
                    currencyService.Update(cur);
                }
                if (currencyService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public int GetExchangeRate()
        {
            int res = 0;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Currency> currencyService = new Repository<Currency>(db);
                if (currencyService.Table.Count() > 0)
                {
                    res = currencyService.Table.FirstOrDefault().ExchangeRate;
                }
            }
            return res;
        }
        #endregion

        #region promotion
        public ErrorCode AddNewPromotion(string name, string code, int discount, bool isPercent, PromotionCondition type, DateTime? issueDate, DateTime? expiryDate, DateTime? startTime, DateTime? stopTime, string note, out Promotion promotion)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Promotion> promotionService = new Repository<Promotion>(db);
                promotion = null;
                if (promotionService.Get(q => q.Code == code).Any())
                {
                    res = ErrorCode.EXISTED_CODE;
                }
                else
                {
                    promotion = new Promotion();
                    promotion.Name = name;
                    promotion.Code = code;
                    promotion.Type = type;
                    promotion.Discount = discount;
                    promotion.IsPercent = isPercent;
                    promotion.IssueDate = issueDate;
                    promotion.ExpiryDate = expiryDate;
                    promotion.StartTime = startTime;
                    promotion.StopTime = stopTime;
                    promotion.Note = note;
                    promotionService.Insert(promotion);
                    if (promotionService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdatePromotion(int id, string name, string code, int discount, bool isPercent, PromotionCondition type, DateTime? issueDate, DateTime? expiryDate, DateTime? startTime, DateTime? stopTime, string note)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Promotion> promotionService = new Repository<Promotion>(db);
                Promotion promotion = promotionService.GetById(id);
                bool temp = true;
                if (promotion != null)
                {
                    if (promotion.Code != code)
                    {
                        if (promotionService.Get(q => q.Code == code).Any())
                        {
                            res = ErrorCode.EXISTED_CODE;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        promotion.Name = name;
                        promotion.Code = code;
                        promotion.Discount = discount;
                        promotion.IsPercent = isPercent;
                        promotion.Type = type;
                        promotion.IssueDate = issueDate;
                        promotion.ExpiryDate = expiryDate;
                        promotion.StartTime = startTime;
                        promotion.StopTime = stopTime;
                        promotion.Note = note;
                        promotionService.Update(promotion);
                        if (promotionService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeletePromotion(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Promotion> promotionService = new Repository<Promotion>(db);
                promotionService.Delete(id);
                if (promotionService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Promotion GetPromotion(int id)
        {
            Promotion res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Promotion> promotionService = new Repository<Promotion>(db);
                res = promotionService.Get(q => q.Id == id).FirstOrDefault();
            }
            return res;
        }
        public List<Promotion> GetPromotions()
        {
            List<Promotion> res = new List<Promotion>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Promotion> promotionService = new Repository<Promotion>(db);
                res = promotionService.GetAll().ToList();
            }
            return res;
        }
        public List<Promotion> GetCurrentPromotion()
        {
            List<Promotion> res = new List<Promotion>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Promotion> promotionService = new Repository<Promotion>(db);
                DateTime currentMoment = DateTime.Now;
                res = promotionService.Get(q => (q.Type == PromotionCondition.NoCondition)
                                                || ((q.Type == PromotionCondition.ByDate) && (q.IssueDate.Value <= currentMoment) && (q.ExpiryDate.Value >= currentMoment))
                                                || ((q.Type == PromotionCondition.ByTime) && ((q.StartTime.Value.Hour < currentMoment.Hour) || ((q.StartTime.Value.Hour == currentMoment.Hour) && (q.StartTime.Value.Minute <= currentMoment.Minute)))
                                                                                          && ((q.StopTime.Value.Hour > currentMoment.Hour) || ((q.StopTime.Value.Hour == currentMoment.Hour) && (q.StopTime.Value.Minute >= currentMoment.Minute))))
                                          ).ToList();
            }
            return res;
        }

        #endregion

        #region job
        public ErrorCode AddNewJob(string name, int discount, bool percent, out Job job)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Job> jobService = new Repository<Job>(db);
                job = null;
                if (jobService.Get(q => q.Name == name).Any())
                {
                    res = ErrorCode.EXISTED_NAME;
                }
                else
                {
                    job = new Job();
                    job.Name = name;
                    job.Discount = discount;
                    job.Percent = percent;
                    jobService.Insert(job);
                    if (jobService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateJob(int id, string name, int discount, bool percent)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Job> jobService = new Repository<Job>(db);
                Job job = jobService.GetById(id);
                bool temp = true;
                if (job != null)
                {
                    if (job.Name != name)
                    {
                        if (jobService.Get(q => q.Name == name).Any())
                        {
                            res = ErrorCode.EXISTED_NAME;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        job.Name = name;
                        job.Discount = discount;
                        job.Percent = percent;
                        jobService.Update(job);
                        if (jobService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteJob(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Job> jobService = new Repository<Job>(db);
                jobService.Delete(id);
                if (jobService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Job GetJob(int id)
        {
            Job res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Job> jobService = new Repository<Job>(db);
                res = jobService.GetById(id);
            }
            return res;
        }
        public List<Job> GetJobs()
        {
            List<Job> res = new List<Job>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Job> jobService = new Repository<Job>(db);
                res = jobService.GetAll().ToList();
            }
            return res;
        }
        #endregion

        #region nationality
        public ErrorCode AddNewNationality(string name, int discount, bool percent, out Nationality nationality)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Nationality> nationalityService = new Repository<Nationality>(db);
                nationality = null;
                if (nationalityService.Get(q => q.Name == name).Any())
                {
                    res = ErrorCode.EXISTED_NAME;
                }
                else
                {
                    nationality = new Nationality();
                    nationality.Name = name;
                    nationality.Discount = discount;
                    nationality.Percent = percent;
                    nationalityService.Insert(nationality);
                    if (nationalityService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateNationality(int id, string name, int discount, bool percent)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Nationality> nationalityService = new Repository<Nationality>(db);
                Nationality nationality = nationalityService.GetById(id);
                bool temp = true;
                if (nationality != null)
                {
                    if (nationality.Name != name)
                    {
                        if (nationalityService.Get(q => q.Name == name).Any())
                        {
                            res = ErrorCode.EXISTED_NAME;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        nationality.Name = name;
                        nationality.Discount = discount;
                        nationality.Percent = percent;
                        nationalityService.Update(nationality);
                        if (nationalityService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteNationality(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Nationality> nationalityService = new Repository<Nationality>(db);
                nationalityService.Delete(id);
                if (nationalityService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Nationality GetNationality(int id)
        {
            Nationality res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Nationality> nationalityService = new Repository<Nationality>(db);
                res = nationalityService.GetById(id);
            }
            return res;
        }
        public List<Nationality> GetNationlities()
        {
            List<Nationality> res = new List<Nationality>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Nationality> nationalityService = new Repository<Nationality>(db);
                res = nationalityService.GetAll().ToList();
            }
            return res;
        }
        #endregion

        #region member
        public ErrorCode AddNewMember(string name, int discount, bool percent, out Member member)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Member> memberService = new Repository<Member>(db);
                member = null;
                if (memberService.Get(q => q.Name == name).Any())
                {
                    res = ErrorCode.EXISTED_NAME;
                }
                else
                {
                    member = new Member();
                    member.Name = name;
                    member.Discount = discount;
                    member.Percent = percent;
                    memberService.Insert(member);
                    if (memberService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }

            return res;
        }
        public ErrorCode UpdateMember(int id, string name, int discount, bool percent)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Member> memberService = new Repository<Member>(db);
                Member member = memberService.GetById(id);
                bool temp = true;
                if (member != null)
                {
                    if (member.Name != name)
                    {
                        if (memberService.Get(q => q.Name == name).Any())
                        {
                            res = ErrorCode.EXISTED_NAME;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        member.Name = name;
                        member.Discount = discount;
                        member.Percent = percent;
                        memberService.Update(member);
                        if (memberService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteMember(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Member> memberService = new Repository<Member>(db);
                memberService.Delete(id);
                if (memberService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Member GetMember(int id)
        {
            Member res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Member> memberService = new Repository<Member>(db);
                res = memberService.GetById(id);
            }
            return res;
        }
        public List<Member> GetMembers()
        {
            List<Member> res = new List<Member>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Member> memberService = new Repository<Member>(db);
                res = memberService.GetAll().ToList();
            }
            return res;
        }
        #endregion

        #region vip setting
        public ErrorCode UpdateVIPSetting(int visit, int account)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<VIPSetting> vipService = new Repository<VIPSetting>(db);
                VIPSetting vip = null;
                if (vipService.Table.Count() == 0)
                {
                    vip = new VIPSetting();
                    vip.Visit = visit;
                    vip.Account = account;
                    vipService.Insert(vip);
                }
                else
                {
                    vip = vipService.Table.FirstOrDefault();
                    vip.Visit = visit;
                    vip.Account = account;
                    vipService.Update(vip);
                }
                if (vipService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public VIPSetting GetVIPSetting()
        {
            VIPSetting res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<VIPSetting> vipService = new Repository<VIPSetting>(db);
                if (vipService.Table.Count() > 0)
                {
                    res = vipService.Table.FirstOrDefault();
                }
            }
            return res;
        }
        #endregion

        #region customer
        public ErrorCode AddNewCustomer(string name, string memberCardSeri, Gender gender, DateTime DOB, string phone, string email, string company, string address, string taxNumber, string jobName, string nationalityName, string memberName, out Customer customer)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Customer> customerService = new Repository<Customer>(db);
                customer = null;
                if (customerService.Get(q => q.MemberCardSeri == memberCardSeri).Any())
                {
                    res = ErrorCode.EXISTED_MEMBERCARDSERI;
                }
                else
                {
                    customer = new Customer();
                    customer.Name = name;
                    customer.Code = GetNewCustomerCode();
                    customer.Gender = gender;
                    customer.DOB = DOB;
                    customer.Phone = phone;
                    customer.Email = email;
                    customer.Company = company;
                    customer.Address = address;
                    customer.TaxNumber = taxNumber;

                    IRepository<Job> jobService = new Repository<Job>(db);
                    IRepository<Nationality> nationalityService = new Repository<Nationality>(db);
                    IRepository<Member> memberService = new Repository<Member>(db);

                    Job job = jobService.Get(q => q.Name == jobName).FirstOrDefault();
                    if (job != null)
                    {
                        customer.JobId = job.Id;
                    }

                    Nationality nationality = nationalityService.Get(q => q.Name == nationalityName).FirstOrDefault();
                    if (nationality != null)
                    {
                        customer.NationalityId = nationality.Id;
                    }

                    Member member = memberService.Get(q => q.Name == memberName).FirstOrDefault();
                    if (member != null)
                    {
                        customer.MemberId = member.Id;
                        customer.MemberCardSeri = memberCardSeri;
                    }

                    customerService.Insert(customer);

                    if (customerService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }

            }

            return res;
        }
        public ErrorCode UpdateCustomer(int id, string name, string memberCardSeri, Gender gender, DateTime DOB, string phone, string email, string company, string address, string taxNumber, string jobName, string nationalityName, string memberName)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Customer> customerService = new Repository<Customer>(db);
                Customer customer = customerService.GetById(id);

                if (customer != null)
                {
                    bool temp = true;
                    if (customer.MemberCardSeri != memberCardSeri)
                    {
                        if (customerService.Get(q => q.MemberCardSeri == memberCardSeri).Any())
                        {
                            res = ErrorCode.EXISTED_MEMBERCARDSERI;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        customer.Name = name;
                        customer.Gender = gender;
                        customer.DOB = DOB;
                        customer.Phone = phone;
                        customer.Email = email;
                        customer.Company = company;
                        customer.Address = address;
                        customer.TaxNumber = taxNumber;

                        IRepository<Job> jobService = new Repository<Job>(db);
                        IRepository<Nationality> nationalityService = new Repository<Nationality>(db);
                        IRepository<Member> memberService = new Repository<Member>(db);

                        Job job = jobService.Get(q => q.Name == jobName).FirstOrDefault();
                        if (job != null)
                        {
                            customer.JobId = job.Id;
                        }

                        Nationality nationality = nationalityService.Get(q => q.Name == nationalityName).FirstOrDefault();
                        if (nationality != null)
                        {
                            customer.NationalityId = nationality.Id;
                        }

                        Member member = memberService.Get(q => q.Name == memberName).FirstOrDefault();
                        if (member != null)
                        {
                            customer.MemberId = member.Id;
                            customer.MemberCardSeri = memberCardSeri;
                        }

                        customerService.Update(customer);
                        if (customerService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }

                }
            }
            return res;
        }
        public ErrorCode DeleteCustomer(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Customer> customerService = new Repository<Customer>(db);
                customerService.Delete(id);
                if (customerService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Customer GetCustomer(int id)
        {
            Customer res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Customer> customerService = new Repository<Customer>(db);
                res = customerService.GetById(id);
            }
            return res;
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> res = new List<Customer>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Customer> customerService = new Repository<Customer>(db);
                res = customerService.Get(null, null, "Job,Nationality,Member").ToList();
            }
            return res;
        }
        private string GetNewCustomerCode()
        {
            string res = "";
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Customer> customerService = new Repository<Customer>(db);
                Customer customer = customerService.GetAll().OrderByDescending(q => q.Id).FirstOrDefault();
                if (customer != null)
                {
                    int currentCodeNumber = 0;
                    int.TryParse(customer.Code.Substring(2), out currentCodeNumber);
                    res = string.Format("KH{0}", (currentCodeNumber + 1).ToString("00000"));
                }
                else
                {
                    res = "KH00000";
                }
            }
            return res;
        }
        #endregion

        #region personnel
        public ErrorCode AddNewPersonnel(string name, int ktvId, Gender gender, DateTime DOB, string phone, DateTime joinDate, JobPosition position, int charge, string idNumber, MaritalStatus maritalStatus, string address, out Personnel personnel)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                personnel = null;
                if (personnelService.Get(q => ((q.KTVId == ktvId) && (q.Status != KTVStatus.Deactive))).Any())
                {
                    res = ErrorCode.EXISTED_KTVID;
                }
                else
                {
                    int count = 1;
                    personnel = personnelService.GetAll().OrderByDescending(q => q.Id).FirstOrDefault();
                    if (personnel != null)
                    {
                        count = personnel.Id + 1;
                    }

                    personnel = new Personnel();
                    personnel.Name = name;
                    personnel.Code = string.Format("KTV{0}", count.ToString("000"));
                    personnel.KTVId = ktvId;
                    personnel.Gender = gender;
                    personnel.DOB = DOB;
                    personnel.Phone = phone;
                    personnel.JoinDate = joinDate;
                    personnel.Position = position;
                    personnel.Charge = charge;
                    personnel.IdNumber = idNumber;
                    personnel.MaritalStatus = maritalStatus;
                    personnel.Address = address;
                    personnel.Status = KTVStatus.Active;
                    personnelService.Insert(personnel);
                    if (personnelService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }

            }

            return res;
        }
        public ErrorCode UpdatePersonnel(int id, string name, int ktvId, Gender gender, DateTime DOB, string phone, DateTime joinDate, JobPosition position, int charge, string idNumber, MaritalStatus maritalStatus, string address, KTVStatus status)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                Personnel personnel = personnelService.GetById(id);

                if (personnel != null)
                {
                    bool temp = true;
                    if ((personnel.Status == KTVStatus.Deactive) && (status == KTVStatus.Active))
                    {
                        if (personnelService.Get(q => ((q.KTVId == ktvId) && (q.Status != KTVStatus.Deactive))).Any())
                        {
                            res = ErrorCode.EXISTED_KTVID;
                            temp = false;
                        }
                    }

                    if (temp == true)
                    {
                        personnel.Name = name;
                        personnel.KTVId = ktvId;
                        personnel.Gender = gender;
                        personnel.DOB = DOB;
                        personnel.Phone = phone;
                        personnel.JoinDate = joinDate;
                        personnel.Position = position;
                        personnel.Charge = charge;
                        personnel.IdNumber = idNumber;
                        personnel.MaritalStatus = maritalStatus;
                        personnel.Address = address;
                        personnel.Status = status;

                        personnelService.Update(personnel);
                        if (personnelService.SaveChanges())
                        {
                            res = ErrorCode.OK;
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeletePersonnel(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                personnelService.Delete(id);
                if (personnelService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Personnel GetPersonnel(int id)
        {
            Personnel res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                res = personnelService.Get(q => q.Id == id, null, "Services").FirstOrDefault();
            }
            return res;
        }
        public List<Personnel> GetPersonnels()
        {
            List<Personnel> res = new List<Personnel>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                res = personnelService.GetAll().ToList();
            }
            return res;
        }
        public List<Personnel> GetKTVs()
        {
            List<Personnel> res = new List<Personnel>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                res = personnelService.Get(q => (q.Position == JobPosition.KTV) && (q.Status != KTVStatus.Deactive), null, "Services").ToList();
            }
            return res;
        }
        #endregion

        #region personnel setting
        public ErrorCode UpdatePeronnelSetting(int bonusPerCustomerOrder, int bonusPerCompanyOrder)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<PersonnelSetting> settingService = new Repository<PersonnelSetting>(db);
                PersonnelSetting setting = null;
                if (settingService.Table.Count() == 0)
                {
                    setting = new PersonnelSetting();
                    setting.BonusPerCustomerOrder = bonusPerCustomerOrder;
                    setting.BonusPerCompanyOrder = bonusPerCompanyOrder;
                    settingService.Insert(setting);
                }
                else
                {
                    setting = settingService.Table.FirstOrDefault();
                    setting.BonusPerCustomerOrder = bonusPerCustomerOrder;
                    setting.BonusPerCompanyOrder = bonusPerCompanyOrder;
                    settingService.Update(setting);
                }
                if (settingService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public PersonnelSetting GetPeronnelSetting()
        {
            PersonnelSetting res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<PersonnelSetting> settingService = new Repository<PersonnelSetting>(db);
                if (settingService.Table.Count() > 0)
                {
                    res = settingService.Table.FirstOrDefault();
                }
            }
            return res;
        }
        #endregion

        #region personnel experience
        public ErrorCode AddNewPersonnelExperience(string personnelCode, string serviceCode, out Service service)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                IRepository<Service> serviceService = new Repository<Service>(db);

                Personnel personnel = personnelService.Get(q => q.Code == personnelCode).FirstOrDefault();
                service = null;
                if (personnel != null)
                {
                    if (personnel.Services == null)
                    {
                        personnel.Services = new List<Service>();
                    }

                    service = serviceService.Get(q => q.Code == serviceCode).FirstOrDefault();
                    if (service != null)
                    {
                        if (personnel.Services.Contains(service))
                        {
                            res = ErrorCode.EXISTED_SERVICE;
                        }
                        else
                        {
                            personnel.Services.Add(service);
                            if (personnelService.SaveChanges())
                            {
                                res = ErrorCode.OK;
                            }
                        }
                    }
                }
            }
            return res;
        }
        public ErrorCode DeletePersonnelExperience(string personnelCode, string serviceCode)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                IRepository<Service> serviceService = new Repository<Service>(db);
                Service service = null;
                Personnel personnel = personnelService.Get(q => q.Code == personnelCode).FirstOrDefault();

                if (personnel != null)
                {
                    service = serviceService.Get(q => q.Code == serviceCode).FirstOrDefault();
                    if (service != null)
                    {
                        if (personnel.Services != null)
                        {
                            if (personnel.Services.Contains(service))
                            {
                                personnel.Services.Remove(service);
                                if (personnelService.SaveChanges())
                                {
                                    res = ErrorCode.OK;
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
        public List<Service> GetKTVExperiences(string personnelCode)
        {
            List<Service> res = new List<Service>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                Personnel personnel = personnelService.Get(q => q.Code == personnelCode).FirstOrDefault();
                if (personnel != null)
                {
                    res = personnel.Services.ToList();
                }
            }
            return res;
        }

        public List<Personnel> GetKTVs(string serviceCode)
        {
            List<Personnel> res = new List<Personnel>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Service> serviceService = new Repository<Service>(db);
                Service service = serviceService.Get(q => q.Code == serviceCode).FirstOrDefault();
                if (service != null)
                {
                    res = service.Personnels.Where(q => q.Status != KTVStatus.Deactive).ToList();
                }
            }
            return res;
        }
        #endregion

        #region import
        public ErrorCode AddNewImport(string warehouseName, string serviceCode, int qty, string importedBy, string note, out Import import)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Import> importService = new Repository<Import>(db);
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);
                IRepository<Certificate> certificateService = new Repository<Certificate>(db);
                IRepository<OtherService> othersService = new Repository<OtherService>(db);

                import = null;
                Warehouse warehouse = warehouseService.Get(q => q.Name == warehouseName).FirstOrDefault();
                if (warehouse != null)
                {
                    import = new Import();
                    switch (warehouse.WarehouseType)
                    {
                        case ServiceType.Certificate:
                            Certificate cer = certificateService.Get(q => q.Code == serviceCode).FirstOrDefault();
                            if (cer != null)
                            {
                                import.CertificateId = cer.Id;
                            }
                            break;
                        case ServiceType.OtherService:
                            OtherService other = othersService.Get(q => q.Code == serviceCode).FirstOrDefault();
                            if (other != null)
                            {
                                import.OtherServiceId = other.Id;
                            }
                            break;
                    }
                    import.WarehouseId = warehouse.Id;
                    import.Quantity = qty;
                    import.ImportedBy = importedBy;
                    import.ImportAt = DateTime.Now;
                    import.Note = note;
                    importService.Insert(import);
                    if (importService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                        UpdateToInventory(warehouse.Name, warehouse.WarehouseType, serviceCode, qty, import.ImportAt);
                    }
                }



            }

            return res;
        }
        public ErrorCode DeleteImport(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Import> importService = new Repository<Import>(db);
                importService.Delete(id);
                if (importService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Import GetImport(int id)
        {
            Import res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Import> importService = new Repository<Import>(db);
                res = importService.Get(q => q.Id == id, null, "Certificate,OtherService,Warehouse").FirstOrDefault();
            }
            return res;
        }
        public List<Import> GetImports()
        {
            List<Import> res = new List<Import>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Import> importService = new Repository<Import>(db);
                res = importService.Get(null, null, "Certificate,OtherService,Warehouse").ToList();

            }
            return res;
        }

        #endregion

        #region export
        public ErrorCode AddNewExport(string warehouseName, string serviceCode, int qty, string strSeries, string exportedBy, string note, out Export export)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Export> exportService = new Repository<Export>(db);
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);
                IRepository<Certificate> certificateService = new Repository<Certificate>(db);
                IRepository<OtherService> othersService = new Repository<OtherService>(db);

                export = null;
                Warehouse warehouse = warehouseService.Get(q => q.Name == warehouseName).FirstOrDefault();
                if (warehouse != null)
                {
                    export = new Export();
                    switch (warehouse.WarehouseType)
                    {
                        case ServiceType.Certificate:
                            Certificate cer = certificateService.Get(q => q.Code == serviceCode).FirstOrDefault();
                            if (cer != null)
                            {
                                export.CertificateId = cer.Id;
                                List<int> series = StringParser.GetSeries(strSeries);
                                if (series.Count > 0)
                                {
                                    List<CertificateSeri> certificateSeries = new List<CertificateSeri>();
                                    AddNewCertificateSeries(cer.Code, series, out certificateSeries);
                                }
                            }
                            break;
                        case ServiceType.OtherService:
                            OtherService other = othersService.Get(q => q.Code == serviceCode).FirstOrDefault();
                            if (other != null)
                            {
                                export.OtherServiceId = other.Id;
                            }
                            break;
                    }
                    export.WarehouseId = warehouse.Id;
                    export.Quantity = qty;
                    export.ExportedBy = exportedBy;
                    export.ExportAt = DateTime.Now;
                    export.Note = note;
                    exportService.Insert(export);
                    if (exportService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                        UpdateToInventory(warehouse.Name, warehouse.WarehouseType, serviceCode, -qty, export.ExportAt);
                    }
                }



            }

            return res;
        }
        public ErrorCode DeleteExport(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Export> exportService = new Repository<Export>(db);
                exportService.Delete(id);
                if (exportService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Export GetExport(int id)
        {
            Export res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Export> exportService = new Repository<Export>(db);
                res = exportService.Get(q => q.Id == id, null, "Certificate,OtherService,Warehouse").FirstOrDefault();
            }
            return res;
        }
        public List<Export> GetExports()
        {
            List<Export> res = new List<Export>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Export> exportService = new Repository<Export>(db);
                res = exportService.Get(null, null, "Certificate,OtherService,Warehouse").ToList();
            }
            return res;
        }

        #endregion

        #region inventory
        public ErrorCode UpdateToInventory(string warehouseName, ServiceType type, string serviceCode, int qty, DateTime date)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Inventory> inventoryService = new Repository<Inventory>(db);
                IRepository<Certificate> certificateService = new Repository<Certificate>(db);
                IRepository<OtherService> othersService = new Repository<OtherService>(db);
                IRepository<Warehouse> warehouseService = new Repository<Warehouse>(db);

                Inventory inventory = new Inventory();
                inventory.Date = date;
                inventory.Quantity = qty;
                switch (type)
                {
                    case ServiceType.Certificate:
                        Certificate cer = certificateService.Get(q => q.Code == serviceCode).FirstOrDefault();
                        if (cer != null)
                        {
                            if (cer.Inventories == null)
                            {
                                cer.Inventories = new List<Inventory>();
                            }
                            inventory.CertificateId = cer.Id;
                            Inventory inv = cer.Inventories.Where(q => q.IsActive == true).LastOrDefault();
                            if (inv != null)
                            {
                                inventory.Quantity += inv.Quantity;
                            }

                        }
                        break;
                    case ServiceType.OtherService:
                        OtherService other = othersService.Get(q => q.Code == serviceCode).FirstOrDefault();
                        if (other != null)
                        {
                            if (other.Inventories == null)
                            {
                                other.Inventories = new List<Inventory>();
                            }
                            inventory.OtherServiceId = other.Id;
                            Inventory inv = other.Inventories.Where(q => q.IsActive == true).LastOrDefault();
                            if (inv != null)
                            {
                                inventory.Quantity += inv.Quantity;
                            }
                        }
                        break;
                }
                Warehouse warehouse = warehouseService.Get(q => q.Name == warehouseName).FirstOrDefault();
                if (warehouse != null)
                {
                    inventory.WarehouseId = warehouse.Id;
                }
                inventoryService.Insert(inventory);
                if (inventoryService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }

            }

            return res;
        }
        #endregion

        #region book
        public ErrorCode AddNewBook(string customerName, DateTime bookingTime, string note, List<string> personnelCodes, List<string> roomCodes, List<string> serviceCodes, List<string> packageCodes, out Book book)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Book> bookService = new Repository<Book>(db);
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                IRepository<Service> serviceService = new Repository<Service>(db);
                IRepository<Package> packageService = new Repository<Package>(db);
                IRepository<Room> roomService = new Repository<Room>(db);

                book = new Book();
                book.CustomerName = customerName;
                book.BookingTime = bookingTime;
                book.Note = note;

                if (personnelCodes.Count > 0)
                {
                    book.Personnels = new List<Personnel>();
                    foreach (string code in personnelCodes)
                    {
                        Personnel personnel = personnelService.Get(q => q.Code == code).FirstOrDefault();
                        if (personnel != null)
                        {
                            book.Personnels.Add(personnel);
                        }
                    }
                }

                if (serviceCodes.Count > 0)
                {
                    book.Services = new List<Service>();
                    foreach (string code in serviceCodes)
                    {
                        Service service = serviceService.Get(q => q.Code == code).FirstOrDefault();
                        if (service != null)
                        {
                            book.Services.Add(service);
                        }
                    }
                }

                if (packageCodes.Count > 0)
                {
                    book.Packages = new List<Package>();
                    foreach (string code in packageCodes)
                    {
                        Package package = packageService.Get(q => q.Code == code).FirstOrDefault();
                        if (package != null)
                        {
                            book.Packages.Add(package);
                        }
                    }
                }

                if (roomCodes.Count > 0)
                {
                    book.Rooms = new List<Room>();
                    foreach (string code in roomCodes)
                    {
                        Room room = roomService.Get(q => q.Code == code).FirstOrDefault();
                        if (room != null)
                        {
                            book.Rooms.Add(room);
                        }
                    }
                }

                bookService.Insert(book);
                if (bookService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }

            }

            return res;
        }
        public ErrorCode UpdateBook(int id, string customerName, DateTime bookingTime, string note, List<string> personnelCodes, List<string> roomCodes, List<string> serviceCodes, List<string> packageCodes)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Book> bookService = new Repository<Book>(db);
                IRepository<Personnel> personnelService = new Repository<Personnel>(db);
                IRepository<Service> serviceService = new Repository<Service>(db);
                IRepository<Package> packageService = new Repository<Package>(db);
                IRepository<Room> roomService = new Repository<Room>(db);

                Book book = bookService.GetById(id);
                if (book != null)
                {
                    book.CustomerName = customerName;
                    if (book.Personnels == null)
                    {
                        book.Personnels = new List<Personnel>();
                    }
                    else
                    {
                        book.Personnels.Clear();
                    }

                    if (book.Services == null)
                    {
                        book.Services = new List<Service>();
                    }
                    else
                    {
                        book.Services.Clear();
                    }

                    if (book.Packages == null)
                    {
                        book.Packages = new List<Package>();
                    }
                    else
                    {
                        book.Packages.Clear();
                    }

                    if (book.Rooms == null)
                    {
                        book.Rooms = new List<Room>();
                    }
                    else
                    {
                        book.Rooms.Clear();
                    }

                    if (personnelCodes.Count > 0)
                    {
                        foreach (string code in personnelCodes)
                        {
                            Personnel personnel = personnelService.Get(q => q.Code == code).FirstOrDefault();
                            if (personnel != null)
                            {
                                book.Personnels.Add(personnel);
                            }
                        }
                    }

                    if (serviceCodes.Count > 0)
                    {
                        foreach (string code in serviceCodes)
                        {
                            Service service = serviceService.Get(q => q.Code == code).FirstOrDefault();
                            if (service != null)
                            {
                                book.Services.Add(service);
                            }
                        }
                    }

                    if (packageCodes.Count > 0)
                    {
                        foreach (string code in packageCodes)
                        {
                            Package package = packageService.Get(q => q.Code == code).FirstOrDefault();
                            if (package != null)
                            {
                                book.Packages.Add(package);
                            }
                        }
                    }

                    if (roomCodes.Count > 0)
                    {
                        foreach (string code in roomCodes)
                        {
                            Room room = roomService.Get(q => q.Code == code).FirstOrDefault();
                            if (room != null)
                            {
                                book.Rooms.Add(room);
                            }
                        }
                    }

                    bookService.Update(book);
                    if (bookService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteBook(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Book> bookService = new Repository<Book>(db);
                bookService.Delete(id);
                if (bookService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public Book GetBook(int id)
        {
            Book res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Book> bookService = new Repository<Book>(db);
                res = bookService.GetById(id);
            }
            return res;
        }
        public List<Book> GetBooks()
        {
            List<Book> res = new List<Book>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<Book> bookService = new Repository<Book>(db);
                res = bookService.GetAll().ToList();
            }
            return res;
        }
        #endregion

        #region shift report
        public ErrorCode AddNewShiftReport(int shift, DateTime date, int vnd, int usd, int visa, string giver, string receiver, out ShiftReport shiftReport)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<ShiftReport> shiftService = new Repository<ShiftReport>(db);

                shiftReport = new ShiftReport();
                shiftReport.Shift = shift;
                shiftReport.Date = date;
                shiftReport.VND = vnd;
                shiftReport.USD = usd;
                shiftReport.Visa = visa;
                shiftReport.Giver = giver;
                shiftReport.Receiver = receiver;
                shiftService.Insert(shiftReport);
                if (shiftService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }

            }

            return res;
        }
        public ErrorCode UpdateShiftReport(int id, int shift, DateTime date, int vnd, int usd, int visa, string giver, string receiver)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<ShiftReport> shiftService = new Repository<ShiftReport>(db);

                ShiftReport shiftReport = shiftService.GetById(id);
                if (shiftReport != null)
                {
                    shiftReport.Shift = shift;
                    shiftReport.Date = date;
                    shiftReport.VND = vnd;
                    shiftReport.USD = usd;
                    shiftReport.Visa = visa;
                    shiftReport.Giver = giver;
                    shiftReport.Receiver = receiver;
                    shiftService.Update(shiftReport);
                    if (shiftService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteShiftReport(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<ShiftReport> shiftService = new Repository<ShiftReport>(db);
                shiftService.Delete(id);
                if (shiftService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public ShiftReport GetShiftReport(int id)
        {
            ShiftReport res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<ShiftReport> shiftService = new Repository<ShiftReport>(db);
                res = shiftService.GetById(id);
            }
            return res;
        }
        public List<ShiftReport> GetShiftReports()
        {
            List<ShiftReport> res = new List<ShiftReport>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<ShiftReport> shiftService = new Repository<ShiftReport>(db);
                res = shiftService.GetAll().ToList();
            }
            return res;
        }
        #endregion

        #region daily report
        public ErrorCode AddNewDailyReport(DateTime date, int vnd, int usd, int visa, string giver, string receiver, out DailyReport dailyReport)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<DailyReport> dailyService = new Repository<DailyReport>(db);

                dailyReport = new DailyReport();
                dailyReport.Date = date;
                dailyReport.VND = vnd;
                dailyReport.USD = usd;
                dailyReport.Visa = visa;
                dailyReport.Giver = giver;
                dailyReport.Receiver = receiver;
                dailyService.Insert(dailyReport);
                if (dailyService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }

            }

            return res;
        }
        public ErrorCode UpdateDailyReport(int id, DateTime date, int vnd, int usd, int visa, string giver, string receiver)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<DailyReport> dailyService = new Repository<DailyReport>(db);

                DailyReport dailyReport = dailyService.GetById(id);
                if (dailyReport != null)
                {
                    dailyReport.Date = date;
                    dailyReport.VND = vnd;
                    dailyReport.USD = usd;
                    dailyReport.Visa = visa;
                    dailyReport.Giver = giver;
                    dailyReport.Receiver = receiver;
                    dailyService.Update(dailyReport);
                    if (dailyService.SaveChanges())
                    {
                        res = ErrorCode.OK;
                    }
                }
            }
            return res;
        }
        public ErrorCode DeleteDailyReport(int id)
        {
            ErrorCode res = ErrorCode.N_OK;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<DailyReport> dailyService = new Repository<DailyReport>(db);
                dailyService.Delete(id);
                if (dailyService.SaveChanges())
                {
                    res = ErrorCode.OK;
                }
            }
            return res;
        }
        public DailyReport GetDailyReport(int id)
        {
            DailyReport res = null;
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<DailyReport> dailyService = new Repository<DailyReport>(db);
                res = dailyService.GetById(id);
            }
            return res;
        }
        public List<DailyReport> GetDailyReports()
        {
            List<DailyReport> res = new List<DailyReport>();
            using (SpaDbContext db = new SpaDbContext())
            {
                IRepository<DailyReport> dailyService = new Repository<DailyReport>(db);
                res = dailyService.GetAll().ToList();
            }
            return res;
        }
        #endregion

    }

}
