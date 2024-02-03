using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    public class StringsCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ICollection<StringInstrument> StringInstruments { get; } = new List<StringInstrument>();
        
        public string? Name { get; set; }

        public int? Number { get; set; }

       
    }
}