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
    [Table("drumns_category")]
    public class DrumnsCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public ICollection<DrumnsPercussion> drumnsPercussions { get; } = new List<DrumnsPercussion>();

        public string? name { get; set; }




       

    }
}