using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace seyhun_celebioglu.Pages
{
    public class CrewinModel : PageModel
    {
        public List<Products> deger2;

        public List<string> deger;

        public string Data;
        public int id;
        public string brand;
        public string c;

        public void OnGet()
        {
            var client = new WebClient();
            var json = client.DownloadString("https://dummyjson.com/products/categories");
            var userPosts = JsonConvert.DeserializeObject<List<string>>(json);
            deger = userPosts;



        }
        public class Products
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }


            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("price")]
            public int Price { get; set; }

            [JsonProperty("discountPercentage")]
            public double DiscountPercentage { get; set; }

            [JsonProperty("rating")]
            public double Rating { get; set; }

            [JsonProperty("stock")]
            public int Stock { get; set; }

            [JsonProperty("brand")]
            public string Brand { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("thumbnail")]
            public string Thumbnail { get; set; }

            [JsonProperty("images")]
            public List<string> Images { get; set; }
        }

        public class Root
        {
            [JsonProperty("products")]
            public List<Products> Products { get; set; }

            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("skip")]
            public int Skip { get; set; }

            [JsonProperty("limit")]
            public int Limit { get; set; }
        }
        public void OnPost()
        {
            Data = Request.Form["product"];


            var client = new WebClient();

            var json = client.DownloadString("https://dummyjson.com/products/category/" + Data);
            Root root = JsonConvert.DeserializeObject<Root>(json);
            deger2 = root.Products;

            //id = a.products.Count();
            //for (int i = 0; i < id; i++)
            //{
            //     c = a.products[i].brand;
            //}
            //brand = c;

            //foreach (Root a in isimler)
            //{

            //}


        }
    }
}
