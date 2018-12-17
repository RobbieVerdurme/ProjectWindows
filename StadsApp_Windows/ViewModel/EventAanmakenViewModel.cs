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
    public class EventAanmakenViewModel
    {
        public async Task AanmakenEventAsync(int ondernemingId, string naam, string beschrijving, string adres, DateTimeOffset date) {
            Event evnt = new Event(ondernemingId, naam, beschrijving, adres, date.Date);

            var eventJson = JsonConvert.SerializeObject(evnt);

            HttpClient client = new HttpClient();
            var res = await client.PostAsync(new Uri("http://localhost:53331/api/events"),
                new StringContent(eventJson, System.Text.Encoding.UTF8, "application/json"));
            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {

            }
        }
    }
}
