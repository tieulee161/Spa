using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public class DailyReport : BaseEntity
    {
        public DateTime Date { get; set; }

        public int VND { get; set; }

        public int USD { get; set; }

        public int Visa { get; set; }

        public string Giver { get; set; }

        public string Receiver { get; set; }

        public string Note { get; set; }
    }
}
