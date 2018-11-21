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
	class VestigingAanmakenViewModel
	{

		public async Task AanmakenVestigingAsync(string naam, string adres)
		{
			Vestiging vestiging = new Vestiging(1, naam, adres)
			{
				Naam = naam,
				Adres = adres
			};

			var vestigingJson = JsonConvert.SerializeObject(vestiging);

			HttpClient client = new HttpClient();

			var res = await client.PostAsync("http://localhost:59258/api/ondernemings",
				new StringContent(vestigingJson,
				System.Text.Encoding.UTF8, "application/json"));
			if (res.StatusCode == System.Net.HttpStatusCode.Created)
			{
				//success
				//lst.Add(onderneming);
			}
		}

	}
}
