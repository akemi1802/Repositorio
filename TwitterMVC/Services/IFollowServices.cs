using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IFollowServices
    {
        [OperationContract]
        bool Follow(int idFollow, string user);

        [OperationContract]
        bool Unfollow(int idunFollow, string user);
    }

    public class Follow
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public virtual User Following { get; set; }
        [DataMember]
        public virtual User Follower { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
