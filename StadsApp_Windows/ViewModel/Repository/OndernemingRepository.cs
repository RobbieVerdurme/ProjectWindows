using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace StadsApp_Windows.ViewModel.Repository
{
    public class OndernemingRepository
    {
        //var
        HttpClient client = new HttpClient();
        private String BaseUrl = "http://localhost:53331/api";

        public ObservableCollection<Onderneming> Ondernemingen { get; set; }
        public ObservableCollection<Vestiging> Vestigingen { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<Promotie> Promoties { get; set; }
        public ObservableCollection<string> Soorten { get; set; }

        //constr
        public OndernemingRepository()
        {
            //vul variablen ^^
            //VulData();
        }

        //meth
        public async Task VulData()
        {
            //onderneming
            var json = await client.GetStringAsync(new Uri($"{BaseUrl}/ondernemings"));
            Ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);

            //vestigingen
            var jsonVestigingen = await client.GetStringAsync(new Uri($"{BaseUrl}/vestigings"));
            Vestigingen = JsonConvert.DeserializeObject<ObservableCollection<Vestiging>>(jsonVestigingen);

            //event
            var jsonEvents = await client.GetStringAsync(new Uri($"{BaseUrl}/events"));
            Events = JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonEvents);

            //promoties
            var jsonPromoties = await client.GetStringAsync(new Uri($"{BaseUrl}/promoties"));
            Promoties = JsonConvert.DeserializeObject<ObservableCollection<Promotie>>(jsonPromoties);

            //soorten onderneming
            //online data afhalen extra class soort
            //var jsonSoorten = await client.GetStringAsync(new Uri($"{BaseUrl}/soortondernemings"));
            //Soorten = JsonConvert.DeserializeObject<ObservableCollection<String>>(jsonSoorten);
            Soorten = new ObservableCollection<string>(new List<string>(new string[] { "Alle", "Schoenenwinkel", "Restaurant", "Café", "Brasserie", "Hotel", "Kledingwinkel", "Supermarkt", "B&B", "Drankcentrale", "Nachtwinkel", "School", "Frituur", "Broodjeszaak", "Overige" }));
        }
        /***************************************************Aanmaken***************************************************************/
        public async Task AanmakenOndernemingAsync(Onderneming onderneming)
        {
            var ondernemingJson = JsonConvert.SerializeObject(onderneming);

            var res = await client.PostAsync($"{BaseUrl}/ondernemings",new StringContent(ondernemingJson,System.Text.Encoding.UTF8, "application/json"));
            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //success
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Onderneming toegevoegd",
                    Content = $"U hebt een onderneming toegevoegd. Met de Naam {onderneming.Naam} en adres voor het hoofdkantoor {onderneming.Adres}",
                    CloseButtonText = "OK"
                };
                await dialog.ShowAsync();
                this.Ondernemingen.Add(onderneming);
            }
        }

        public async Task AanmakenPromotieAsync(Promotie promotie)
        {

            var promotieJson = JsonConvert.SerializeObject(promotie);

            var res = await client.PostAsync(new Uri($"{BaseUrl}/promoties"), new StringContent(promotieJson, System.Text.Encoding.UTF8, "application/json"));
            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //success
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Promotie toegevoegd",
                    Content = $"U hebt een promotie toegevoegd. Met de beschrijving {promotie.Beschrijving}.",
                    CloseButtonText = "OK"
                };
                await dialog.ShowAsync();
                this.Promoties.Add(promotie);
            }
        }

        internal async Task AanmakenEventAsync(Event evnt)
        {
            var eventJson = JsonConvert.SerializeObject(evnt);
            var res = await client.PostAsync(new Uri($"{BaseUrl}/events"),new StringContent(eventJson, System.Text.Encoding.UTF8, "application/json"));
            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //success
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Event toegevoegd",
                    Content = $"U hebt een Event toegevoegd met naam {evnt.Naam}. Met de beschrijving {evnt.Beschrijving}",
                    CloseButtonText = "OK"
                };
                await dialog.ShowAsync();
                this.Events.Add(evnt);
            }
        }

        public async Task AanmakenVestigingAsync(Vestiging vestiging)
        {
            var vestigingJson = JsonConvert.SerializeObject(vestiging);

            HttpClient client = new HttpClient();

            var res = await client.PostAsync(new Uri($"{BaseUrl}/vestigings/"),new StringContent(vestigingJson, System.Text.Encoding.UTF8, "application/json"));
            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //success
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Vestiging toegevoegd",
                    Content = $"U hebt een vestiging toegevoegd met naam {vestiging.Naam}.",
                    CloseButtonText = "OK"
                };
                await dialog.ShowAsync();
                this.Vestigingen.Add(vestiging);
            }
        }

        /***************************************************Verwijderen***************************************************************/
        public async Task VerwijderOnderneming(Onderneming geselecteerdeOnderneming)
        {
            await client.DeleteAsync(new Uri($"{BaseUrl}/ondernemings/{geselecteerdeOnderneming.OndernemingID}"));
            Onderneming verwijderenOnderneming = this.Ondernemingen.Where(o => o.OndernemingID == geselecteerdeOnderneming.OndernemingID).FirstOrDefault();
            this.Ondernemingen.Remove(verwijderenOnderneming);
        }

        public async Task VerwijderVestigingAsync(Vestiging vestiging)
        {
            await client.DeleteAsync(new Uri($"{BaseUrl}/vestigings/{vestiging.VestigingID}"));
            Vestiging verwijderenVestiging = this.Vestigingen.Where(v => v.VestigingID == v.VestigingID).FirstOrDefault();
            this.Vestigingen.Remove(verwijderenVestiging);
        }
    }
}
