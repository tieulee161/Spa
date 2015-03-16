using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Package : BaseService
    {
        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<BillPackage> BillPackages { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
