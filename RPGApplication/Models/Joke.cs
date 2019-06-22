using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    public class Joke
    {

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("pergunta")]
        public string pergunta { get; set; }
        [JsonProperty("resposta")]
        public string resposta { get; set; }


    }
}