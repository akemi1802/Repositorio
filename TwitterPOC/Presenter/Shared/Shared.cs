using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Shared
{
    public class Shared
    {
        IShared _View;

        public Shared(IShared login)
        {
            login.Login+=new VoidHandler(_Login);
            _View=login;
        }

        private void _Login()
        {
            Model.Account.AccountDAO accdao = new Model.Account.AccountDAO();
            Model.Account.Account acc = new Model.Account.Account();
            acc.Username = _View.Username;
            acc.Password = _View.Password;
            _View.Name = accdao.TryLogin(acc);
        }
    }
}
