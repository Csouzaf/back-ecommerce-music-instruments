using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_music_back.Models
{
    [Table("sound_box_category")]
    public class SoundBoxCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ICollection<SoundBox> SoundBoxs { get; } = new List<SoundBox>();
        
        public string? Name { get; set; }

        
    }
}