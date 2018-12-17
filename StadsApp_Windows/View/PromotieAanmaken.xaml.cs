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
    public sealed partial class PromotieAanmaken : Page
    {
        public PromotieAanmakenViewModel promotievm;
        public Onderneming GeselecteerdeOnderneming;

        public PromotieAanmaken()
        {
            this.InitializeComponent();
            promotievm = new PromotieAanmakenViewModel(); 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GeselecteerdeOnderneming = (Onderneming)e.Parameter;
            this.DataContext = promotievm;
        }

        private async void PromotieOpslaan(object sender, RoutedEventArgs e)
        {
            double percentage;
            Promotie promotie = new Promotie(GeselecteerdeOnderneming.OndernemingID, Double.TryParse(txtPercentagePromotie.Text, out percentage) ? percentage : 0.0, txtBeschrijvingPromotie.Text, calVan.Date.Value.Date, calTot.Date.Value.Date);
            await promotievm.AanmakenPromotieAsync(promotie);
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Promotie toegevoegd",
                Content = $"U hebt een Promotie toegevoegd aan {GeselecteerdeOnderneming.Naam}. Met de beschrijving {txtBeschrijvingPromotie.Text} en een percentage van {percentage}",
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
            GeselecteerdeOnderneming.Promoties.Add(promotie);
            this.Frame.Navigate(typeof(OndernemingDetail), GeselecteerdeOnderneming);
        }
    }
}
