﻿using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel
{
    public class VestigingAanmakenViewModel
    {
        /************************************************************AANMAKEN VESTIGING****************************************************************************/
        public async Task AanmakenVestigingAsync(int ondernemingsId, string naam, string adres)
        {
            Vestiging vestiging = new Vestiging(ondernemingsId, naam, adres);
            
            var vestigingsJson = JsonConvert.SerializeObject(vestiging);

            HttpClient client = new HttpClient();

            var res = await client.PostAsync("http://localhost:59258/api/Vestigings",
                new StringContent(vestigingsJson,
                System.Text.Encoding.UTF8, "application/json"));
            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //success
                //lst.Add(onderneming);
            }
        }
    }
}
