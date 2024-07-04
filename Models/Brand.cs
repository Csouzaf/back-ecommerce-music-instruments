
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ecommerce_music_back.Models
{
    [Table("brand")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }
        
        public ICollection<Model> models { get; } = new List<Model>();
        public ICollection<DrumnsPercussion> drumnsPercussions { get; } = new List<DrumnsPercussion>();
        public ICollection<PianoKeyboard> pianoKeyboards { get; } = new List<PianoKeyboard>();
        public ICollection<SoundBox> soundBoxs { get; } = new List<SoundBox>();
        public ICollection<StringInstrument> stringInstruments { get; } = new List<StringInstrument>();
        public ICollection<WindInstrument> windInstruments { get; } = new List<WindInstrument>();


    }
}