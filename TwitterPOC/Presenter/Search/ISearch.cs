using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Presenter.Search
{
    public interface ISearch
    {
        string Term { get; }
        //string Username { set; }
        //ArrayList Tweets { set; }
        //IList<Model.Profile.Profile> tweets { set; }
        //Model.Profile.Profile tweets { set; }
        List<Tuple<string, string>> Searchresult { set; }
        event VoidHandler SearchTweets;
    }
}
