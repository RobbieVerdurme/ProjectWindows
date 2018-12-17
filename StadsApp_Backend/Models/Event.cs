using Newtonsoft.Json;
using StadsApp_Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Event
    {
        [ForeignKey("Onderneming")]
        public int Ondernemingsid { get; set; }
        [Key]
        public int EventId { get; set; }
        public String Naam { get; set; }
        public String Beschrijving { get; set; }
        public String Adres { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public virtual Onderneming Onderneming { get; set; }
    }
}
