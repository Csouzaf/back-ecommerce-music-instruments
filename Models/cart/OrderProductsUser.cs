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
        
        [ForeignKey("AdminUser")]
        [Column("user_adm_id")]
        public Guid userAdminId { get; set; }

        [JsonIgnore]
        public AdminUser? adminUser { get; set; }

        [Column("order_date")]
        [DataType(DataType.Date)]
        public DateTime? orderDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("DrumnsPercussion")]
        [Column("drumns_percussion_id")]
        public int drumnsPercussionId { get; set; }

        public DrumnsPercussion? drumnsPercussion { get; set; }

        [Column("amount_drumns_percussion")]
        public int amountDrumsPercussionId { get; set; }

        
//TODO - Create modelbuilder
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


 
        public OrderProductsUser()
        {
            id = Guid.NewGuid();
        }
       
    }
}