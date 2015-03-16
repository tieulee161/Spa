using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Bed : BaseEntity
    {
        [Required]
        public int BedId { get; set; }

        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        public virtual ICollection<BedTransaction> BedTransaction { get; set; }
    }
}
