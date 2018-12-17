using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
	public class OndernemingAanmakenViewModel
	{
        public ObservableCollection<String> Soorten { get; set;}

        public OndernemingAanmakenViewModel() {
            Soorten = new ObservableCollection<string>(new List<string>(new string[] { "Schoenenwinkel", "Restaurant", "Café", "Brasserie", "Hotel", "Kledingwinkel", "Supermarkt", "B&B", "Drankcentrale", "Nachtwinkel", "School", "Frituur", "Broodjeszaak", "Overige" }));
        }

        public async Task AanmakenOndernemingAsync(Onderneming onderneming)
		{
			var ondernemingJson = JsonConvert.SerializeObject(onderneming);

			HttpClient client = new HttpClient();

			var res = await client.PostAsync("http://localhost:53331/api/ondernemings",
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
