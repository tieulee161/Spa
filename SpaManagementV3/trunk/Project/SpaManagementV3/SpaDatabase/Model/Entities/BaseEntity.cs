using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    [Serializable]
    public class BaseEntity : MarshalByRefObject
    {
        public BaseEntity()
        {
            IsActive = true;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        #region Common properties

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [MaxLength(100)]
        public string UpdatedBy { get; set; }

        #endregion
    }

    public enum ServiceType
    {
        Service = 0,
        Package,
        Certificate,
        OtherService
    }

    public enum PromotionCondition
    {
        NoCondition = 0,
        ByDate,
        ByTime
    }

    public enum BillDiscountType
    {
        Custom,
        Promotion,
    }

    public enum CertificateStatus
    {
        New,
        Saled,
        Returned,
        Expiry,
    }

    public enum BillStatus
    {
        NotPayed,
        Payed,
        Bad,
    }

    public enum BedStatus
    {
        Available,
        Busy
    }

    public enum BedTransactionStatus
    {
        Open,
        Running,
        Close
    }

    public enum BookingStatus
    {
        New,
        Cancelled,
        Done,
        Snoozed,
        Dimiss,
    }
}
