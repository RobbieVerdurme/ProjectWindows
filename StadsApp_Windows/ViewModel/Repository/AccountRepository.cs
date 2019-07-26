using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StadsApp_Backend.Models;
using StadsApp_Windows.Model;
using StadsApp_Windows.Model.Exceptions;
using StadsApp_Windows.Model.message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StadsApp_Windows.ViewModel.Repository
{
    public class AccountRepository
    {
        //var
        private HttpClient client;
        private string BaseUrl;

        //const
        public AccountRepository()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("http://localhost:53331");
        }

        //metho
        public async Task Login(string username, string password)
        {
            //Login user
            var request = new HttpRequestMessage(HttpMethod.Post, "/token");

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
            keyValues.Add(new KeyValuePair<string, string>("username", username));
            keyValues.Add(new KeyValuePair<string, string>("password", password));

            request.Headers.Add("Accept", "Application/json");
            request.Content = new FormUrlEncodedContent(keyValues);
            var response = await client.SendAsync(request);

            //Log error message
            if (!response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
                ApiError error = JsonConvert.DeserializeObject<ApiError>(content);
                
                if (error.Error == "invalid_grant")
                {
                    throw new InvalidCredentialsException();
                }
                throw new Exception(error.Error);
            }

            //Save user in global variables
            Ondernemer o = new Ondernemer();
            o.Username = username;  

            var result = response.Content.ReadAsStringAsync().Result;
            Dictionary<string, string> tokenDictionary =
               JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            string token = tokenDictionary["access_token"];
            o.Access_token = token;

            //Send new loggedinuserevent
            Messenger.Default.Send<GebruikerLoggedInMessage>(new GebruikerLoggedInMessage(o));

            //Save user credentials
            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Add(new Windows.Security.Credentials.PasswordCredential("StadsApp", username, password));
        }

        public async Task Register(string username, string password, string passwordconfirm)
        {
            //Register user
            var registerdata = new RegisterBindingModel() { Email = username, Password = password, ConfirmPassword = passwordconfirm };
            var registerJson = JsonConvert.SerializeObject(registerdata);
            
            var res = await client.PostAsync("/api/account/register", new StringContent(registerJson, System.Text.Encoding.UTF8, "application/json"));

            //Log error message
            if (!res.IsSuccessStatusCode)
            {
                String content = await res.Content.ReadAsStringAsync();
                var err = JObject.Parse(content);

                try
                {
                    var mes = err["ModelState"][""][0].ToString();
                    throw new InvalidCredentialsException(mes);
                }
                catch(NullReferenceException ex)
                {
                    throw new InvalidCredentialsException("Bad Request from server");
                }
                
            }
        }
    }
}
