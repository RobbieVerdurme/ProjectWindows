using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    class VestigingDetailViewModel
    {
        public async Task<VestigingDetailViewModel> Verwijder(Vestiging v)
        {
            HttpClient client = new HttpClient();
            var json = await client.DeleteAsync(new Uri("http://localhost:53331/api/vestigings/" + v.VestigingID));
            return this;
        }
    }
}
