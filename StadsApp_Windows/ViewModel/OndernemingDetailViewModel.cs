using Newtonsoft.Json;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    class OndernemingDetailViewModel
    {
        //var
        public Onderneming GeselecteerdeOnderneming { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        private OndernemingRepository OndernemingRepo;

        //constr
        public OndernemingDetailViewModel(OndernemingRepository ondRepo, Onderneming geselecteerdeOnderneming)
        {
            this.OndernemingRepo = ondRepo;
            this.GeselecteerdeOnderneming = geselecteerdeOnderneming;
            vulData();
        }


        //methods
        public void vulData()
        {
            Events = OndernemingRepo.Events;
        }

        public void VerwijderOnderneming(Onderneming o)
        {
            OndernemingRepo.VerwijderOnderneming(GeselecteerdeOnderneming);
        }
    }
}
