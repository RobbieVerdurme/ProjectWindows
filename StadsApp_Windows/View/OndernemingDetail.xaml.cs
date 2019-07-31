using iTextSharp.text;
using iTextSharp.text.pdf;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Appointments;
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
    public sealed partial class OndernemingDetail : Page
    {
        //var
        private OndernemingDetailViewModel detailondernemingvm;
        private OndernemingRepository OndernemingRepo;

        //constr
        public OndernemingDetail()
        {
            this.InitializeComponent();
        }

        //meth
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ParamDTO param = (ParamDTO)e.Parameter;
            this.OndernemingRepo = param.ondernemingRepo;
            this.detailondernemingvm = new OndernemingDetailViewModel(param.ondernemingRepo, param.gekozenOnderneming);
            this.DataContext = detailondernemingvm;
        }

        /************************************************************Toevoegen****************************************************************************/
        private void VestigingToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VestigingAanmaken), new ParamDTO() {
            gekozenOnderneming = this.detailondernemingvm.GeselecteerdeOnderneming,
            ondernemingRepo = this.OndernemingRepo
            });
        }

        private void PromotieToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PromotieAanmaken), new ParamDTO() {
                gekozenOnderneming = this.detailondernemingvm.GeselecteerdeOnderneming,
                ondernemingRepo = this.OndernemingRepo
            });
        }
        
        /************************************************************Promotie pdf Genereren****************************************************************************/
        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*OpenFileDialog 
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }*/

            Promotie p = (Promotie)lvPromoties.SelectedItem;

            Document doc = new Document();
            
            doc.Open();
            Paragraph p1 = new Paragraph("Veel plezier met uw kortingsbon!!");
            Paragraph p2 = new Paragraph($"Dankzij {this.detailondernemingvm.GeselecteerdeOnderneming.Naam} heeft U een kortingsbon ontvangen ter waarde van {p.Percentage}%. " +
                $"Deze kan gebruikt worden in alle winkels van onze onderneming");
            Paragraph p3 = new Paragraph($"Deze kortingsbon is geldig vanaf {p.Van} tot {p.Tot}.");
            Paragraph p4 = new Paragraph($"{p.Beschrijving}");
            Paragraph p5 = new Paragraph("Wij wensen u alvast veel plezier met onze kortingsbon");
            doc.Add(p1);
            doc.Add(p2);
            doc.Add(p3);
            doc.Add(p4);
            doc.Add(p5);
            doc.Close();
            PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Boeferrob\\Downloads\\file.pdf", FileMode.Create));
            ContentDialog dialog = new ContentDialog()
            {
                Title = "PDF gedownload",
                Content = "PDF van deze promotie vindt U terug in uw Download folder",
                CloseButtonText = "OK"
            };
            dialog.ShowAsync();
        }

        /************************************************************Naar vestiging gaan****************************************************************************/
        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Vestiging v = GetVestiging((Vestiging)lvVestigingen.SelectedItem);
            v.Events.AddRange(detailondernemingvm.Events.Where(x => x.VestigingID.Equals(v.VestigingID)));
            this.Frame.Navigate(typeof(DetailVestiging), new ParamDTO()
            {
                gekozenVestiging = v,
                ondernemingRepo = this.OndernemingRepo
            });
        }

        private Vestiging GetVestiging(Vestiging selectedItem)
        {
            return this.detailondernemingvm.GeselecteerdeOnderneming.Vestigingen.Where(x => x.VestigingID.Equals(selectedItem.VestigingID)).FirstOrDefault();
        }

        public void Verwijderen(object sender, RoutedEventArgs e)
        {
            detailondernemingvm.VerwijderOnderneming();
            this.Frame.Navigate(typeof(OverzichtOndernemingen), this.OndernemingRepo);
        }
    }
    //public sealed class SaveFileDialog : FileDialog { }
}


