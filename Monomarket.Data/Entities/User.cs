using System;
using System.Collections.Generic;

#nullable disable

namespace Monomarket.Data.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PhoneNumber { get; set; }

        public virtual UserCredential UserCredential { get; set; }
    }
}
