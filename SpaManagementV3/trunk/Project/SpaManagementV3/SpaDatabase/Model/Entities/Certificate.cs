using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Certificate : BaseService
    {
        [Required]
        public int Duration { get; set; }

        public virtual ICollection<BillCertificate> BillCertificates { get; set; }
        public virtual ICollection<CertificateSeri> CertificateSeries { get; set; }
        public virtual ICollection<Import> Imports { get; set; }
        public virtual ICollection<Export> Exports { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
