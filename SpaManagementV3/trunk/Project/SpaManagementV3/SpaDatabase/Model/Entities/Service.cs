using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class Service : BaseService 
    {
        [Required]
        public int Tour { get; set; }

        [Required]
        public int NumberOfKTVNeeded { get; set; }

 
        public virtual ICollection<Package> Packages
        {
            get;
            set;
        }

        public virtual ICollection<Personnel> Personnels { get; set; }

        public virtual ICollection<BillService> BillServices { get; set; }

        public virtual ICollection<BedTransaction> BedTransactions { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
