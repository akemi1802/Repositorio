using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterMVC.Models;

namespace TwitterMVC.ViewModels
{
    public class UserViewModels
    {
        public UserModel UserVM { get; set; }
        public virtual IEnumerable<UserModel> WhotoFollow { get; set; }
        public virtual IEnumerable<UserModel> ListFollowing { get; set; }
        public virtual IEnumerable<UserModel> ListFollower { get; set; }
    }
}