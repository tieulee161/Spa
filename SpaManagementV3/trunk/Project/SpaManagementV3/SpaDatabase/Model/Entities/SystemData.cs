using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class SystemData : BaseEntity
    {
       [MaxLength(100)]
       public string MailDB { get; set; }

       [MaxLength(100)]
       public string MailBill { get; set; }

       [MaxLength(400)]
       public string BackupFolder { get; set; }

       public int Period { get; set; }
    }
}
