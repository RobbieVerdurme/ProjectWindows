using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class LoginViewModel
    {
        //var
        private AccountRepository AccountRepo;

        //const
        public LoginViewModel(AccountRepository accountrepo)
        {
            this.AccountRepo = accountrepo;
        }

        public async Task<string> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Please enter a username";
                
            }
            if (string.IsNullOrEmpty(password))
            {
                return "Please enter a password";
            }

            return await AccountRepo.Login(username, password);
        }

        //meth
    }
}
