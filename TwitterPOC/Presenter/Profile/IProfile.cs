using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Presenter.Profile
{
    public interface IProfile
    {
        string Tweet { get; }
        string Username { get; }
        bool Return { set; }
        event VoidHandler PostTweet;
    }
}
