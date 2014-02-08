using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Search
{
    public class SearchPresenter
    {
        ISearch _View;

        public SearchPresenter(ISearch tweet)
        {
            tweet.SearchTweets+=new VoidHandler(_SearchTweets);
            _View = tweet;
        }

        private void _SearchTweets()
        {
            Model.Profile.ProfileDAO profiledao = new Model.Profile.ProfileDAO();
            _View.Searchresult=profiledao.SearchTweet(_View.Term);
        }
    }
}
