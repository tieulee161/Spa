using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BillService : BaseEntity
    {
        #region main
        public int? BillMainId { get; set; }

        public int? BillPackageId { get; set; }

        public int ServiceId { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public int Tour { get; set; }

        public int Total { get { return Price * Qty; } }

        public int ServiceChargePercent { get; set; }

        public int ServiceChargeValue { get { return Total * ServiceChargePercent / 100; } }
        #endregion

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

        #region room
        public int RoomId { get; set; }
        public int RoomChargePercent { get; set; }
        public int RoomChargeValue { get { return RoomChargePercent * Price * Qty / 100; } }
        #endregion

        #region customer
        public int? CustomerId { get; set; }

        public int? CustomerDiscountPercent { get; set; }

        public int? CustomerDiscountVND { get; set; }

        public int? CustomerDiscountValue { get { return CustomerDiscountPercent *Total / 100 + CustomerDiscountVND; } }
        #endregion

        [ForeignKey("BillMainId")]
        public virtual BillMain BillMain { get; set; }

        [ForeignKey("PromotionId")]
        public virtual Promotion Promotion { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("BillPackageId")]
        public virtual BillPackage BillPackage { get; set; }

        public virtual ICollection<BillKTV> BillKTVs { get; set; }
    }
}
