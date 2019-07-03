using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.Repository;
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
    public sealed partial class OverzichtPromoties : Page
    {
        //var
        public OverzichtPromotiesViewModel overzichtPromotiesvm;
        public OverzichtOndernemingenViewModel overzichtOndvm;
        private OndernemingRepository OndernemingRepo;
        //constr
        public OverzichtPromoties()
        {
            this.InitializeComponent();
        }
        //meth
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            this.OndernemingRepo = (OndernemingRepository)e.Parameter;
            this.overzichtPromotiesvm = new OverzichtPromotiesViewModel(OndernemingRepo);
            this.overzichtOndvm = new OverzichtOndernemingenViewModel(OndernemingRepo);
            this.DataContext = overzichtPromotiesvm;
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //repo?
            Promotie p = (Promotie)lvPromoties.SelectedItem;
            Onderneming o = overzichtPromotiesvm.Ondernemingen.Where(ond => ond.OndernemingID.Equals(p.OndernemingID)).FirstOrDefault();
            o.Vestigingen.AddRange(overzichtOndvm.Vestigingen.Where(x => x.Ondernemingid.Equals(o.OndernemingID)));
            o.Promoties.AddRange(overzichtPromotiesvm.Promoties.Where(x => x.OndernemingID.Equals(o.OndernemingID)));
            this.Frame.Navigate(typeof(OndernemingDetail), o);
        }
    }
}
