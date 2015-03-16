using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        public int JobPosition { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<BillMain> BillMains { get; set; }
    }
}
