using Newtonsoft.Json;
using StadsApp_Windows.Model;
using StadsApp_Windows.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class OverzichtOndernemingenViewModel
    {
        //prop
        private OndernemingRepository OndernemingRepo;

        public ObservableCollection<Onderneming> Ondernemingen { get; set; }
        public ObservableCollection<Onderneming> GefilterdeLijst { get; set; }
        public ObservableCollection<Vestiging> Vestigingen { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<Promotie> Promoties { get; set; }
        public ObservableCollection<string> Soorten { get; set; }

        //constructor
        public OverzichtOndernemingenViewModel(OndernemingRepository ondRepo){
            this.OndernemingRepo = ondRepo;
            vulData();
        }


        //methods
        /************************************************************Properties opvullen****************************************************************************/
        public void vulData()
        {
            this.Ondernemingen = OndernemingRepo.Ondernemingen;
            this.GefilterdeLijst = Ondernemingen;
            this.Vestigingen = OndernemingRepo.Vestigingen;
            this.Events = OndernemingRepo.Events;
            this.Promoties = OndernemingRepo.Promoties;
            this.Soorten = OndernemingRepo.Soorten;
        }

        /************************************************************FILTER****************************************************************************/
        public IEnumerable<Onderneming> ZoekOnderneming(String tekst, String soort)
        {
            GefilterdeLijst.Clear();
            var o = new List<Onderneming>();
            o = Ondernemingen.ToList().Where(onderneming => onderneming.Naam.Contains(tekst) && onderneming.Soort.Contains(soort)).ToList();
            
            if (o.Count > 0)
            {
                o.ForEach(ond => GefilterdeLijst.Add(ond));
            } else
            {
                //o = Ondernemingen.ToList();//.Where(ond => ond.Naam.Contains("") && ond.Soort.Contains("")).ToList();
                //o.ForEach(ond => GefilterdeLijst.Add(ond));
            }
            return GefilterdeLijst.OrderBy(ond => ond.Naam).ThenBy(ond => ond.Soort);
            /*var o = new List<Onderneming>();

            if((soort.Trim().Equals("") || soort.Equals(null)) && (tekst.Trim().Equals("") || tekst.Equals(null))) {
                GefilterdeLijst.Clear();
                Ondernemingen.ToList().ForEach(e => GefilterdeLijst.Add(e));
                return GefilterdeLijst;
            }
            else if(soort.Trim().Equals("") || soort.Equals(null))
            {
                o = Ondernemingen.ToList().FindAll(onderneming => onderneming.Naam.Contains(tekst));
            }
            else if((tekst.Trim().Equals("") || tekst.Equals(null)) && !soort.Equals("Alle"))
            {
                o = Ondernemingen.ToList().FindAll(onderneming => onderneming.Soort.Equals(soort));
            }

            if (o.Count > 0)
            {
                GefilterdeLijst.Clear();
                o.ForEach(e => GefilterdeLijst.Add(e));
                return GefilterdeLijst;
            }
            else
            {
                //throw new ArgumentException("De onderneming is niet gevonden");
                GefilterdeLijst.Clear();
            }
            return GefilterdeLijst;



            /*if (soort.Trim().Equals("") || soort.Equals(null))
            {
                if (tekst == null || tekst.Trim().Equals(""))
                {
                    GefilterdeLijst.Clear();
                    Ondernemingen.ToList().ForEach(e => GefilterdeLijst.Add(e));
                    return GefilterdeLijst;
                }
                o = Ondernemingen.ToList().FindAll(onderneming => onderneming.Naam.Contains(tekst) /*|| onderneming.Adres.Contains(tekst)*//*);*/

                
            /*} else if()


            if (o.Count > 0)
            {
                GefilterdeLijst.Clear();
                o.ForEach(e => GefilterdeLijst.Add(e));
                return GefilterdeLijst;
            }
            else
            {
                //throw new ArgumentException("De onderneming is niet gevonden");
                GefilterdeLijst.Clear();
            }

            return GefilterdeLijst;*/


        }
        
    }
}
