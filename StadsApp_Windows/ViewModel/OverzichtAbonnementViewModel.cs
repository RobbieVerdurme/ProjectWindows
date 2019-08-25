using GalaSoft.MvvmLight.Ioc;
using StadsApp_Windows.Model;
using StadsApp_Windows.Model.Exceptions;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class OverzichtAbonnementViewModel
    {
        //var
        private AbonnementRepository AbonnementRepo;

        private List<Event> _subscribedEvents;

        public List<Event> SubscribedEvents
        {
            get { return _subscribedEvents; }
            set { _subscribedEvents = value; }
        }

        //const
        public OverzichtAbonnementViewModel(OndernemingRepository o)
        {
            this.SubscribedEvents = new List<Event>();
            if (this.SubscribedEvents == null) return;
            o.Abonnementen.ToList().ForEach(v => v.Events.ForEach(e => this.SubscribedEvents.Add(e)));
        }
        
    }
}
