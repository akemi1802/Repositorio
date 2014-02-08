using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Model.Profile
{
    public class ProfileDAO
    {
        public bool PostTweet(Profile objprofile)
        {
            ServiceProfile.ProfileServicesClient pfl = new ServiceProfile.ProfileServicesClient();
            Service.ProfileService service = new Service.ProfileService();

            service.Username = objprofile.Username;
            service.Tweet = objprofile.Tweet;
            return pfl.PostTweet(service);
        }

        public bool Following(int idfollower,int idfollow)
        {
            ServiceProfile.ProfileServicesClient pfl = new ServiceProfile.ProfileServicesClient();
            return pfl.Following(idfollower, idfollow);
        }
        public List<Tuple<string,DateTime, string>> ListTweet(string username)
        {
            ServiceProfile.ProfileServicesClient pfl = new ServiceProfile.ProfileServicesClient();
            
            var returnwcf = pfl.ListTweets(username);
            List<Tuple<string, DateTime, string>> result = new List<Tuple<string, DateTime, string>>();

            foreach (Service.ProfileService p in returnwcf)
            {
                result.Add(new Tuple<string,DateTime, string>(p.Tweet,p.Data, p.Username));
            }/*
            ArrayList tweets = new ArrayList();
            foreach(string cont in returnwcf)
            {
                tweets.Add(cont);
            }

            return tweets;*/
            return result;
        }

        public List<Tuple<string, string>> SearchTweet(string term)
        {
            ServiceProfile.ProfileServicesClient pfl = new ServiceProfile.ProfileServicesClient();
            var returnwcf = pfl.SearchTweets(term);
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            
            foreach (Service.ProfileService p in returnwcf)
            {
                result.Add(new Tuple<string,string>(p.Tweet,p.Username));
            }
            
            return result;
        }

        public string GetUsername(int id)
        {
            ServiceProfile.ProfileServicesClient pfl = new ServiceProfile.ProfileServicesClient();
            return pfl.GetUsername(id);
        }

        public int GetID(string username)
        {
            ServiceProfile.ProfileServicesClient pfl = new ServiceProfile.ProfileServicesClient();
            return pfl.ReturnIdUser(username);
        }

        public void Follow(int idFollower, int idFollow)
        {
            ServiceProfile.ProfileServicesClient pfl = new ServiceProfile.ProfileServicesClient();

            pfl.Follow(idFollower, idFollow);
        }
    }
}
