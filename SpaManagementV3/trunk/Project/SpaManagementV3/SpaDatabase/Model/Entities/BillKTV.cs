using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BillKTV : BaseEntity
    {
        public int BillServiceId { get; set; }

        public int PersonnelId { get; set; }

        public int? ChargePercent { get; set; }

        public int? ChargeValue { get { return BillService.Total * ChargePercent / 100; } }

        public int Tour
        {
            get
            {
                int res = 0;
                res = (BillService.Tour * BillService.Qty) / BillService.BillKTVs.Count;
                return res;
            }
        }

        public bool? IsCustomerOrder { get; set; }

        public bool? IsCompanyOrder { get; set; }

        [ForeignKey("BillServiceId")]
        public virtual BillService BillService { get; set; }

        [ForeignKey("PersonnelId")]
        public virtual Personnel Personnel { get; set; }
    }
}
