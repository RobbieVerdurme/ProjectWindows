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
	public class OndernemingAanmakenViewModel
	{
        //var
        private OndernemingRepository OndernemingRepo;
        public ObservableCollection<String> Soorten { get; set;}


        //constr
        public OndernemingAanmakenViewModel(OndernemingRepository ondRepo) {
            this.OndernemingRepo = ondRepo;
            this.Soorten = ondRepo.Soorten;
        }

        //meth
        public async Task AanmakenOndernemingAsync(Onderneming onderneming)
		{
            await OndernemingRepo.AanmakenOndernemingAsync(onderneming);
		}

	}
}
