using System;
using System.Collections.Generic;

#nullable disable

namespace Monomarket.Data.Entities
{
    public partial class UserCredential
    {
        public int UserCredentialsId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
