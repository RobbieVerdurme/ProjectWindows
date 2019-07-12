using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public abstract class Gebruiker
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ObservableCollection<Onderneming> Ondernemingenvolgen {get;set;}
        public string Access_token { get; set; }
    }
}
