using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StadsApp_Backend.Models
{
    public class Vestiging
    {
        [Key]
        public int VestigingId { get; set; }
        [ForeignKey("Onderneming")]
        public int Ondernemingid { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [JsonIgnore]
        public virtual Onderneming Onderneming { get; set; }
    }
}