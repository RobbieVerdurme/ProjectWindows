﻿using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
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
			//await overzichtvm.GetData();
            this.DataContext = overzichtvm;
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







        /************************************************************DETAIL PAGINA****************************************************************************/

        private Onderneming GetOnderneming(Onderneming selectedItem)
        {
            return overzichtvm.Ondernemingen.Where(x => x.OndernemingID == selectedItem.OndernemingID).FirstOrDefault();
        }

        private void StackPanel_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OndernemingDetail), GetOnderneming((Onderneming)lvOndernemingen.SelectedItem));
        }
    }
}
