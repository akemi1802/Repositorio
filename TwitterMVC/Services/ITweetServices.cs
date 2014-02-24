using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    [ServiceContract]
    [ServiceKnownType(typeof(List<Tweet>))]
    
    public interface ITweetServices
    {
        [OperationContract]
        bool InsertTweet(Tweet tweet, string username);

        [OperationContract]
        List<Tweet> ListTweet(string username, int type);

        //[OperationContract]
        //List<Tweet> SearchTweet(string text);

        [OperationContract]
        bool DeleteTweet(int ID);
    }

    [DataContract]
    public class Tweet
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Texto { get; set; }
        [DataMember]
        public DateTime Posted { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public virtual User User { get; set; }
        
    }
}
