using StadsApp_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Backend.Model
{
    public class Onderneming //: INotifyPropertyChanged
    {
		public int OndernemingID { get; set; }
        public String Naam { get; set; }
        public String Soort { get; set; }
		public String Adres { get; set; }
		public virtual ICollection<Vestiging> Vestigings { get; set; }

		public Onderneming()
        {

        }

		public Onderneming(int ondernemingId, string naam, string adres)//, string soort)
		{
			OndernemingID = ondernemingId;
			Naam = naam;
			Adres = adres;
			//Soort = soort;
		}

		public void VestigingToevoegen(Vestiging vestiging)
        {
            this.Vestigings.Add(vestiging);
        }
    }
}
