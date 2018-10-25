using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.Model
{
    public static class DummyDataSource
    {
        public static List<Onderneming> Ondernemingen { get; set; } = new List<Onderneming>()
        {
            new Onderneming() {Naam="test", Adres="BakkerStraat", Soort="bakker"}
        };
    }
}
