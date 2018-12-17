using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class VestigingAanmaken : Page
    {
        private VestigingAanmakenViewModel vestigingvm;
        private Onderneming ond;

        public VestigingAanmaken()
        {
            this.InitializeComponent();
            vestigingvm = new VestigingAanmakenViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ond = (Onderneming)e.Parameter;
            this.DataContext = vestigingvm;
        }

        private async void VestigingOpslaan(object sender, RoutedEventArgs e)
        {
            await vestigingvm.AanmakenVestigingAsync(ond.OndernemingID, txtNaam.Text, txtAdres.Text);
            ContentDialog dialog = new ContentDialog() {
                Title = "Vestiging toegevoegd",
                Content = $"U hebt een vestiging toegevoegd aan {ond.Naam}. Met de Naam {txtNaam.Text} en adres {txtAdres.Text}",
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
            this.Frame.Navigate(typeof(OndernemingDetail), ond);
		}

	}
}
