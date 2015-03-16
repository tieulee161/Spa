using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BillMain : BaseEntity
    {
        [Required]
        public int BillNumber { get; set; }
        public int Shift { get; set; }
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfPerson { get; set; }
        public int NumberOfService { get; set; }
      
        public int USD { get; set; }
        public int VND { get; set; }
        public int Visa { get; set; }
        public DateTime Date { get; set; }
        public int Debt 
        { 
            get
            {
                int res = 0;
                int exchangeRate = 21000;
                using(SpaDbContext db = new SpaDbContext())
                {
                    var query = (from q in db.Currencies
                                 where q.Type == CurrencyType.USD
                                 select q).FirstOrDefault();
                    if (query != null)
                    {
                        exchangeRate = query.ExchangeRate;
                    }
                }
                res = FinalTotal - VND - Visa - USD * exchangeRate - Voucher;
                return res;
            }
        }

        [MaxLength(500)]
        public string Note { get; set; }

        public BillStatus Status { get; set; }
        
        public string DeleteBillReason { get; set; }
        public Branch Branch { get; set; }

        #region 
        public int ServiceCharge { get; set; }
        public int RawTotal { get; set; }
        public int RawTotalDiscount { get; set; }
        public int Voucher { get; set; }
        public int BillDiscount { get; set; }
        public int FinalTotal { get; set; }
        public int VAT { get; set; }
        #endregion

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<BillVoucherPayment> BillVoucherPayments { get; set; }

        public virtual ICollection<BillService> BillServices { get; set; }

        public virtual ICollection<BillPackage> BillPackages { get; set; }

        public virtual ICollection<BillCertificate> BillCertificates { get; set; }

        public virtual ICollection<BillOtherService> BillOtherServices { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
