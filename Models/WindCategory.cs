using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_music_back.Models
{
    public class WindCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ICollection<WindInstrument> WindInstruments { get; } = new List<WindInstrument>();
        public string? Name { get; set; }

        public int? Number { get; set; }
    }
}