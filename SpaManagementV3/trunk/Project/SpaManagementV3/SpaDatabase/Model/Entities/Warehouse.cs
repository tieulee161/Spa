using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Warehouse : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Code { get; set; }

        [Required]
        public ServiceType WarehouseType { get; set; }

        public virtual ICollection<Import> Imports { get; set; }
        public virtual ICollection<Export> Exports { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
