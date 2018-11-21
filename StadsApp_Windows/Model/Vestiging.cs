using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Vestiging
    {
        public int VestigingID { get; set; }
        public string Naam { get; set; }
        public int OndernemingsID { get; set; }
        public string Adres { get; set; }


        public Vestiging(int ondernemingsId, string naam, string adres)
        {
            this.Naam = naam;
            this.Adres = adres;
            this.OndernemingsID = ondernemingsId;
        }
    }
}
