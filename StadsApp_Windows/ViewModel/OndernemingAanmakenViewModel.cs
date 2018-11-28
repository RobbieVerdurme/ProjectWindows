using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
	class OndernemingAanmakenViewModel
	{

		public async Task AanmakenOndernemingAsync(string naam, string adres, string soort)
		{
			Onderneming onderneming = new Onderneming()
			{
				Naam = naam, 
				Adres = adres,
				Soort = soort
			};

			var ondernemingJson = JsonConvert.SerializeObject(onderneming);

			HttpClient client = new HttpClient();

			var res = await client.PostAsync("http://localhost:59258/api/ondernemings",
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
