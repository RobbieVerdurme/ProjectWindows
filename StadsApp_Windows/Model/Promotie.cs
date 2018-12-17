using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Promotie
    {
        public int OndernemingID { get; set; }
        public int PromotieID { get; set; }
        public double Percentage { get; set; }
        public String Beschrijving { get; set; }
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }

        public Promotie() { }

        public Promotie(int ondernemingId, double percentage, String beschrijving, DateTime van, DateTime tot) {
            this.OndernemingID = ondernemingId;
            this.Percentage = percentage;
            this.Beschrijving = beschrijving;
            this.Van = van;
            this.Tot = tot;
        }
    }
}
