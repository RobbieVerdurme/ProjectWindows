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

        //constr
        public VestigingDetailViewModel(OndernemingRepository ondRepo)
        {
            this.OndernemingRepo = ondRepo;
        }

        //meth
        public async Task VerwijderVestigingAsync(Vestiging v)
        {
            await OndernemingRepo.VerwijderVestigingAsync(v);
        }
    }
}
