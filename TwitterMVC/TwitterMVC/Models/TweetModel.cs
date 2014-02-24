using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TwitterMVC.Models
{
    public class TweetModel
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tweet is required")]
        [StringLength(140)]
        public string Texto { get; set; }
        
        public DateTime Posted { get; set; }

        [ScaffoldColumn(false)]
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        
        public virtual UserModel User { get; set; }

    }
}