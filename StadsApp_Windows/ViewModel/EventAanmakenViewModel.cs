using Newtonsoft.Json;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace StadsApp_Windows.ViewModel
{
    public class EventAanmakenViewModel
    {
        //var
        private OndernemingRepository OndernemingRepo;

        //constr
        public EventAanmakenViewModel(OndernemingRepository ondRepo)
        {
            this.OndernemingRepo = ondRepo;
        }

        //meth
        public async Task AanmakenEventAsync(Event evnt) {
            await OndernemingRepo.AanmakenEventAsync(evnt);
        }
    }
}
