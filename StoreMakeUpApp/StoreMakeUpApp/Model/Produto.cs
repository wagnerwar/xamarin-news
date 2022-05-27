using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreMakeUpApp.Model
{
    public class Produto
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "brand")]
        public String brand { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String name { get; set; }
        [JsonProperty(PropertyName = "email")]
        public String email { get; set; }
        /*[JsonProperty(PropertyName = "image_link")]
        public String image_link { get; set; }
        [JsonProperty(PropertyName = "product_link")]
        public String product_link { get; set; }
        [JsonProperty(PropertyName = "rating")]
        public Double? rating { get; set; }
        [JsonProperty(PropertyName = "product_type")]
        public String product_type { get; set; }
        [JsonProperty(PropertyName = "product_api_url")]
        public String product_api_url { get; set; }
        [JsonProperty(PropertyName = "price_sign")]
        public String price_sign { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public String currency { get; set; }
        [JsonProperty(PropertyName = "website_link")]
        public String website_link { get; set; }
        [JsonProperty(PropertyName = "description")]
        public String description { get; set; }
        [JsonProperty(PropertyName = "category")]
        public String category { get; set; }
        [JsonProperty(PropertyName = "tag_list")]
        public List<String> tag_list { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public String created_at { get; set; }
        [JsonProperty(PropertyName = "updated_at")]
        public String updated_at { get; set; }
        [JsonProperty(PropertyName = "api_featured_image")]
        public String api_featured_image { get; set; }
        [JsonProperty(PropertyName = "product_colors")]
        public List<ProductColor> product_colors { get; set; }*/

    }
    public class ProductColor
    {
        [JsonProperty(PropertyName = "hex_value")]
        public String hex_value { get; set; }
        [JsonProperty(PropertyName = "colour_name")]
        public String colour_name { get; set; }
    }
}
