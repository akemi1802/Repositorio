using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Profile
{
    public class FollowPresenter
    {
        IFollow _View;

        public FollowPresenter(IFollow tweet)
        {
            tweet.LoadProfile+=new VoidHandler(_LoadProfile);
            
            tweet.Follow += new VoidHandler(_Follow);
            _View = tweet;
        }

        private void _LoadProfile()
        {
            Model.Profile.ProfileDAO profiledao = new Model.Profile.ProfileDAO();
            string username;
            username = profiledao.GetUsername(_View.Userid);
            _View.Username = username;
            _View.Tweetlist = profiledao.ListTweet(username);

            int myid = profiledao.GetID(_View.Myusername);
            if (myid == _View.Userid)
            {
                _View.Isfollowing = true;
            }
            else
            {
                _View.Isfollowing = profiledao.Following(myid, _View.Userid);
            }
        }

        private void _Follow()
        {
            Model.Profile.ProfileDAO profiledao = new Model.Profile.ProfileDAO();
            int myid = profiledao.GetID(_View.Myusername);
            profiledao.Follow(myid,_View.Userid);
        }

    }
}
