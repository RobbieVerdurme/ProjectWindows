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
    public class OverzichtOndernemingenViewModel
    {
        //var

        //prop
        public ObservableCollection<Onderneming> Ondernemingen { get; set; }

        //constructor
        public OverzichtOndernemingenViewModel()
        {
            //Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen/*DATASOURCE*/);
            GetData();
        }

        //methods
        private async void GetData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:59258/api/ondernemings"));
            Ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
        }
    }
}
