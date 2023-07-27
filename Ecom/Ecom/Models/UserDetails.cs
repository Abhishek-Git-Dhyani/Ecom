using Ecom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecom.Models
{
    public class UserDetails
    {
        public user User { get; set; }
        public address Address { get; set; }
        public contact Contact { get; set; }
        public enum userType
        {
            ADMIN,
            DOCTOR,
            ASSISTANT,
            USER
        }
    }
}