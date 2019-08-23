using iTextSharp.text;
using iTextSharp.text.pdf;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel;
using StadsApp_Windows.ViewModel.ParamDTO;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.IO;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
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
        private async void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Promotie p = (Promotie)lvPromoties.SelectedItem;

                Document doc = new Document();
                /*string pathName = "";
                try
                {
                    StorageFolder folder = await DownloadsFolder.CreateFolderAsync("Promoties");
                    pathName = folder.Path;
                } catch(Exception ex)
                {
                    string localfolder = ApplicationData.Current.LocalFolder.Path;
                    var array = localfolder.Split('\\');
                    var username = array[2];
                    string downloads = @"C:\Users\" + username + @"\Downloads\440f7795-f868-46cf-9c90-16733e673bb3_zp8g5bj0fsrbp!App\Promoties";
                    pathName = downloads;
                }
                string fileName = p.Beschrijving + ".pdf";
                string fullName = Path.Combine(pathName, fileName);
                //PdfWriter.GetInstance(doc, new FileStream(fullName, FileMode.Create));*/
                StorageFile file = await DownloadsFolder.CreateFileAsync(p.Beschrijving + ".pdf");


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
                //await Windows.Storage.FileIO.WriteTextAsync(file, /*doc.ToString()*/"Halloo");
                
                /*byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";

                string pdfName = "User";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();*/
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "PDF gedownload",
                    Content = "PDF van deze promotie vindt U terug in uw Download folder",
                    CloseButtonText = "OK"
                };
                dialog.ShowAsync();
            }
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


