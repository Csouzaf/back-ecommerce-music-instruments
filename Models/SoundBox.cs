using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;

namespace ecommerce_music_back.Models
{
    [Table("sound_box")]
    public class SoundBox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Column("name")]
        public string name { get; set; }

        [Column("speaker_type")]
        public string? speakerType { get; set; }

        [Column("number_speakers")]
        public int? numberSpeakers { get; set; }

        [Column("power")]
        public string? power { get; set; }
          
        [Column("usb_connect")]
        public string? usbConnect { get; set; }

        [MaxLength(10000)]
        [Column("description")]
        public string? description { get; set; }

        [Column("rechargable_battery")]
        public bool rechargableBattery { get; set; }

        [Column("has_bluetooth")]
        public bool hasBluetooth { get; set; }

        [Column("has_led_light")]
        public bool hasLedLight { get; set; }

        [Column("include_charger")]
        public bool includeCharger { get; set; }
        
        [Column("color")]
        public string? color { get; set; }

        [Column("price")]
        public double price { get; set; }

        [Column("volt")]
        public string? volt { get; set; }

        [Column("dimensions")]
        public string? dimensions { get; set; }    
        
        [JsonIgnore]
        public Brand? brand { get; set; }

        [ForeignKey("Brand")]
        [Column("brand_id")]
        public int brandId { get; set; }

        [Column("photo")]
        public string photo { get; set; }

        [JsonIgnore]
        public SoundBoxCategory soundBoxCategory { get; set; }

        [ForeignKey("SoundBox")]
        [Column("sound_box_category_id")]
        public int soundBoxCategoryId { get; set; }

        [ForeignKey("CommonUser")]
        [Column("user_id")]
        public Guid userId { get; set; }

        [JsonIgnore]
        public CommonUser? commonUser { get; set; }

        [Column("date_time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateTime { get; set; }

        [Column("created_time")]
        [DataType(DataType.Date)]
        public DateTime created { get; set; } = DateTime.UtcNow;
   
        [Column("percent_tax")]
        public double percentTax { get; set; }

        [Column("qnt_avaliable")]
        public int quantityAvaliable { get; set; }

        public ICollection<PaymentProduct> paymentProducts { get; } = new List<PaymentProduct>();

    }
}