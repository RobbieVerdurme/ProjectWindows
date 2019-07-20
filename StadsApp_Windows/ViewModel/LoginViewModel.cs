using StadsApp_Windows.Model.Exceptions;
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

        public async Task Login(string username, string password) 
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new InvalidUsernameException("Please enter a username");
                
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidPasswordException("Please enter a password");
            }

            await AccountRepo.Login(username, password);
        }

        //meth
    }
}
