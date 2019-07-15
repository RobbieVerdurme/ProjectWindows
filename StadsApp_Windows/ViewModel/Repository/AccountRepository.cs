using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using StadsApp_Backend.Models;
using StadsApp_Windows.Model;
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
            this.BaseUrl = "http://localhost:53331";
        }

        //metho
        public async Task<string> Login(string username, string password)
        {
            //Login user
            client.BaseAddress = new Uri($"{BaseUrl}");
            var request = new HttpRequestMessage(HttpMethod.Post, "/token");

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
            keyValues.Add(new KeyValuePair<string, string>("username", username));
            keyValues.Add(new KeyValuePair<string, string>("password", password));

            request.Headers.Add("Accept", "Application/json");
            //request.Headers.Accept("application/json");
            request.Content = new FormUrlEncodedContent(keyValues);
            var response = await client.SendAsync(request);

            //Log error message
            if (!response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
                /*ApiError error = JsonConvert.DeserializeObject<ApiError>(content);
                
                if (error.Error == "invalid_grant")
                {
                    return "Invalid credentials";
                }
                else
                {
                    return error.Error + " " + error.ErrorDescription;
                }
                */
                return content;
            }

            //Save user in global variables
            Ondernemer o = new Ondernemer();
            o.Username = username;

            var result = response.Content.ReadAsStringAsync().Result;
            Dictionary<string, string> tokenDictionary =
               JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            string token = tokenDictionary["access_token"];
            o.Access_token = token;

            Messenger.Default.Send<GebruikerLoggedInMessage>(new GebruikerLoggedInMessage(o));

            //Save user credentials
            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Add(new Windows.Security.Credentials.PasswordCredential("StadsApp", username, password));
            return "Error";
        }

        public async Task<string> Register(string username, string password, string passwordconfirm)
        {
            //Register user
            var registerdata = new RegisterBindingModel() { Email = username, Password = password, ConfirmPassword = passwordconfirm };
            var registerJson = JsonConvert.SerializeObject(registerdata);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync($"{BaseUrl}/api/account/register", new StringContent(registerJson, System.Text.Encoding.UTF8, "application/json"));

            //Log error message
            if (!res.IsSuccessStatusCode)
            {
                return res.StatusCode + " " + res.ReasonPhrase;
            }
            else
            {
                return "Error";
            }
        }
    }
}
