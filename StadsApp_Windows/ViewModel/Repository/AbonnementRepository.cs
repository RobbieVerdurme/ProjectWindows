using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StadsApp_Backend.Models;
using StadsApp_Windows.Model;
using StadsApp_Windows.Model.Exceptions;
using StadsApp_Windows.Model.message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel.Repository
{
    public class AbonnementRepository
    {
        private List<Vestiging> _subscriptions = new List<Vestiging>();
        public List<Vestiging> Subscriptions
        {
            get { return _subscriptions; }
            set { this._subscriptions = value; }
        }

        private HttpClient client;
        private string BaseUrl;

        public AbonnementRepository()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("http://localhost:53331");
        }
        
        public void subscribe(Vestiging vestiging)
        {
            this.Subscriptions.Add(vestiging);
        }

        public void unsubscribe(Vestiging vestiging)
        {
            this.Subscriptions.Remove(vestiging);
        }
    }
}
