using GoogleMaps.LocationServices;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class OverzichtOndernemingen : Page
    {
        private OverzichtOndernemingenViewModel overzichtvm;

        public OverzichtOndernemingen()
        {
            this.InitializeComponent();
        }
		

		protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            overzichtvm = new OverzichtOndernemingenViewModel();
            ShowMapAsync();
			await overzichtvm.GetData();
            this.DataContext = overzichtvm;
            //test();
        }

        private void btnZoekOnderneming_Click(object sender, RoutedEventArgs e)
        {
            /*Zoeken in lijst van overzicht ondernemingen view model naar de tekst in txtZoekOnderneming*/
            overzichtvm.ZoekOnderneming(txtZoekOnderneming.Text);
        }

        private void btnZoekOnderneming_Click(object sender, TextChangedEventArgs e)
        {

            overzichtvm.ZoekOnderneming(txtZoekOnderneming.Text);
        }

        public async void ShowMapAsync()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 100, ReportInterval=10000 };
                    Geoposition pos = await geolocator.GetGeopositionAsync().AsTask();

                    BasicGeoposition begin = new BasicGeoposition();
                    begin.Latitude = pos.Coordinate.Latitude;
                    begin.Longitude = pos.Coordinate.Longitude;

                    Geopoint location = new Geopoint(begin);

                    MapIcon posIcon1 = new MapIcon();
                    posIcon1.Location = location;
                    posIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                    posIcon1.Title = "Uw Locatie";
                    posIcon1.ZIndex = 0;
                    MyMap.MapElements.Add(posIcon1);

                    MyMap.Center = location;
                    MyMap.ZoomLevel = 14;
                    break;

                case GeolocationAccessStatus.Denied:
                    break;
            }

        }


        //private void test()
        //{
        //    string address = "grensstraat, gent";

        //    GoogleLocationService locationService = new GoogleLocationService();
        //    MapPoint point = locationService.GetLatLongFromAddress(address);

        //    BasicGeoposition latitude = new BasicGeoposition();
        //    latitude.Latitude = point.Latitude;
        //    latitude.Longitude = point.Longitude;

        //    Geopoint location = new Geopoint(latitude);

        //    MapIcon postest = new MapIcon();
        //    postest.Location = location;
        //    postest.NormalizedAnchorPoint = new Point(0.5, 1.0);
        //    postest.Title = "test";
        //    postest.ZIndex = 0;
        //    MyMap.MapElements.Add(postest);
        //}


        /************************************************************DETAIL PAGINA****************************************************************************/

        private Onderneming GetOnderneming(Onderneming selectedItem)
        {
            return overzichtvm.Ondernemingen.Where(x => x.OndernemingID == selectedItem.OndernemingID).FirstOrDefault();
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OndernemingDetail), GetOnderneming((Onderneming)lvOndernemingen.SelectedItem));
        }
    }
}
