using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BedTransaction : BaseEntity
    {
        public DateTime StartTime { get; set; }

        public int Duration { get; set; }

        public int BedId { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("BedId")]
        public virtual Bed Bed { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }

        public virtual ICollection<Personnel> KTVs { get; set; }
    }
}
