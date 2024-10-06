using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ecommerce_music_back.Models.admin;
namespace ecommerce_music_back.Models
{
    [Table("payment_product")]
    public class PaymentProduct
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        
        [ForeignKey("CommonUser")]
        [Column("common_user_id")]
        public Guid commonUserId { get; set; }

        [JsonIgnore]
        public CommonUser? commonUser { get; set; }

        [Column("payment_method")]
        public string paymentMethod { get; set; }

        [Column("payment_parcel")]
        public int paymentParcel { get; set; }
        
        [Column("final_price")]
        public double finalPrice { get; set; }

        [Column("is_paid")]
        public bool isPaid { get; set; }
        
        public ICollection<OrderPaymentProduct> orderPaymentProducts { get; } = new List<OrderPaymentProduct>();
        
          [ForeignKey("DrumnsPercussion")]
        [Column("drumns_percussion_id")]
        public int drumnsPercussionId { get; set; }

        public DrumnsPercussion? drumnsPercussion { get; set; }

        [Column("amount_drumns_percussion")]
        public int amountDrumsPercussionId { get; set; }

        [ForeignKey("PianoKeyboard")]
        [Column("piano_keyboard_id")]
        public int pianoKeyboardId { get; set; }

        public PianoKeyboard? pianoKeyboard { get; set; }

        [Column("amount_drumns_percussion")]
        public int amountPianoKeyboardId { get; set; }
      
        
        [ForeignKey("SoundBox")]
        [Column("sound_box_id")]
        public int soundBoxId { get; set; }

        public SoundBox? soundBox { get; set; }

        [Column("amount_sound_box")]
        public int amountSoundBoxId { get; set; }


         
        [ForeignKey("StringInstrument")]
        [Column("string_instrument_id")]
        public int stringInstrumentId { get; set; }

        public StringInstrument? stringInstrument { get; set; }

        [Column("amount_string_instrument")]
        public int amountStringInstrumentId { get; set; }


        [ForeignKey("StringInstrument")]
        [Column("wind_instrument_id")]
        public int windInstrumentId { get; set; }

        public WindInstrument? windInstrument { get; set; }

        [Column("amount_wind_instrument")]
        public int amountWindInstrumentId { get; set; }

        public PaymentProduct()
        {
            id = Guid.NewGuid();
        }
       
    }
}