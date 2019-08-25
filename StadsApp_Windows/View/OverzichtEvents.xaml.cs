using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StadsApp_Windows.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverzichtEvents : Page
    {
        private OverzichtEventsViewModel overzichtvm;
        private OndernemingRepository ondernemingRepo;

        public OverzichtEvents()
        {
            this.InitializeComponent();
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.ondernemingRepo = (OndernemingRepository)e.Parameter;
            await ondernemingRepo.VulData();
            overzichtvm = new OverzichtEventsViewModel(ondernemingRepo);
            this.DataContext = overzichtvm;
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //Vestiging v = this.ondernemingRepo.Vestigingen.Where(vestiging => vestiging.VestigingID == e.OriginalSource.).First();
            //v.Events.AddRange(detailondernemingvm.Events.Where(x => x.VestigingID.Equals(v.VestigingID)));
            var baseobj = sender as FrameworkElement;
            var evenement = baseobj.DataContext as Event;
            Vestiging vestiging = this.ondernemingRepo.Vestigingen.Where(v => v.VestigingID == evenement.VestigingID).First();
            vestiging.Events.AddRange(overzichtvm.Events.Where(even => even.VestigingID == vestiging.VestigingID));
            this.Frame.Navigate(typeof(DetailVestiging), new ParamDTO()
            {
                gekozenVestiging = vestiging,
                ondernemingRepo = this.ondernemingRepo
            });
        }

    }
}
