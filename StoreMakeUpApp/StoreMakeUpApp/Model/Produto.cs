using System;
using System.Collections.Generic;
using System.Text;

namespace StoreMakeUpApp.Model
{
    public class Produto
    {
        public int id { get; set; }
        public String brand { get; set; }
        public String name { get; set; }
        public Double price { get; set; }
        public String image_link { get; set; }
        public String product_link { get; set; }
        public Double rating { get; set; }
        public String product_type { get; set; }
        public String product_api_url { get; set; }
    }
}
