using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Vestiging
    {
        private GoogleLocationService locationservice;
        public int VestigingID { get; set; }
        public string Naam { get; set; }
        public int Ondernemingid { get; set; }
        public string Adres { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();

        public Vestiging() { }

        public Vestiging(int ondernemingsId, string naam, string adres)
        {
            this.Naam = naam;
            this.Adres = adres;
            this.Ondernemingid = ondernemingsId;
            /*if(!adres.Equals("") || adres != null)
            {
                SetLatAndLong();
            }*/
            
        }

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

        private void SetLatAndLong()
        {
            if(locationservice == null) {
                locationservice = new GoogleLocationService("AIzaSyBNlBpJ6zueh7xNcd3bj2hcgDVlK5bGDKQ");
            }
            
            MapPoint point = locationservice.GetLatLongFromAddress(Adres);

            this.Longitude = point.Longitude;
            this.Latitude = point.Latitude;
        }
    }
}
