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
           //GetData();
        }


        //methods

        public async Task<OverzichtOndernemingenViewModel> GetData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:59258/api/ondernemings"));
            Ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
			return this;
        }

      
        public IEnumerable<Onderneming> ZoekOnderneming(String tekst)
        {
            if (tekst == null || tekst.Trim().Equals(""))
                return Ondernemingen;
            var o = Ondernemingen.ToList().FindAll(onderneming => onderneming.Naam.Contains(tekst) /*|| onderneming.Adres.Contains(tekst)*/);
            if (o.Count > 0)
                return o;
            else
                throw new ArgumentException("De onderneming is niet gevonden");
            
        }
        
    }
}
