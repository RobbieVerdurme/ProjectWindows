using GalaSoft.MvvmLight.Ioc;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace StadsApp_Windows.View
{
    public sealed partial class OverzichtAbonnementen : Page
    {//var
        private OverzichtAbonnementViewModel abonnementenvm;
        private OndernemingRepository ondernemingRepo;
        
        public OverzichtAbonnementen()
        {
            this.InitializeComponent();
        }

        //meth
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.ondernemingRepo = (OndernemingRepository)e.Parameter;
            this.abonnementenvm = new OverzichtAbonnementViewModel(this.ondernemingRepo);
            this.DataContext = this.abonnementenvm;
            
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //Vestiging v = this.ondernemingRepo.Vestigingen.Where(vestiging => vestiging.VestigingID == e.OriginalSource.).First();
            //v.Events.AddRange(detailondernemingvm.Events.Where(x => x.VestigingID.Equals(v.VestigingID)));
            var baseobj = sender as FrameworkElement;
            var evenement = baseobj.DataContext as Event;
            Vestiging vestiging = this.ondernemingRepo.Vestigingen.Where(v => v.VestigingID == evenement.VestigingID).First();
            vestiging.Events.AddRange(ondernemingRepo.Events.Where(even => even.VestigingID == vestiging.VestigingID));
            this.Frame.Navigate(typeof(DetailVestiging), new ParamDTO()
            {
                gekozenVestiging = vestiging,
                ondernemingRepo = this.ondernemingRepo
            });
        }

    }
}
