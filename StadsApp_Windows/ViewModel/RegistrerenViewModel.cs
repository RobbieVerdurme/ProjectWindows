using Newtonsoft.Json;
using StadsApp_Windows.Model;
using StadsApp_Windows.Model.Exceptions;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace StadsApp_Windows.ViewModel
{
    public class RegistrerenViewModel
    {
        //var
        private AccountRepository AccountRepo;

        //const
        public RegistrerenViewModel(AccountRepository accountrepo)
        {
            this.AccountRepo = accountrepo;
        }

        //meth
        public async Task Registreer(string username, string password, string passwordconfirm)
        {
            //checks
            if (string.IsNullOrEmpty(username))
            {
                throw new InvalidUsernameException("Please enter a username");
            }
            if (!IsValidEmail(username))
            {
                throw new InvalidUsernameException("Not a valid email");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidPasswordException("Please enter a password");
            }
            if (string.IsNullOrEmpty(passwordconfirm))
            {
                throw new InvalidPasswordException("Please enter a password");
            }
            if (password != passwordconfirm)
            {
                throw new InvalidPasswordException("Passwords do not match");
            }
            if (!CheckStrength(password))
            {
                throw new InvalidPasswordException("password is not strong enough");
            }

            //registreer
            await AccountRepo.Register(username, password, passwordconfirm);
        }

        /***********************************Checks Help meth***********************************************/
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckStrength(string password)
        {

            string MatchEmailPattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{8,15})$";

            if (password != null) return Regex.IsMatch(password, MatchEmailPattern);
            else return false;
        }
    }
}
