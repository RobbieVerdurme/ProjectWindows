using Newtonsoft.Json;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void LoginClicked(object sender, RoutedEventArgs e)
        {
			bool success = true;

			if(success)
			{
				var vault = new Windows.Security.Credentials.PasswordVault();
				vault.Add(new Windows.Security.Credentials.PasswordCredential("StadsApp", UsernameTextBox.Text, PasswordTextBox.Password));
			}
        }

        private void RegistreerClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registreren));
        }

		private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
		{
			ErrorMessage.Text = "";
		}
		private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
		{
			ErrorMessage.Text = "";
			Frame.Navigate(typeof(Registreren));
		}

		private async Task Login()
		{
			using (var client = new HttpClient())
			{
				try
				{
					await client.PostAsJsonAsync("http://localhost:59258/api/users", id);

				}
				catch (Exception ex)
				{
					await new MessageDialog(ex.Message).ShowAsync();
				}
			}
			//Ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
			//GefilterdeLijst = new ObservableCollection<Onderneming>(Ondernemingen.ToList());
		}
	}
}
