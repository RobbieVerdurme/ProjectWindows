using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StadsApp_Backend.Models;
using StadsApp_Windows.Model;
using StadsApp_Windows.Model.Exceptions;
using StadsApp_Windows.Model.message;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StadsApp_Windows.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private OndernemingRepository ondernemingsRepo;
        private AccountRepository AccountRepo;
        private LoginViewModel loginvm;

        public Login()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            AccountDTO param = (AccountDTO)e.Parameter;
            this.loginvm = new LoginViewModel(param.AccountRepository);
            this.ondernemingsRepo = param.OndernemingRepository;
            this.AccountRepo = param.AccountRepository;
        }

        private async void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";
            //login
            try
            {
                await loginvm.Login(UsernameTextBox.Text, PasswordTextBox.Password);
                
                //Navigate to ondernemingen when successfully logged in
                Frame.Navigate(typeof(OverzichtOndernemingen), ondernemingsRepo);
            }
            catch (InvalidUsernameException ex)
            {
                ErrorMessage.Text = "Invalid username";
            }
            catch (InvalidPasswordException ex)
            {
                ErrorMessage.Text = "Invalid password";
            }
            catch (InvalidCredentialsException ex)
            {
                ErrorMessage.Text = "Invalid credentials";
            }

		}

        private void RegistreerClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registreren), new AccountDTO()
            {
                AccountRepository = this.AccountRepo,
                OndernemingRepository = this.ondernemingsRepo
            }) ;
        }
		
		private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
		{
			ErrorMessage.Text = "";
			Frame.Navigate(typeof(Registreren), new AccountDTO()
            {
                AccountRepository = this.AccountRepo,
                OndernemingRepository = this.ondernemingsRepo
            });
		}

	}
}
