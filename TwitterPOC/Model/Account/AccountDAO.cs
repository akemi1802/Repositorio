using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Account
{
    public class AccountDAO:ServiceAccount.AccountServicesClient
    {
        public bool CreateAccount(Account objAcc)
        {
            ServiceAccount.AccountServicesClient acc = new ServiceAccount.AccountServicesClient();
            Service.AccountService service = new Service.AccountService();
            service.Name = objAcc.Name;
            service.Gender = objAcc.Gender;
            service.Username = objAcc.Username;
            service.Password = objAcc.Password;

            return acc.CreateAccount(service);
        }

        public string TryLogin(Account objAcc)
        {
            ServiceAccount.AccountServicesClient acc = new ServiceAccount.AccountServicesClient();
            Service.AccountService service = new Service.AccountService();
            service.Name = objAcc.Name;
            service.Username = objAcc.Username;
            service.Password = objAcc.Password;

            return acc.TryLogin(service);

        }
    }
}
