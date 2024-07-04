using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_music_back.Models
{
    [Table("piano_category")]
    public class PianoCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public ICollection<PianoKeyboard> pianoKeyboards { get; } = new List<PianoKeyboard>();
        public string? name { get; set; }

    }
}