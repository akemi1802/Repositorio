using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Profile
{
    public interface IFollow
    {
        string Myusername { get; }
        int Userid { get; }
        string Username { set; }
        List<Tuple<string, DateTime, string>> Tweetlist { set; }
        bool Isfollowing { set; }
        event VoidHandler LoadProfile;
        event VoidHandler Follow;
    }
}
