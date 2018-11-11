using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class OverzichtOndernemingenViewModel
    {
        //var

        //prop
        public ObservableCollection<Onderneming> Ondernemingen { get; set; }

        //constructor
        public OverzichtOndernemingenViewModel()
        {
            //Ondernemingen = new ObservableCollection<Onderneming>(DummyDataSource.Ondernemingen/*DATASOURCE*/);
            Ondernemingen = Data.Ondernemingen;
        }

        //methods        
        public IEnumerable<Onderneming> ZoekOnderneming(Onderneming onderneming)
        {
            if (Ondernemingen.Contains(onderneming)) {
                return Ondernemingen.Where(x => x.Naam.Contains(onderneming.Naam));
            }
            else
            {
                throw new ArgumentException("De onderneming is niet gevonden");
            }
        }
        
    }
}
