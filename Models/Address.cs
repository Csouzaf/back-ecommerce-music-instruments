

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ecommerce_music_back.Models
{
    public class Address
    {
        [JsonPropertyName("cep")]
        public string? cep { get; set; }

        [JsonPropertyName("state")]
        public string? state { get; set; }

        [JsonPropertyName("city")]
        public string? city { get; set; }

        [JsonPropertyName("neighborhood")]
        public string? neighborhood { get; set; }

        [JsonPropertyName("street")]
        public string? street { get; set; }

        [JsonPropertyName("service")]
        public string? service { get; set; }
    }
}