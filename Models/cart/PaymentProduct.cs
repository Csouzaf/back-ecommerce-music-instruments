using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;
namespace ecommerce_music_back.Models
{
    [Table("payment_product")]
    public class PaymentProduct
    {
        //TODO - Create table database and modelbuilder
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        
        [ForeignKey("AdminUser")]
        [Column("user_adm_id")]
        public Guid userAdminId { get; set; }

        [JsonIgnore]
        public AdminUser? adminUser { get; set; }

        [Column("payment_method")]
        public string paymentMethod { get; set; }

        [Column("payment_parcel")]
        public int paymentParcel { get; set; }
        
        [Column("final_price")]
        public double finalPrice { get; set; }

        [Column("is_paid")]
        public bool isPaid { get; set; }
        
        [Column("order")]
        public int order { get; set; }

        public PaymentProduct()
        {
            id = Guid.NewGuid();
        }
       
    }
}