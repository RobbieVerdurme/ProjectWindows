using Newtonsoft.Json;
using StadsApp_Backend.Models;
using StadsApp_Windows.Model.Exceptions;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class Registreren : Page
    {
        private RegistrerenViewModel registrerenvm;
        private AccountRepository AccountRepo;
        private OndernemingRepository OndernemingRepo;

        public Registreren()
        {
            this.InitializeComponent();
        }

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login), new AccountDTO()
            {
                AccountRepository = this.AccountRepo,
                OndernemingRepository = this.OndernemingRepo
            });
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            AccountDTO param = (AccountDTO)e.Parameter;
            this.AccountRepo = param.AccountRepository;
            this.OndernemingRepo = param.OndernemingRepository;
            registrerenvm = new RegistrerenViewModel(AccountRepo);
            this.DataContext = registrerenvm;
        }

        private async void RegisterButton_Click_Async(object sender, RoutedEventArgs e)
		{
			ErrorMessage.Text = "";

            //In the real world you would normally validate the entered credentials and information before 
            //allowing a user to register a new account. 
            //For this sample though we will skip that step and just register an account if username is not null.
            try
            {
                //Try to register the user
                await registrerenvm.Registreer(UsernameTextBox.Text, PasswordBox.Password, PasswordRepeatBox.Password);

                //Go to main page
                Frame.Navigate(typeof(Login), new AccountDTO()
                {
                    AccountRepository = this.AccountRepo,
                    OndernemingRepository = this.OndernemingRepo
                });
            }
            catch(InvalidPasswordException ex)
            {
                ErrorMessage.Text = ex.Message;
            }
            catch (InvalidUsernameException ex)
            {
                ErrorMessage.Text = ex.Message;
            }
            catch (InvalidCredentialsException ex)
            {
                ErrorMessage.Text = ex.Message;
            }

        }
	}
}
