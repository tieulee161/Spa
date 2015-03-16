using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SpaDatabase.Model.Entities
{
    public enum UserRole
    {
        ReadOnly = 0,
        AddNewUser = 1,
        AddNewBill = 2,
    }

    public class Role : BaseEntity
    {
        public int UserId { get; set; }

        public UserRole UserRole { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
