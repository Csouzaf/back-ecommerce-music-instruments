using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;

namespace ecommerce_music_back.Models
{
    [Table("drumns_percussion")]
    public class DrumnsPercussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Column("name")]
        public string? name { get; set; }

        [Column("photo")]
        public string? photo { get; set; }

        [Column("material")]
        public string? material { get; set; }

        [Column("height")]
        public string? height { get; set; }

        [Column("width")]
        public string? width { get; set; }

        [MaxLength(10000)]
        [Column("description")]
        public string description { get; set; }
        
        [Column("has_baqueta")]
        public bool hasBaqueta { get; set; }

        [Column("is_new_or_used")]
        public bool isNewOrUsed { get; set; }

        [JsonIgnore]
        public Brand? brand { get; set; }

        [ForeignKey("Brand")]
        [Column("brand_id")]
        public int brandId { get; set; }

        [JsonIgnore]
        public Model? model { get; set; }

        [ForeignKey("Model")]
        [Column("model_id")]
        public int modelId { get; set; }

        [JsonIgnore]
        public DrumnsCategory? drumnsCategory { get; set; }

        [ForeignKey("DrumnsPercussion")]
        [Column("drumns_percussion_category_id")]
        public int drumnsPercussionCategoryId { get; set; }

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

        [Column("price")]
        public double price { get; set; }

        [Column("percent_tax")]
        public double percentTax { get; set; }

        [Column("qnt_avaliable")]
        public int quantityAvaliable { get; set; }

       public ICollection<PaymentProduct> paymentProducts { get; } = new List<PaymentProduct>();


    }
}