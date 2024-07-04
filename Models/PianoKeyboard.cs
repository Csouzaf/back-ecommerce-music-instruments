using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    [Table("piano_keyboard")]
    public class PianoKeyboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Column("name")]
        public string name { get; set; }

        [JsonIgnore]
        public Brand? brand { get; set; }

        [ForeignKey("Brand")]
        [Column("brand_id")]
        public int brandId { get; set; }

        [Column("photo")]
        public string photo { get; set; }

        [JsonIgnore]
        public PianoCategory pianoCategory { get; set; }

        [ForeignKey("PianoKeyboard")]
        [Column("piano_category_id")]
        public int pianoCategoryId { get; set; }

        
    }
}