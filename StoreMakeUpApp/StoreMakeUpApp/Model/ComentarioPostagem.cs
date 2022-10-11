using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace StoreMakeUpApp.Model
{
    public class ComentarioPostagem
    {
        [JsonProperty(PropertyName = "postId")]
        public int PostId { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName = "body")]
        public String Body { get; set; }
        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }
    }
}
