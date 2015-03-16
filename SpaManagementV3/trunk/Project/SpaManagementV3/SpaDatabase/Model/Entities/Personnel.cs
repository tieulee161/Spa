using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public enum Gender
    {
        Female = 0,
        Male = 1,
        Others = 2
    }

    public enum JobPosition
    {
        KTV = 0,
        Cashier = 1,
        Accountant = 2,
        ViceDirector = 3,
        Director = 4,
        Manager = 5,
    }

    public enum MaritalStatus
    {
        Single,
        Married, 
    }

    public enum KTVStatus
    {
        Active = 0,
        Deactive,
        Busy,
        Available,
    }

    public class Personnel : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Code { get; set; }

        public int KTVId { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        [Required]
        public JobPosition Position { get; set; }

        public int? Charge { get; set; }

        [MaxLength(20)]
        public string IdNumber { get; set; }

        public MaritalStatus? MaritalStatus { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public KTVStatus Status { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<BillKTV> BillKTVs { get; set; }

        public virtual ICollection<BedTransaction> BedTransactions { get; set; }

        public virtual ICollection<Book> Books { get; set; }
   
    }
}
