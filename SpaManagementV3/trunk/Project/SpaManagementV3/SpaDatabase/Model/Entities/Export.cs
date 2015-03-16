using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Export : BaseEntity
    {
        [Required]
        public string ExportedBy { get; set; }

        public int? CertificateId { get; set; }

        public int? OtherServiceId { get; set; }

        public DateTime ExportAt { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey("CertificateId")]
        public virtual Certificate Certificate { get; set; }

        [ForeignKey("OtherServiceId")]
        public virtual OtherService OtherService { get; set; }
    }
}
