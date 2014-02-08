using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace Service
{
    [ServiceContract]
    public interface IProfileServices
    {
        [OperationContract]
        bool PostTweet(ProfileService pflservice);

        [OperationContract]
        int ReturnIdUser(string username);

        [OperationContract]
        List<ProfileService> ListTweets(string username);

        [OperationContract]
        List<ProfileService> SearchTweets(string term);

        [OperationContract]
        string GetUsername(int id);

        [OperationContract]
        bool Following(int idfollower, int idfollow);

        [OperationContract]
        void Follow(int idfollower, int idfollow);

    }

    [DataContract]
    public class ProfileService
    {
        string username = string.Empty;
        string tweet = string.Empty;
        DateTime data;

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Tweet
        {
            get { return tweet; }
            set { tweet = value; }
        }
        [DataMember]
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
