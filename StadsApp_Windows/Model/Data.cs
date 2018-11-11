using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Data
    {
        //prop
        public static ObservableCollection<Onderneming> Ondernemingen {get;set;}

        //method
        private async void GetData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:59258/api/ondernemings"));
            Ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
        }
    }
}
