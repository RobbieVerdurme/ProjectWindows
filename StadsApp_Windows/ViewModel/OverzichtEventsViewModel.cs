using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    class OverzichtEventsViewModel
    {
        private OndernemingRepository OndernemingRepo;
        public ObservableCollection<Event> Events { get; set; }

        public OverzichtEventsViewModel(OndernemingRepository ondRepo)
        {
            this.OndernemingRepo = ondRepo;
            VulData();
        }

        private void VulData()
        {
            this.Events = this.OndernemingRepo.Events;
        }
    }
}
