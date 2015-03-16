using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class VIPSetting : BaseEntity
    {
        public int? Visit { get; set; }

        public int? Account { get; set; }
    }
}
