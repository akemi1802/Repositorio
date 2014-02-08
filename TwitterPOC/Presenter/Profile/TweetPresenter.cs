using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Presenter.Profile
{
    public class TweetPresenter
    {
        ITweet _View;

        public TweetPresenter(ITweet tweet)
        {
            tweet.ListTweets+=new VoidHandler(_ListTweets);
            _View = tweet;
        }

        private void _ListTweets()
        {
            Model.Profile.ProfileDAO profiledao = new Model.Profile.ProfileDAO();

            _View.Tweets = profiledao.ListTweet(_View.Username);
            /*ArrayList tweets = new ArrayList();
            tweets=profiledao.ListTweet(_View.Username);
            _View.Tweets = tweets;*/
        }
    }
}
