using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreMakeUpApp.Model
{
    public class Usuario
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "brand")]
        public String brand { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String name { get; set; }
        [JsonProperty(PropertyName = "email")]
        public String email { get; set; }
        [JsonProperty(PropertyName = "username")]
        public String username { get; set; }
        [JsonProperty(PropertyName = "address")]
        public Adress address { get; set; }
        public List<PostagemUsuario> postagens { get; set; }
    }
    public class Adress
    {
        [JsonProperty(PropertyName = "street")]
        public String Street { get; set; }
        [JsonProperty(PropertyName = "suite")]
        public String Suite { get; set; }
        [JsonProperty(PropertyName = "city")]
        public String City { get; set; }
        [JsonProperty(PropertyName = "zipcode")]
        public String ZipCode { get; set; }
    }
}
