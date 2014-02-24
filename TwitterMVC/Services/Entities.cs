using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Services
{
    public class Entities : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Tweet> Tweet { get; set; }
        public DbSet<Follow> Follow { get; set; }
    }
}