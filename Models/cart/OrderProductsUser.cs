using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;
namespace ecommerce_music_back.Models
{
    [Table("order_products_user")]
    public class OrderProductsUser
    {
        //TODO - Create table database and modelbuilder
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        
        [ForeignKey("UserModel")]
        [Column("user_id")]
        public Guid userId { get; set; }

        [JsonIgnore]
        public UserModel? userModel { get; set; }

        [ForeignKey("DrumnsPercussion")]
        [Column("drumns_percussion_id")]
        public int drumnsPercussionId { get; set; }

        [JsonIgnore]
        public DrumnsPercussion? drumnsPercussion { get; set; }

        [Column("total_amount_drumns_percussion")]
        public int totalAmountDrumsPercussion { get; set; }

        [Column("order_date")]
        [DataType(DataType.Date)]
        public DateTime? orderDate { get; set; }


 
        public OrderProductsUser()
        {
            id = Guid.NewGuid();
        }
       
    }
}