using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class CertificateSeri : BaseEntity
    {
        public int? BillCertificateId { get; set; }

        [Required]
        public int Seri { get; set; }

        public DateTime? IssueDate
        {
            get
            {
                DateTime? res = null;
                if (BillCertificate != null)
                {
                    res = BillCertificate.BillMain.Date;
                }
                return res;
            }
        }

        public DateTime? ExpiryDate
        {
            get
            {
                DateTime? res = null;
                if(IssueDate != null)
                {
                    res = IssueDate.Value.AddMonths(Certificate.Duration);
                }
                return res;
            }
        }

        public DateTime? BackDate 
        { 
            get
            {
                DateTime? res = null;
                if(Remain == 0)
                {
                    BillVoucherPayment billVoucherPayment = BillVoucherPayments.ToList()[BillVoucherPayments.Count - 1];
                    res = billVoucherPayment.BillMain.Date;
                }
                return res;
            }
        }

        public int Remain
        {
            get
            {
                int res = 0;
                foreach (BillVoucherPayment billVoucherPayment in BillVoucherPayments)
                {
                    res += billVoucherPayment.Pay;
                }
                res = Certificate.Price - res;
                if (res < 0) res = 0;
                return res;
            }
        }

        public CertificateStatus Status 
        { 
            get
            {
                CertificateStatus res = CertificateStatus.New;
                if(BackDate != null)
                {
                    res = CertificateStatus.Returned;
                }
                else if ((ExpiryDate != null) && (ExpiryDate.Value <= DateTime.Now))
                {
                    res = CertificateStatus.Expiry;
                }
                else if (IssueDate != null)
                {
                    res = CertificateStatus.Saled;
                }
                return res;
            }
        }

        public int? CertificateId { get; set; }

        [ForeignKey("CertificateId")]
        public virtual Certificate Certificate { get; set; }

        public virtual ICollection<BillVoucherPayment> BillVoucherPayments { get; set; }

        [ForeignKey("BillCertificateId")]
        public virtual BillCertificate BillCertificate { get; set; }
    }
}
