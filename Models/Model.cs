

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    public class Model
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

        public ICollection<WindInstrument> windInstruments { get;} = new List<WindInstrument>();

        public ICollection<DrumnsPercussion> drumnsPercussions { get; } = new List<DrumnsPercussion>();
        
        public ICollection<StringInstrument> stringInstruments { get; } = new List<StringInstrument>();
    }
}