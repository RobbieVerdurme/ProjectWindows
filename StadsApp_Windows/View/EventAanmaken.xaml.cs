using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
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
    public sealed partial class EventAanmaken : Page
    {
        public Vestiging GeselecteerdeVestiging;
        public EventAanmakenViewModel eventAamakenvm;

        public EventAanmaken()
        {
            this.InitializeComponent();
            eventAamakenvm = new EventAanmakenViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.GeselecteerdeVestiging = (Vestiging)e.Parameter;
            this.DataContext = eventAamakenvm;
        }

        private async void EventToevoegen(object sender, RoutedEventArgs e)
        {
            await eventAamakenvm.AanmakenEventAsync(GeselecteerdeVestiging.VestigingID, txtNaamEvent.Text, txtBeschrijvingEvent.Text, calDate.Date.Value);
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Event toegevoegd",
                Content = $"U hebt een Event toegevoegd aan {GeselecteerdeVestiging.Naam}. Met de naam {txtNaamEvent.Text}",
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
            this.Frame.Navigate(typeof(DetailVestiging), GeselecteerdeVestiging);
        }
    }
}
