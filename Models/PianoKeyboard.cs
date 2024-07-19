using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;

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

        [ForeignKey("UserModel")]
        [Column("user_id")]
        public Guid userId { get; set; }

        [JsonIgnore]
        public UserModel? userModel { get; set; }

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
        [Column("qnt_avaliable")]
        public int quantityAvaliable { get; set; }

        public OrderProductsUser? orderProductsUser{ get; set; }
    }
}