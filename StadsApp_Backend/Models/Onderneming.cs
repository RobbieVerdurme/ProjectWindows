using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StadsApp_Backend.Models
{
    public class Onderneming
    {
        public int OndernemingID { get; set; }
        public String Naam { get; set; }
        public String Adres { get; set; }
        public String Soort { get; set; }
        public virtual ICollection<Vestiging> Vestigings { get; set; }
    }
}