using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;
namespace ecommerce_music_back.Models
{
    [Table("order_payment_product")]
    public class OrderPaymentProduct
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        
        [ForeignKey("CommonUser")]
        [Column("common_user_id")]
        public Guid common_user_Id { get; set; }

        [JsonIgnore]
        public CommonUser? commonUser { get; set; }

        [Column("order_date")]
        [DataType(DataType.Date)]
        public DateTime? orderDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("PaymentProduct")]
        [Column("payment_product_id")]
        public Guid paymentProductId { get; set; }

        public PaymentProduct? paymentProduct { get; set; }


        public OrderPaymentProduct()
        {
            id = Guid.NewGuid();
        }
       
    }
}