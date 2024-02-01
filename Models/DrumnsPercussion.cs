using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    public class DrumnsPercussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Photo { get; set; }

        public string Material { get; set; }

        public string Height { get; set; }

        public string Width { get; set; }

        [MaxLength(10000)]
        public string Description { get; set; }
        
        public bool HasBaqueta { get; set; }

        public bool IsNewOrUsed { get; set; }

        // [JsonIgnore]
        // public Brand? Brand { get; set; }

        // [ForeignKey("Brand")]
        // public int BrandId { get; set; }
    }
}