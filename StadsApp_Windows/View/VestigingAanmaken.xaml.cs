using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
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
    public sealed partial class VestigingAanmaken : Page
    {
        //var
        private VestigingAanmakenViewModel vestigingvm;
        private Onderneming GeselecteerdeOnderneming { get; set; }
        private OndernemingRepository OndernemingRepo;

        //constr
        public VestigingAanmaken()
        {
            this.InitializeComponent();
        }

        //meth
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ParamDTO param = (ParamDTO)e.Parameter;
            this.GeselecteerdeOnderneming = param.gekozenOnderneming;
            this.OndernemingRepo = param.ondernemingRepo;
            vestigingvm = new VestigingAanmakenViewModel(param.ondernemingRepo);
            this.DataContext = vestigingvm;
        }

        private async void VestigingOpslaan(object sender, RoutedEventArgs e)
        {
            Geopoint gp = new Geopoint(new BasicGeoposition());
            MapLocationFinderResult res = await MapLocationFinder.FindLocationsAsync(txtAdres.Text, gp);
            MapLocation location = res.Locations.First();

            Vestiging vestiging = new Vestiging(GeselecteerdeOnderneming.OndernemingID, txtNaam.Text, txtAdres.Text, location.Point.Position.Latitude, location.Point.Position.Longitude);

            await vestigingvm.AanmakenVestigingAsync(vestiging);
            GeselecteerdeOnderneming.Vestigingen.Add(vestiging);
            this.Frame.Navigate(typeof(OndernemingDetail), new ParamDTO()
            {
                gekozenOnderneming = this.GeselecteerdeOnderneming,
                ondernemingRepo = this.OndernemingRepo
            });
		}

	}
}
