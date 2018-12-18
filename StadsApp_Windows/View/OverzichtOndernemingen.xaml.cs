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
        //public ObservableCollection<string> Soorten;

        public OverzichtOndernemingen()
        {
            this.InitializeComponent();
        }
		

		protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            overzichtvm = new OverzichtOndernemingenViewModel();
            await overzichtvm.GetData();
            this.DataContext = overzichtvm;
            this.cboSoorten.SelectedValue = "Alle";
            ShowMapAsync();
			
            //this.cboSoorten.SelectedIndex = 0;
            ToonVestigingenOpMap();
        }

        /************************************************************FILTER****************************************************************************/
        private void btnZoekOnderneming_Click(object sender, RoutedEventArgs e)
        {
            /*Zoeken in lijst van overzicht ondernemingen view model naar de tekst in txtZoekOnderneming*/
            try
            {
                filter(txtZoekOnderneming.Text, overzichtvm.Soorten[cboSoorten.SelectedIndex]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                filter(txtZoekOnderneming.Text, "");
            }
            //overzichtvm.ZoekOnderneming(txtZoekOnderneming.Text, overzichtvm.Soorten[cboSoorten.SelectedIndex]);
        }

        private void btnZoekOnderneming_Click(object sender, TextChangedEventArgs e)
        {
            //filter(txtZoekOnderneming.Text, overzichtvm.Soorten[cboSoorten.SelectedIndex]);
            //overzichtvm.ZoekOnderneming(txtZoekOnderneming.Text, overzichtvm.Soorten[cboSoorten.SelectedIndex]);
        }


        private void btnZoekOnderneming_Click(FrameworkElement sender, DataContextChangedEventArgs args)
        {
          try {
                filter(txtZoekOnderneming.Text, overzichtvm.Soorten[cboSoorten.SelectedIndex]);
            } catch(ArgumentOutOfRangeException e)
            {
                filter(txtZoekOnderneming.Text, "");
            }
        }

        private void filter(string naam, string soort)
        {
            if (soort.Equals("Alle"))
                soort = "";

            overzichtvm.ZoekOnderneming(naam, soort);
        }

        /************************************************************MAP CONTROLS****************************************************************************/
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


        private void ToonVestigingenOpMap()
        {
            BasicGeoposition geoposition = new BasicGeoposition();
            foreach (Vestiging vestiging in overzichtvm.Vestigingen) {
                geoposition.Latitude = vestiging.Latitude;
                geoposition.Longitude = vestiging.Longitude;

                Geopoint location = new Geopoint(geoposition);
                MapIcon mapicon = new MapIcon();

                mapicon.Location = location;
                mapicon.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapicon.Title = vestiging.Naam;
                mapicon.ZIndex = 0;
                MyMap.MapElements.Add(mapicon);
            }
        }


        /************************************************************DETAIL PAGINA****************************************************************************/

        private Onderneming GetOnderneming(Onderneming selectedItem)
        {
            return overzichtvm.Ondernemingen.Where(x => x.OndernemingID == selectedItem.OndernemingID).FirstOrDefault();
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Onderneming ondern = GetOnderneming((Onderneming)lvOndernemingen.SelectedItem);
            ondern.Vestigingen.AddRange(overzichtvm.Vestigingen.Where(x => x.Ondernemingid.Equals(ondern.OndernemingID)));            
            ondern.Promoties.AddRange(overzichtvm.Promoties.Where(x => x.OndernemingID.Equals(ondern.OndernemingID)));
            this.Frame.Navigate(typeof(OndernemingDetail), ondern);
        }

    }
}
