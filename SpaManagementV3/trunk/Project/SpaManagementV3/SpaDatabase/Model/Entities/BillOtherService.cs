using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BillOtherService : BaseEntity
    {
        public int BillMainId { get; set; }

        public int OtherServiceId { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public int Total { get { return Price * Qty; } }

        #region promotion
        public int? PromotionId { get; set; }

        public int? PromotionPercent { get; set; }

        public int? PromotionVND { get; set; }

        public int? PromotionValue { get { return PromotionPercent * Total / 100 + PromotionVND; } }
        #endregion

        #region discount
        public int? DiscountPercent { get; set; }

        public int? DiscountVND { get; set; }

        public int? DiscountValue { get { return DiscountPercent * Total / 100 + DiscountVND; } }
        #endregion

        #region customer
        public int? CustomerId { get; set; }
        #endregion

        [ForeignKey("BillMainId")]
        public virtual BillMain BillMain { get; set; }

        [ForeignKey("OtherServiceId")]
        public virtual OtherService OtherService { get; set; }

        [ForeignKey("PromotionId")]
        public virtual Promotion Promotion { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
