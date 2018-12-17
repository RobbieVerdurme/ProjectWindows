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

		public async Task AanmakenVestigingAsync(int ondId, string naam, string adres)
		{
            Vestiging vestiging = new Vestiging(ondId, naam, adres)
            {
                Latitude = 0,
                Longitude = 0
            };

			var vestigingJson = JsonConvert.SerializeObject(vestiging);

			HttpClient client = new HttpClient();

			var res = await client.PostAsync(new Uri("http://localhost:53331/api/vestigings/"),
				new StringContent(vestigingJson, System.Text.Encoding.UTF8, "application/json"));
			if (res.StatusCode == System.Net.HttpStatusCode.Created)
			{
				//success
				//lst.Add(vestiging);
			}
		}

	}
}
