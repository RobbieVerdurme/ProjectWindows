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
    public class OndernemingDetailViewModel
    {
        public Onderneming GeselecteerdeOnderneming { get; set; }
        public ObservableCollection<Event> Events { get; set; }

        //methods
        /************************************************************DATA OPHALEN DATABASE****************************************************************************/
        public async Task<OndernemingDetailViewModel> GetData()
        {
            HttpClient client = new HttpClient();

            var jsonEvents = await client.GetStringAsync(new Uri("http://localhost:53331/api/events"));
            Events = JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonEvents);
            return this;
        }
    }

    

}
