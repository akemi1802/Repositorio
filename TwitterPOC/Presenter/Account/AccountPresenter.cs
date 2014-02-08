using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Account
{
    public class AccountPresenter
    {
        INewAccount _View;

        public AccountPresenter(INewAccount createAccount)
        {
            createAccount.Create+=new VoidHandler(_Create);
            _View=createAccount;
        }

        private void _Create()
        {
            Model.Account.AccountDAO accdao = new Model.Account.AccountDAO();
            Model.Account.Account acc = new Model.Account.Account();
            acc.Name = _View.Name;
            acc.Gender = _View.Gender;
            acc.Username = _View.Username;
            acc.Password = _View.Password;
            _View.Return = accdao.CreateAccount(acc);
        }
    }
}
