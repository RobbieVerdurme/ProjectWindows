using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model.message
{
    class GebruikerLoggedInMessage
    {
        public Gebruiker gebruiker { get; set; } 

        public GebruikerLoggedInMessage(Gebruiker g)
        {
            gebruiker = g;
        }
    }
}
