using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Backend.Model
{
    public class Promotie
    {
        [ForeignKey("Onderneming")]
        public int OndernemingID { get; set; }
        [Key]
        public int PromotieID { get; set; }
        public double Percentage { get; set; }
        public String Beschrijving { get; set; }
        public DateTime Van { get; set; }
        public DateTime Tot { get; set; }
        [JsonIgnore]
        public virtual Onderneming Onderneming { get; set; }
    }
}
