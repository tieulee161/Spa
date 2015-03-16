using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaDatabase.Model.Entities
{
    public enum MemberType
    {
        Normal = 0,
        VIP = 1
    }
    public class Member : BaseCustomer
    {
    }
}
