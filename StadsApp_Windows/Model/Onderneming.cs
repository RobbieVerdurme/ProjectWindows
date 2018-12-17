using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Onderneming //: INotifyPropertyChanged
    {
		private int v;

		public int OndernemingID { get; set; }
        public String Naam { get; set; }
        public String Soort { get; set; }
		public String Adres { get; set; }
        public List<Vestiging> Vestigingen { get; set; } = new List<Vestiging>();
        

        public Onderneming()
        {

        }

		public Onderneming(int v, string naam, string adres, string soort)
		{
			this.v = v;
			Naam = naam;
			Adres = adres;
			Soort = soort;
		}

		public void VestigingToevoegen(Vestiging vestiging)
        {
            this.Vestigingen.Add(vestiging);
        }

        
    }
}
