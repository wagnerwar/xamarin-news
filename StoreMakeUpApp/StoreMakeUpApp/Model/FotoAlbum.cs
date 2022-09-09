using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreMakeUpApp.Model
{
    public class FotoAlbum
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public String Title { get; set; }
        [JsonProperty(PropertyName = "url")]
        public String Url { get; set; }
        [JsonProperty(PropertyName = "thumbnailUrl")]
        public String Thumbnail { get; set; }
    }
}
