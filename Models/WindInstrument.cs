using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ecommerce_music_back.Models
{
    [Table("wind_instrument")]
    public class WindInstrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; } 
        
        public string? Width { get; set; }

        public string? Color { get; set; }

        [JsonIgnore]
        public Model Model { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }

        [JsonIgnore]
        public Brand? Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public string Photo { get; set; }

        [JsonIgnore]
        public WindCategory? WindCategory { get; set; }

        [ForeignKey("WindInstrument")]
        public int? WindInstrumentCategoryId { get; set; }
    }
}