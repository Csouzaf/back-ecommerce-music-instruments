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
        public int id { get; set; }
        
        [Column("name")]
        public string name { get; set; }

        [Column("width")]
        public string? width { get; set; }

        [Column("color")]
        public string? color { get; set; }

        [JsonIgnore]
        public Model model { get; set; }

        [ForeignKey("Model")]
        public int modelId { get; set; }

        [JsonIgnore]
        public Brand? brand { get; set; }

        [ForeignKey("Brand")]
        [Column("brand_id")]
        public int brandId { get; set; }

        [Column("photo")]
        public string photo { get; set; }

        [JsonIgnore]
        public WindCategory? windCategory { get; set; }

        [ForeignKey("WindInstrument")]
        [Column("wind_instrument_categoryId")]
        public int? windInstrumentCategoryId { get; set; }
    }
}