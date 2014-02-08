using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Presenter.Profile
{
    public interface ITweet
    {
        string Username { get; }
        List<Tuple<string,DateTime, string>> Tweets { set; }
        event VoidHandler ListTweets;
    }
}
