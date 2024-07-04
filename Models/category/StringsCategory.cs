using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ecommerce_music_back.Models
{
    [Table("strings_category")]
    public class StringsCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public ICollection<StringInstrument> stringInstruments { get; } = new List<StringInstrument>();
        
        public string? name { get; set; }

       
    }
}