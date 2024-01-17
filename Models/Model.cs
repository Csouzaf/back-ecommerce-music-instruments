

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        long id { get; set; }
        
        private string nameModel { get; set; }

        [JsonIgnore]
        private Brand? brand { get; set; }

        [ForeignKey("Brand")]
        private int brandId { get; set; }
    }
}