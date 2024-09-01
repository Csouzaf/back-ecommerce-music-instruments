using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;
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
        public Model? model { get; set; }

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
        
        //TODO - Create column
        [Column("percent_tax")]
        public double percentTax { get; set; }

        //TODO - Create column
        [Column("qnt_avaliable")]
        public int quantityAvaliable { get; set; }

        public OrderProductsUser? orderProductsUser{ get; set; }

    }
}