using Newtonsoft.Json;
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
    public class PromotieAanmakenViewModel
    {
        //var
        private OndernemingRepository OndernemingRepo;

        //const
        public PromotieAanmakenViewModel(OndernemingRepository ondRepo)
        {
            this.OndernemingRepo = ondRepo;
        }

        //meth
        public async Task AanmakenPromotieAsync(Promotie promotie)
        {
            await OndernemingRepo.AanmakenPromotieAsync(promotie);
        }
    }
}
