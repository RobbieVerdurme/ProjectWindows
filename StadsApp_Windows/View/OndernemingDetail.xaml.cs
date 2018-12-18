using iTextSharp.text;
using iTextSharp.text.pdf;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
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
        private OndernemingDetailViewModel detailondernemingvm;
        public Onderneming GeselecteerdeOnderneming { get; set; }


        public OndernemingDetail()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GeselecteerdeOnderneming = (Onderneming)e.Parameter;
            detailondernemingvm = new OndernemingDetailViewModel();
            await detailondernemingvm.GetData();
            this.DataContext = GeselecteerdeOnderneming;
        }

        /************************************************************Toevoegen****************************************************************************/
        private void VestigingToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VestigingAanmaken), GeselecteerdeOnderneming);
        }

        private void PromotieToevoegen(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PromotieAanmaken), GeselecteerdeOnderneming);
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
            Paragraph p2 = new Paragraph($"Dankzij {GeselecteerdeOnderneming.Naam} heeft U een kortingsbon ontvangen ter waarde van {p.Percentage}%. " +
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
            PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Simon Anckaert\\Desktop", FileMode.Create));
            ContentDialog dialog = new ContentDialog()
            {
                Title = "PDF gedownload",
                Content = "PDF van deze promotie vindt U terug in uw Download folder",
                CloseButtonText = "OK"
            };
            dialog.ShowAsync();
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Vestiging v = GetVestiging((Vestiging)lvVestigingen.SelectedItem);
            v.Events.AddRange(detailondernemingvm.Events.Where(x => x.VestigingID.Equals(v.VestigingID)));
            this.Frame.Navigate(typeof(DetailVestiging), v);
        }

        private Vestiging GetVestiging(Vestiging selectedItem)
        {
            return GeselecteerdeOnderneming.Vestigingen.Where(x => x.VestigingID.Equals(selectedItem.VestigingID)).FirstOrDefault();
        }
    }
    //public sealed class SaveFileDialog : FileDialog { }
}


