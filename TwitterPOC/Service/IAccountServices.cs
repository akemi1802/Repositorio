using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Service
{
    [ServiceContract]
    public interface IAccountServices
    {
        [OperationContract]
        bool CreateAccount(AccountService accservice);

        [OperationContract]
        string TryLogin(AccountService accservice);
    }

    [DataContract]
    public class AccountService
    {
        string name = string.Empty;
        int gender = 0;
        string username = string.Empty;
        string password = string.Empty;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
