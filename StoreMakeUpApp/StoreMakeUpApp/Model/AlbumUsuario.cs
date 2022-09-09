using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreMakeUpApp.Model
{
    public class AlbumUsuario
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public String Title { get; set; }
    }
}
