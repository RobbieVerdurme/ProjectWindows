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
    public class OverzichtPromotiesViewModel
    {
        public ObservableCollection<Onderneming> Ondernemingen { get; set; }
        public ObservableCollection<Promotie> Promoties { get; set; }

        public async Task<OverzichtPromotiesViewModel> GetData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:53331/api/ondernemings"));
            Ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);

            var jsonPromoties = await client.GetStringAsync(new Uri("http://localhost:53331/api/promoties"));
            Promoties = JsonConvert.DeserializeObject<ObservableCollection<Promotie>>(jsonPromoties);
            return this;
        }
    }
}
