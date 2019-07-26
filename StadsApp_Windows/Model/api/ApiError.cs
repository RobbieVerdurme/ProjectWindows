using Newtonsoft.Json;
using StadsApp_Windows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StadsApp_Backend.Models
{

    public class ApiError
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("ModelState")]
        public JsonObjectAttribute ModelState { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}