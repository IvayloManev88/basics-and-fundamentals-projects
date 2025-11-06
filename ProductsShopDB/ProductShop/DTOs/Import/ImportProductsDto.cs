using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Import
{
    public class ImportProductsDto
    {
        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; } = null!;
        [JsonProperty("Price")]
        [Required]
        public string Price { get; set; } = null!;
        [JsonProperty("SellerId")]
        [Required]
        public string SellerId { get; set; } = null!;
        [JsonProperty("BuyerId")]
        
        public string? BuyerId { get; set; }


        
    }
}
