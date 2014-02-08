using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//public delegate void VoidHandler();

namespace Presenter.Shared
{
    public interface IShared
    {
        string Name { set; }
        string Username { get; }
        string Password { get; }
        //bool Return { set; }
        event VoidHandler Login;

    }
}
