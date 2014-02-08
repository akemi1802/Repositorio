using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public delegate void VoidHandler();

namespace Presenter.Account
{
    public interface INewAccount
    {
        string Name { get; }
        int Gender { get; }
        string Username { get; }
        string Password { get; }
        bool Return { set; }
        event VoidHandler Create;
    }
}