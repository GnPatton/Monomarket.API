using System;
using System.Collections.Generic;

#nullable disable

namespace Monomarket.Data.Entities
{
    public partial class Migration
    {
        public int IdMigration { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public string Source { get; set; }
    }
}
