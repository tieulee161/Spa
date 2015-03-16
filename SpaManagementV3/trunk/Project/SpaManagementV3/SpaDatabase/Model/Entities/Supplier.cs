using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Supplier : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Code { get; set; }

        [MaxLength(200)]
        public string ContactPerson { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string AccountNumber { get; set; }

        [MaxLength(400)]
        public string Address { get; set; }
    }
}
