using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IUserServices
    {
        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        bool InsertUser(User user);

        [OperationContract]
        bool Login(User user);

        [OperationContract]
        List<User> ListUser(int idUser, int type);
    }

    public class User
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public virtual ICollection<Tweet> Tweets { get; set; }
        
        /*[DataMember]
        public virtual List<User> Following { get; set; }
        [DataMember]
        public virtual List<User> Follower { get; set; }*/
    }
}