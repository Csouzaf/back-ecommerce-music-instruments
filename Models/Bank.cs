

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ecommerce_music_back.Models
{
    public class Bank
    {
   
        [JsonPropertyName("ispb")]
        public string? ispb { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("code")]
    
        public int? code { get; set; }

        [JsonPropertyName("fullName")]
        public string? fullName { get; set; }
    }
}