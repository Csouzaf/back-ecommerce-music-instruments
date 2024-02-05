using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    public class SoundBox
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string? SpeakerType { get; set; }
        public int? NumberSpeakers { get; set; }
        public string? Power { get; set; }
        public string? UsbConnect { get; set; }
        public string? Description { get; set; }
        public bool RechargableBattery { get; set; }
        public bool Bluetooth { get; set; }
        public bool LedLight { get; set; }
        public bool IncludesCharger { get; set; }
        public string? Color { get; set; }
        public double Price { get; set; }
        public string? Volt { get; set; }
        public string? Dimensions { get; set; }    
        
        [JsonIgnore]
        public Brand? Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public string Photo { get; set; }

        [JsonIgnore]
        public SoundBoxCategory SoundBoxCategory { get; set; }

        [ForeignKey("SoundBox")]
        public int SoundBoxId { get; set; }
    }
}