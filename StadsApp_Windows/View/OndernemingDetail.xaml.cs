using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class OndernemingDetail : Page
    {
        public Onderneming GeselecteerdeOnderneming { get; set; }


        public OndernemingDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GeselecteerdeOnderneming = (Onderneming)e.Parameter;
            this.DataContext = GeselecteerdeOnderneming;
        }
        /************************************************************Toevoegen****************************************************************************/
        private void VestigingToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VestigingAanmaken), GeselecteerdeOnderneming);
        }

        private void EventToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EventAanmaken), GeselecteerdeOnderneming);
        }

        private void PromotieToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PromotieAanmaken), GeselecteerdeOnderneming);
        }
        /************************************************************Event In Kalender Zetten****************************************************************************/
        private async void Event_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var appointment = new Appointment();
            Event evnt = GetEvent((Event)lvEvents.SelectedItem);

            appointment.Subject = evnt.Naam;
            appointment.Details = evnt.Beschrijving;
            appointment.Location = evnt.Adres;
            appointment.StartTime = evnt.Date;
            appointment.AllDay = true;

            var rect = OndernemingDetail.GetElementRect(this as FrameworkElement);
            string appointmentId = await AppointmentManager.ShowAddAppointmentAsync(appointment, rect, Windows.UI.Popups.Placement.Default);
        }

        private Event GetEvent(Event selectedItem)
        {
            return GeselecteerdeOnderneming.Events.Where(x => x.EventId == selectedItem.EventId).FirstOrDefault();
        }

        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }
        /************************************************************Promotie pdf Genereren****************************************************************************/
        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
