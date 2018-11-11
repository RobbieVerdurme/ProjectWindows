﻿using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            overzichtvm = new OverzichtOndernemingenViewModel();
            this.DataContext = overzichtvm;
        }

        private void btnZoekOnderneming_Click(object sender, RoutedEventArgs e)
        {
            /*Zoeken in lijst van overzicht ondernemingen view model naar de tekst in txtZoekOnderneming*/
            overzichtvm.ZoekOnderneming(new Onderneming() { Naam = txtZoekOnderneming.Text });
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Console.Out.Write(e.ClickedItem.ToString());
        }
    }
}
