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
			Onderneming vestiging = new Onderneming(1, naam, adres, soort)
			{
				Naam = naam,
				Adres = adres,
				Soort = soort
			};

			var vestigingJson = JsonConvert.SerializeObject(vestiging);

			HttpClient client = new HttpClient();

			var res = await client.PostAsync(new Uri("http://localhost:53331/api/ondernemings/"),
				new StringContent(vestigingJson, System.Text.Encoding.UTF8, "application/json"));
			if (res.StatusCode == System.Net.HttpStatusCode.Created)
			{
				//success
				//lst.Add(onderneming);
			}
		}

	}
}
