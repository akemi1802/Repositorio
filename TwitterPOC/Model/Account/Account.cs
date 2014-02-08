using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Account
{
    public class Account
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Creation { get; set; }
        public DateTime LastAccess { get; set; }
        public int Activate { get; set; }
    }
}
