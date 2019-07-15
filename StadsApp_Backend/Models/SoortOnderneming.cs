using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StadsApp_Backend.Models
{
    public class SoortOnderneming
    {
        [Key]
        public String SoortNaam { get; set; }
    }
}