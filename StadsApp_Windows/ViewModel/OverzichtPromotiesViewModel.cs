using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;
using System.Collections.ObjectModel;
using System.Linq;

namespace StadsApp_Windows.ViewModel
{
    public class OverzichtPromotiesViewModel
    {
        //var
        public ObservableCollection<Onderneming> Ondernemingen { get; set; }
        public ObservableCollection<Promotie> Promoties { get; set; }
        private OndernemingRepository OndernemingRepo;

        //const
        public OverzichtPromotiesViewModel(OndernemingRepository ondRepo)
        {
            this.OndernemingRepo = ondRepo;
            vulData();
        }

        //meth
        public void vulData()
        {
            this.Ondernemingen = OndernemingRepo.Ondernemingen;
            this.Promoties = OndernemingRepo.Promoties;
            //this.Promoties.OrderBy(x => x.Van);
        }
    }
}
