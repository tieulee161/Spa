using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Book : BaseEntity
    {
        public string CustomerName { get; set; }
        public DateTime BookingTime { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        public BookingStatus Status { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Personnel> Personnels { get; set; }

    }
}
