using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ecommerce_music_back.Models
{
    public class StringInstrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        [JsonIgnore]
        public Brand? Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public string? Color {get; set; }

        public string? NumberStrings { get; set; }

        public string? NumberPickups { get; set; }

        public string WoodType{ get; set; }

        public string? HandOrientation { get; set; }

        public bool WithLever { get; set; }

        public string Photo { get; set; }

        [JsonIgnore]
        public StringsCategory StringsCategory { get; set; }

        [ForeignKey("StringsInstrument")]
        public int StringsInstrumentCategoryId { get; set; }
       
    }
}