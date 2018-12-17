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
    public class PromotieAanmakenViewModel
    {
        public async Task AanmakenPromotieAsync(int ondernemingId, double percentage, String beschrijving, DateTime van, DateTime tot)
        {
            Promotie promotie = new Promotie(ondernemingId, percentage, beschrijving, van, tot);

            var promotieJson = JsonConvert.SerializeObject(promotie);

            HttpClient client = new HttpClient();
            var res = await client.PostAsync(new Uri("http://localhost:53331/api/promoties"),
                new StringContent(promotieJson, System.Text.Encoding.UTF8, "application/json"));
            if (res.StatusCode == System.Net.HttpStatusCode.Created) {

            }
        }
    }
}
