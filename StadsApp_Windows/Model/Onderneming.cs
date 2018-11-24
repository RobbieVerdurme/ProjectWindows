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

        public int OndernemingID { get; set; }
        public String Naam { get; set; }
        public String Soort { get; set; }
        public List<Vestiging> Vestigingen { get; set; } = new List<Vestiging>();

        public Onderneming()
        {
            VestigingToevoegen(new Vestiging(1,"Hallooo", "Deerlijkseweg 204"));
            VestigingToevoegen(new Vestiging(2, "Hallooo222", "Spitaalstraat 22"));
        }



        public void VestigingToevoegen(Vestiging vestiging)
        {
            this.Vestigingen.Add(vestiging);
        }
    }
}
