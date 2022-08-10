using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreMakeUpApp.Model
{
    public class PostagemUsuario
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public String Title { get; set; }
        [JsonProperty(PropertyName = "body")]
        public String Body { get; set; }
    }
}
