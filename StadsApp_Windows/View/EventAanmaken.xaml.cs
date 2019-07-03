using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StadsApp_Windows.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventAanmaken : Page
    {
        //var
        public Vestiging GeselecteerdeVestiging;
        public EventAanmakenViewModel eventAamakenvm;
        private OndernemingRepository OndernemingRepo;

        //constr
        public EventAanmaken()
        {
            this.InitializeComponent();
        }

        //meth
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ParamDTO param = (ParamDTO)e.Parameter;
            this.GeselecteerdeVestiging = param.gekozenVestiging;
            this.OndernemingRepo = param.ondernemingRepo;
            eventAamakenvm = new EventAanmakenViewModel(param.ondernemingRepo);
            this.DataContext = eventAamakenvm;
        }

        private async void EventToevoegen(object sender, RoutedEventArgs e)
        {
            Event evnt = new Event(GeselecteerdeVestiging.VestigingID, txtNaamEvent.Text, txtBeschrijvingEvent.Text, calDate.Date.Value.Date);
            await eventAamakenvm.AanmakenEventAsync(evnt);
            this.GeselecteerdeVestiging.Events.Add(evnt);
            this.Frame.Navigate(typeof(DetailVestiging), new ParamDTO()
            {
                ondernemingRepo = this.OndernemingRepo,
                gekozenVestiging = this.GeselecteerdeVestiging
            });
        }
    }
}
