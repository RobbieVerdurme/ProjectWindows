using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Appointments;
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
    public sealed partial class DetailVestiging : Page
    {
        //var
        private Vestiging Vestiging;
        private VestigingDetailViewModel vmDetail;
        private OndernemingRepository OndernemingRepo;

        //constr
        public DetailVestiging()
        {
            this.InitializeComponent();
        }

        //meth
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ParamDTO param = (ParamDTO)e.Parameter;
            this.OndernemingRepo = param.ondernemingRepo;
            this.Vestiging = param.gekozenVestiging;
            vmDetail = new VestigingDetailViewModel(param.ondernemingRepo);
            this.DataContext = Vestiging;
        }

        private void EventToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EventAanmaken), new ParamDTO() {
            gekozenVestiging = this.Vestiging,
            ondernemingRepo = this.OndernemingRepo
            });
        }

        protected async void Verwijderen(object sender, RoutedEventArgs e)
        {
            await vmDetail.VerwijderVestigingAsync(Vestiging);
            this.Frame.Navigate(typeof(OverzichtOndernemingen), this.OndernemingRepo);
        }

        /************************************************************Event In Kalender Zetten****************************************************************************/
        private async void Event_Tapped(object sender, TappedRoutedEventArgs e)
        {

            var appointment = new Appointment();
            Event evnt = GetEvent((Event)lvEvents.SelectedItem);

            appointment.Subject = evnt.Naam;
            appointment.Details = evnt.Beschrijving;
            appointment.Location = Vestiging.Adres;
            appointment.StartTime = evnt.Date;
            appointment.AllDay = true;

            var rect = GetElementRect(this as FrameworkElement);
            string appointmentId = await AppointmentManager.ShowAddAppointmentAsync(appointment, rect, Windows.UI.Popups.Placement.Default);
        }
        
        private Event GetEvent(Event selectedItem)
        {
            return Vestiging.Events.Where(x => x.EventId == selectedItem.EventId).FirstOrDefault();
        }

        private static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }
    }
}
