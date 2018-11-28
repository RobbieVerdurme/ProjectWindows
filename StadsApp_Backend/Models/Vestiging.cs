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
        public int Onderneming { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
    }
}