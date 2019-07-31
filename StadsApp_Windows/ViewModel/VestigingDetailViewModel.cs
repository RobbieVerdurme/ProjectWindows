using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class VestigingDetailViewModel
    {
        //var
        private OndernemingRepository OndernemingRepo;
        public Vestiging Vestiging { get; set; }
        public Gebruiker Gebruiker { get; set; } = Globals.loggedInGebruiker;

        //constr
        public VestigingDetailViewModel(OndernemingRepository ondRepo, Vestiging vestiging)
        {
            this.OndernemingRepo = ondRepo;
            this.Vestiging = vestiging;
        }

        //meth
        public async Task VerwijderVestigingAsync()
        {
            await OndernemingRepo.VerwijderVestigingAsync(Vestiging);
        }
    }
}
