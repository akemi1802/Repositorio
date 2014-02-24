using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    public class FollowServices : IFollowServices
    {
        private Entities db = new Entities();

        public bool Follow(int idFollow, string user)
        {
            try
            {
                /*
                Follow f = new Follow();

                f.Following = db.User.Where(u => u.ID == idFollow).FirstOrDefault();
                f.Follower = db.User.Where(u => u.Username == user).FirstOrDefault();
                f.Active = true;
                db.Follow.Add(f);*/
                db.Follow.Add(new Follow
                {
                    Active = true,
                    Following = db.User.Where(u => u.ID == idFollow).FirstOrDefault(),
                    Follower = db.User.Where(u => u.Username == user).FirstOrDefault()
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Unfollow(int idUnfollow, string user)
        {
            try
            {
                db.Configuration.LazyLoadingEnabled = false;
                var result = db.Follow.Where(f => f.Following.ID == idUnfollow && f.Follower.Username == user && f.Active == true).FirstOrDefault();
                result.Active = false;
                db.SaveChanges();
                db.Configuration.LazyLoadingEnabled = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
