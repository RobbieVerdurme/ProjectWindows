using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class OverzichtOndernemingenViewModel
    {
        //prop
        public ObservableCollection<Onderneming> Ondernemingen { get; set; }
        public ObservableCollection<Onderneming> GefilterdeLijst { get; set; }
        public ObservableCollection<Vestiging> Vestigingen { get; set; }
        public ObservableCollection<string> Soorten { get; set; }

        //constructor
        public OverzichtOndernemingenViewModel(){
            Soorten = new ObservableCollection<string>(new List<string>(new string[] { "Alle","Schoenenwinkel", "Restaurant", "Café", "Brasserie", "Hotel", "Kledingwinkel", "Supermarkt", "B&B", "Drankcentrale", "Nachtwinkel", "School", "Frituur", "Broodjeszaak", "Overige" }));
        }


        //methods
        /************************************************************DATA OPHALEN DATABASE****************************************************************************/
        public async Task<OverzichtOndernemingenViewModel> GetData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:53331/api/ondernemings"));
            Ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
            GefilterdeLijst = new ObservableCollection<Onderneming>(Ondernemingen.ToList());

            var jsonVestigingen = await client.GetStringAsync(new Uri("http://localhost:53331/api/vestigings"));
            Vestigingen = JsonConvert.DeserializeObject<ObservableCollection<Vestiging>>(jsonVestigingen);
			return this;
        }

        /************************************************************FILTER****************************************************************************/
        public IEnumerable<Onderneming> ZoekOnderneming(String tekst, String soort)
        {
            GefilterdeLijst.Clear();
            var o = new List<Onderneming>();
            o = Ondernemingen.ToList().Where(onderneming => onderneming.Naam.Contains(tekst) && onderneming.Soort.Contains(soort)).ToList();
            
            if (o.Count > 0)
            {
                o.ForEach(ond => GefilterdeLijst.Add(ond));
            } else
            {
                //o = Ondernemingen.ToList();//.Where(ond => ond.Naam.Contains("") && ond.Soort.Contains("")).ToList();
                //o.ForEach(ond => GefilterdeLijst.Add(ond));
            }
            return GefilterdeLijst;
            /*var o = new List<Onderneming>();

            if((soort.Trim().Equals("") || soort.Equals(null)) && (tekst.Trim().Equals("") || tekst.Equals(null))) {
                GefilterdeLijst.Clear();
                Ondernemingen.ToList().ForEach(e => GefilterdeLijst.Add(e));
                return GefilterdeLijst;
            }
            else if(soort.Trim().Equals("") || soort.Equals(null))
            {
                o = Ondernemingen.ToList().FindAll(onderneming => onderneming.Naam.Contains(tekst));
            }
            else if((tekst.Trim().Equals("") || tekst.Equals(null)) && !soort.Equals("Alle"))
            {
                o = Ondernemingen.ToList().FindAll(onderneming => onderneming.Soort.Equals(soort));
            }

            if (o.Count > 0)
            {
                GefilterdeLijst.Clear();
                o.ForEach(e => GefilterdeLijst.Add(e));
                return GefilterdeLijst;
            }
            else
            {
                //throw new ArgumentException("De onderneming is niet gevonden");
                GefilterdeLijst.Clear();
            }
            return GefilterdeLijst;



            /*if (soort.Trim().Equals("") || soort.Equals(null))
            {
                if (tekst == null || tekst.Trim().Equals(""))
                {
                    GefilterdeLijst.Clear();
                    Ondernemingen.ToList().ForEach(e => GefilterdeLijst.Add(e));
                    return GefilterdeLijst;
                }
                o = Ondernemingen.ToList().FindAll(onderneming => onderneming.Naam.Contains(tekst) /*|| onderneming.Adres.Contains(tekst)*//*);*/

                
            /*} else if()


            if (o.Count > 0)
            {
                GefilterdeLijst.Clear();
                o.ForEach(e => GefilterdeLijst.Add(e));
                return GefilterdeLijst;
            }
            else
            {
                //throw new ArgumentException("De onderneming is niet gevonden");
                GefilterdeLijst.Clear();
            }

            return GefilterdeLijst;*/


        }
        
    }
}
