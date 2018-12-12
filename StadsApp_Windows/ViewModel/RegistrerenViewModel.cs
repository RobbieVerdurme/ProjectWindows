using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace StadsApp_Windows.ViewModel
{
    public class RegistrerenViewModel
    {

        public async Task Registreer(TextBox txtUsername, TextBox txtPassword, TextBox txtPasswordConfirmation)
        {
			Klant klant= new Klant()
			{
				Username = txtUsername.Text,
				Password = txtPassword.Text
			};

			var ondernemingJson = JsonConvert.SerializeObject(klant);

			HttpClient client = new HttpClient();

			var res = await client.PostAsync("http://localhost:59258/api/gebruikers",
				new StringContent(ondernemingJson,
				System.Text.Encoding.UTF8, "application/json"));
			if (res.StatusCode == System.Net.HttpStatusCode.Created)
			{
				//success
				//lst.Add(onderneming);
			}
		}
    }
}
