using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public enum Branch
    {
        MH9C = 0,
        MH2A = 1,
        Branch3,
        Branch4,
        Branch5,
        Branch6,
        Branch7,
        Branch8,
        Branch9,
        Branch10,
    }

    public class Room : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string Code { get; set; }

        [Required]
        public int Charge { get; set; }

        public Branch Branch { get; set; }
 
        public virtual ICollection<Bed> Beds { get; set; }

        public virtual ICollection<BillService> BillServices { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
