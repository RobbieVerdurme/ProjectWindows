using System.Collections.Generic;

namespace StadsApp_Windows.Model
{
    public class Vestiging
    {
        public int VestigingID { get; set; }
        public string Naam { get; set; }
        public int Ondernemingid { get; set; }
        public string Adres { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();

        public Vestiging() { }

        public Vestiging(int ondernemingsId, string naam, string adres, double latitude, double longitude)
        {
            this.Ondernemingid = ondernemingsId;
            this.Naam = naam;
            this.Adres = adres;
            this.Latitude = latitude;
            this.Longitude = longitude;

        }

        public void EventToevoegen(Event evnt)
        {
            this.Events.Add(evnt);
        }
    }
}
