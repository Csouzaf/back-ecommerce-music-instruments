using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_music_back.Models
{
    [Table("wind_category")]
    public class WindCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public ICollection<WindInstrument> windInstruments { get; } = new List<WindInstrument>();
        public string? name { get; set; }

    }
}