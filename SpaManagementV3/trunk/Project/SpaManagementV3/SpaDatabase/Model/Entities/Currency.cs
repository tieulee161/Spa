using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaDatabase.Model.Entities
{
    public enum CurrencyType
    {
        USD = 0,
        JPY
    }
    public class Currency : BaseEntity
    {
        public CurrencyType Type { get; set; }

        public int ExchangeRate { get; set; }
    }
}
