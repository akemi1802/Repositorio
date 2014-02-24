using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    public class TweetServices : ITweetServices
    {
        private Entities db = new Entities();

        public bool InsertTweet(Tweet tweet, string username)
        {
            tweet.User = db.User.Where(u => u.Username == username).FirstOrDefault();

            try
            {
                db.Tweet.Add(tweet);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteTweet(int ID)
        {
            try
            {
                var result = db.Tweet.Where(t => t.ID == ID).FirstOrDefault();
                result.Active = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Tweet> ListTweet(string value, int type)
        {
            try
            {
                return ReturnList(ReturnQuery(type, value));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #region Private Methods

        private IQueryable<Tweet> ReturnQuery(int type, string value)
        {
            switch (type)
            {
                case 1:
                    User me = db.User.Where(u => u.Username == value).FirstOrDefault();
                    return (from t in db.Tweet.Include("User")
                            join f in db.Follow
                            on t.UserID equals f.Following.ID
                            into tf
                            from f in tf.DefaultIfEmpty()
                            where t.Active == true
                            && (t.UserID == me.ID || (f.Follower.ID == me.ID && f.Active == true))
                            orderby t.Posted descending
                            select t);
                case 2:
                    return (from t in db.Tweet
                            where t.Texto.Contains(value)
                            && t.Active == true
                            orderby t.Posted descending
                            select t);
                default:
                    return (from t in db.Tweet select t);

            }
        }

        private List<Tweet> ReturnList(IQueryable<Tweet> query)
        {
            return query.AsEnumerable().Select(item =>
                     new Tweet
                     {
                         ID = item.ID,
                         Posted = item.Posted,
                         Texto = item.Texto,
                         Active = item.Active,
                         UserID = item.UserID
                     }).ToList();
        }

        #endregion
    }
}
