using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class OndernemingAanmakenViewModel
    {

        public void AanmakenOnderneming(string naam, string adres, string soort)
        {
           Onderneming onderneming = new Onderneming()
            {
                Naam = naam,
                Adres = adres,
                Soort = soort
            };

            //Data.Ondernemingen.Add(onderneming);
        }
    }
}
