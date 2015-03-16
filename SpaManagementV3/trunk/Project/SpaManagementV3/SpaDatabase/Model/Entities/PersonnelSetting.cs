using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class PersonnelSetting : BaseEntity
    {
        public int BonusPerCustomerOrder { get; set; }

        public int BonusPerCompanyOrder { get; set; }
    }
}
