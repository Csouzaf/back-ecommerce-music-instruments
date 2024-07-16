
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ecommerce_music_back.Models.admin
{
    [Table("user_model")]
    public class UserModel
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
 
        [Required]
        public string Password { get; set; }

        public string? Role { get; set; }

        public ICollection<StringInstrument> StringInstruments { get; } = new List<StringInstrument>();
        public ICollection<DrumnsPercussion> DrumnsPercussions { get; } = new List<DrumnsPercussion>();
        public ICollection<PianoKeyboard> PianoKeyboards { get; } = new List<PianoKeyboard>();
        public ICollection<SoundBox> SoundBoxs { get; } = new List<SoundBox>();
        public ICollection<WindInstrument> WindInstruments { get; } = new List<WindInstrument>();

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public UserModel()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
       
    }
}