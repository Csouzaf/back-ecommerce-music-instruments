using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ecommerce_music_back.Models
{
    public class DrumnsCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<DrumnsPercussion> DrumnsPercussions { get; } = new List<DrumnsPercussion>();

        public string? Name { get; set; }




       

    }
}