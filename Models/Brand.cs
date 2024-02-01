
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ecommerce_music_back.Models
{


    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Model> Models { get; } = new List<Model>();
        // public ICollection<DrumnsPercussion> DrumnsPercussions { get; } = new List<DrumnsPercussion>();
        // public ICollection<PianoKeyboard> PianoKeyboards { get; } = new List<PianoKeyboard>();
        // public ICollection<SoundBox> SoundBoxs { get; } = new List<SoundBox>();
        // public ICollection<StringInstrument> StringInstruments { get; } = new List<StringInstrument>();
        // public ICollection<WindInstrument> WindInstruments { get; } = new List<WindInstrument>();


    }
}