using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public sealed partial class OndernemingAanmaken : Page
    {
        //var
        private OndernemingAanmakenViewModel ondernemingvm;
        private OndernemingRepository OndernemingRepo;
        
        //constr
        public OndernemingAanmaken()
        {
            this.InitializeComponent();
        }

        //meth
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.OndernemingRepo = (OndernemingRepository)e.Parameter;
            ondernemingvm = new OndernemingAanmakenViewModel(OndernemingRepo);
            this.DataContext = ondernemingvm;
        }

        private async void btnToevoegenClicked(object sender, RoutedEventArgs e)
        {
            Onderneming onderneming = new Onderneming()
            {
                Naam = txtNaam.Text,
                Adres = txtAdres.Text,
                Soort = ondernemingvm.Soorten[cboSoort.SelectedIndex]
            };
            await ondernemingvm.AanmakenOndernemingAsync(onderneming);
            this.Frame.Navigate(typeof(OverzichtOndernemingen), OndernemingRepo);
        }
    }
}
