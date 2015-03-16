using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BillVoucherPayment : BaseEntity
    {
        public int? BillMainId { get; set; }

        public int CertificateSeriId { get; set; }

        public int Pay { get; set; }

        [ForeignKey("BillMainId")]
        public virtual BillMain BillMain { get; set; }

        [ForeignKey("CertificateSeriId")]
        public virtual CertificateSeri CertificateSeri { get; set; }
    }
}
