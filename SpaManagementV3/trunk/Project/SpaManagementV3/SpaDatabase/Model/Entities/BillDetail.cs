using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BillDetail : BaseEntity
    {
        public string Description { get; set; }

        public string Code { get; set; }

        public string KTV { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public int Total { get; set; }

        public int Discount { get; set; }

        public int BillMainId { get; set; }

        [ForeignKey("BillMainId")]
        public virtual BillMain BillMain { get; set; }
    }
}
