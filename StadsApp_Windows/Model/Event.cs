using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Event
    {
        public int OndernemingsID { get; set; }
        public int EventId { get; set; }
        public String Naam { get; set; }
        public String Beschrijving { get; set; }
        public String Adres { get; set; }
        public DateTime Date { get; set; }

        public Event() {}
        
        public Event(int ondernemingsID, String naam, String beschrijving, String adres, DateTime date) {
            this.OndernemingsID = ondernemingsID;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Adres = adres;
            this.Date = date;
        }
    }
}
