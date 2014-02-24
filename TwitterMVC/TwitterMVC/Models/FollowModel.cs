using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TwitterMVC.Models
{
    public class FollowModel
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public virtual UserModel Following { get; set; }

        [ScaffoldColumn(false)]
        public virtual UserModel Follower { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }
    }
}