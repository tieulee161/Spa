using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class BaseCustomer : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int Discount { get; set; }

        [Required]
        public bool Percent { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
