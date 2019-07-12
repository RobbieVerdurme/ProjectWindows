using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StadsApp_Backend.Models;
using StadsApp_Windows.Model;
using StadsApp_Windows.Model.message;
using StadsApp_Windows.ViewModel;
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
        public Login()
        {
            this.InitializeComponent();
        }

        private async void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {
			if (string.IsNullOrEmpty(UsernameTextBox.Text))
			{
				ErrorMessage.Text = "Please enter a username";
				return;
			}
			if (string.IsNullOrEmpty(PasswordTextBox.Password))
			{
				ErrorMessage.Text = "Please enter a password";
				return;
			}

			//Login user
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:53331");
			var request = new HttpRequestMessage(HttpMethod.Post, "/token");

			var keyValues = new List<KeyValuePair<string, string>>();
			keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
			keyValues.Add(new KeyValuePair<string, string>("username", UsernameTextBox.Text));
			keyValues.Add(new KeyValuePair<string, string>("password", PasswordTextBox.Password));

			request.Content = new FormUrlEncodedContent(keyValues);
			var response = await client.SendAsync(request);

            //Log error message
            String content = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
                ApiError error = JsonConvert.DeserializeObject<ApiError>(content);

                if(error.Error == "invalid_grant")
                {
                    ErrorMessage.Text = "Invalid credentials";
                }
                else
                {
                    ErrorMessage.Text = error.Error + " " + error.ErrorDescription;
                }
                return;
			}

			//Save user in global variables
			Ondernemer o = new Ondernemer();
			o.Username = UsernameTextBox.Text;

			var result = response.Content.ReadAsStringAsync().Result;
			Dictionary<string, string> tokenDictionary =
			   JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
			string token = tokenDictionary["access_token"];
			o.Access_token = token;
            
            Messenger.Default.Send<GebruikerLoggedInMessage>(new GebruikerLoggedInMessage(o));

            //Save user credentials
            var vault = new Windows.Security.Credentials.PasswordVault();
			vault.Add(new Windows.Security.Credentials.PasswordCredential("StadsApp", UsernameTextBox.Text, PasswordTextBox.Password));

			Frame.Navigate(typeof(OverzichtOndernemingen));
		}

        private void RegistreerClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registreren));
        }
		
		private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
		{
			ErrorMessage.Text = "";
			Frame.Navigate(typeof(Registreren));
		}

	}
}
