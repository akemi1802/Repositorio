using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Profile
{
    public class Profile
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Tweet { get; set; }
        public DateTime Creation { get; set; }
        public int Activate { get; set; }
    }
}
