using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public class Ondernemer : Gebruiker
    {
        public override bool IsOndernemer() { return true; }
    }
}
