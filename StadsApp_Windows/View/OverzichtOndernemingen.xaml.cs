using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;
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
        private OndernemingRepository ondernemingRepo;

        public OverzichtOndernemingen()
        {
            this.InitializeComponent();
        }
		

		protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.ondernemingRepo = (OndernemingRepository)e.Parameter;
            overzichtvm = new OverzichtOndernemingenViewModel(ondernemingRepo);
            await ondernemingRepo.VulData();
            this.DataContext = overzichtvm;
            this.cboSoorten.SelectedValue = "Alle";
            ShowMapAsync();
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
            if(overzichtvm.Vestigingen != null)
            {
                foreach (Vestiging vestiging in overzichtvm.Vestigingen)
                {
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
        }


        /************************************************************DETAIL PAGINA****************************************************************************/

        private Onderneming GetOnderneming(Onderneming selectedItem)
        {
            //repo?
            return overzichtvm.Ondernemingen.Where(x => x.OndernemingID == selectedItem.OndernemingID).FirstOrDefault();
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //repo?
            Onderneming ondern = GetOnderneming((Onderneming)lvOndernemingen.SelectedItem);
            ondern.Vestigingen.AddRange(overzichtvm.Vestigingen.Where(x => x.Ondernemingid.Equals(ondern.OndernemingID)));            
            ondern.Promoties.AddRange(overzichtvm.Promoties.Where(x => x.OndernemingID.Equals(ondern.OndernemingID)));
            this.Frame.Navigate(typeof(OndernemingDetail), new ParamDTO()
            {
                gekozenOnderneming = ondern,
                ondernemingRepo = this.ondernemingRepo
            });
        }

    }
}
