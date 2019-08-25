using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class VestigingDetailViewModel : INotifyPropertyChanged
    {
        //var
        private OndernemingRepository OndernemingRepo;

        public Vestiging Vestiging { get; set; }
        public Gebruiker Gebruiker { get; set; } = Globals.loggedInGebruiker;
        public String AbonnerenText { get
            {
                if (IsGeabonneerd()) return "Unsubscribe";
                else return "Subscribe";
            }
        }
        

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

        public async Task AbonneerVestigingAsync()
        {
            await OndernemingRepo.AbonneerVestigingAsync(Vestiging);
            OnPropertyChanged(new PropertyChangedEventArgs("AbonnerenText"));
        }

        public async Task OnAbonneerVestigingAsync()
        {
            await OndernemingRepo.UnAbonneerVestigingAsync(Vestiging);
            OnPropertyChanged(new PropertyChangedEventArgs("AbonnerenText"));
        }

        public Boolean IsGeabonneerd()
        {
            return OndernemingRepo.Abonnementen.ToList().Find(v => v.VestigingID == Vestiging.VestigingID) != null;
        }


        //Notify the view of the changed username
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
