using Newtonsoft.Json;
using StadsApp_Backend.Models;
using StadsApp_Windows.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public Registreren()
        {
            this.InitializeComponent();
            registrerenvm = new RegistrerenViewModel();
            this.DataContext = registrerenvm;
        }

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

		private async void RegisterButton_Click_Async(object sender, RoutedEventArgs e)
		{
			ErrorMessage.Text = "";
			

			//In the real world you would normally validate the entered credentials and information before 
			//allowing a user to register a new account. 
			//For this sample though we will skip that step and just register an account if username is not null.

			if (string.IsNullOrEmpty(UsernameTextBox.Text))
			{
				ErrorMessage.Text = "Please enter a username";
				return;
			}
			if(!IsValidEmail(UsernameTextBox.Text))
			{
				ErrorMessage.Text = "Not a valid email";
			}
			if (string.IsNullOrEmpty(PasswordBox.Password))
			{
				ErrorMessage.Text = "Please enter a password";
				return;
			}
			if (string.IsNullOrEmpty(PasswordRepeatBox.Password))
			{
				ErrorMessage.Text = "Please enter the password";
				return;
			}
			if (PasswordBox.Password != PasswordRepeatBox.Password)
			{
				ErrorMessage.Text = "Passwords do not match";
				return;
			}
			
			//Register user
			var registerdata = new RegisterBindingModel() { Email = UsernameTextBox.Text, Password = PasswordBox.Password, ConfirmPassword = PasswordRepeatBox.Password };
			var registerJson = JsonConvert.SerializeObject(registerdata);
			HttpClient client = new HttpClient();
			var res = await client.PostAsync("http://localhost:53331/api/account/register", new
			StringContent(registerJson, System.Text.Encoding.UTF8, "application/json"));

			//Log error message
			if(!res.IsSuccessStatusCode)
			{
				ErrorMessage.Text = res.StatusCode + " " + res.ReasonPhrase;
				return;
			}

			//Go to main page
			Frame.Navigate(typeof(OverzichtOndernemingen));

		}

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
	}
}
