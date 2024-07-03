

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        [JsonIgnore]
        public Brand? Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public ICollection<WindInstrument> WindInstruments { get;} = new List<WindInstrument>();

        public ICollection<DrumnsPercussion> DrumnsPercussions { get; } = new List<DrumnsPercussion>();
        
        public ICollection<StringInstrument> StringInstruments { get; } = new List<StringInstrument>();
    }
}