using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace Services
{
    public class UserServices : IUserServices
    {
        private Entities db = new Entities();

        public User GetUser(string username)
        {
            try
            {
                var query = (from u in db.User
                             where u.Username == username
                             && u.Active == true
                             select u);

                return query.AsEnumerable().Select(item =>
                            new User
                            {
                                ID = item.ID,
                                Email = item.Email,
                                Name = item.Name,
                                Username = item.Username
                            }).FirstOrDefault();
                /*
                if (user != null)
                {
                    return (User)user;
                }
                else
                {
                    throw new Exception("Invalid user ID");
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool InsertUser(User user)
        {
            if (Exist(user.Username))
            {
                return false;
            }
            else
            {
                try
                {
                    db.User.Add(user);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Login(User user)
        {
            var userEntity = db.User.Where(u => u.Username == user.Username
                                            && u.Password == user.Password
                                            && u.Active == true).FirstOrDefault();

            if (userEntity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> ListUser(int idUser, int type)
        {
            try
            {
                return ReturnList(ReturnQuery(type, idUser));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #region Private Methods

        private IQueryable<User> ReturnQuery(int type, int idUser)
        {
            switch (type)
            {
                case 1:
                    return (from u in db.User
                             where u.ID != idUser
                             && u.Active == true
                             && !(from f in db.Follow
                                  where f.Follower.ID == idUser
                                  && f.Active == true
                                  select f.Following.ID).Contains(u.ID)
                             select u);
                case 2:
                    return (from f in db.Follow
                             where f.Follower.ID == idUser
                             && f.Active == true
                             select f.Following);
                case 3:
                    return (from f in db.Follow
                            where f.Following.ID == idUser
                            && f.Active == true
                            select f.Follower);
                default:
                    return (from u in db.User select u);
                    
            } 
        }

        private List<User> ReturnList(IQueryable<User> query)
        {
            return query.AsEnumerable().Select(item =>
                             new User
                             {
                                 ID = item.ID,
                                 Email = item.Email,
                                 Name = item.Name,
                                 Username = item.Username
                             }).ToList();
        }

        private bool Exist(string username)
        {
            return db.User.Any(u => u.Username == username);
        }

        #endregion
    }
}
