using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Customer : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Code { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string TaxNumber { get; set; }

        public int? JobId { get; set; }

        public int? NationalityId { get; set; }

        public int? MemberId { get; set; }

        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }

        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [MaxLength(50)]
        public string MemberCardSeri { get; set; }

        public virtual ICollection<BillMain> BillMains { get; set; }
      
    }
}
