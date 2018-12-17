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
        public int VestigingID { get; set; }
        public int EventId { get; set; }
        public String Naam { get; set; }
        public String Beschrijving { get; set; }
        public DateTime Date { get; set; }

        public Event() {}
        
        public Event(int vestigingID, String naam, String beschrijving, DateTime date) {
            this.VestigingID = vestigingID;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Date = date;
        }

    }
}
