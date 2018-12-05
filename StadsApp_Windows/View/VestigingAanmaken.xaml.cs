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
    public sealed partial class OndernemingAanmaken : Page
    {
        private OndernemingAanmakenViewModel ondernemingvm;

        public OndernemingAanmaken()
        {
            this.InitializeComponent();
			ondernemingvm = new OndernemingAanmakenViewModel();
            this.DataContext = ondernemingvm;
        }

        private async void btnToevoegenClicked(object sender, RoutedEventArgs e)
        {
            await ondernemingvm.AanmakenOndernemingAsync(txtNaam.Text, txtAdres.Text, "testsoort");
		}
    }
}
