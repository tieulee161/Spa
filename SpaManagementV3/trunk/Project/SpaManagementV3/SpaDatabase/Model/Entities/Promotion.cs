using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Promotion : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Code { get; set; }

        public PromotionCondition Type { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? StopTime { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        public int Discount { get; set; }

        public bool IsPercent { get; set; }

        public virtual ICollection<BillService> BillServices { get; set; }

        public virtual ICollection<BillPackage> BillPackages { get; set; }

        public virtual ICollection<BillCertificate> BillCertificates { get; set; }

        public virtual ICollection<BillOtherService> BillOtherServices { get; set; }
    }
}
