using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ecommerce_music_back.Models.response
{
    public class StringInstrumentResponse
    {

        public int Id { get; set; }
        
        public string Name { get; set; }

        public int BrandId { get; set; }

        public int ModelId { get; set; }

        public string Color {get; set; }

        public string NumberStrings { get; set; }

        public string NumberPickups { get; set; }

        public string WoodType{ get; set; }

        public string HandOrientation { get; set; }

        public bool WithLever { get; set; }

        public string Photo { get; set; }

    //    public StringInstrumentResponse(StringInstrument stringInstrument)
    //    {
    //         Id = stringInstrument.Id;
    //         Name = stringInstrument.Name;
    //         BrandId = stringInstrument.BrandId;
    //         ModelId = stringInstrument.ModelId;
    //         WoodType = stringInstrument.WoodType;
    //         HandOrientation = stringInstrument.HandOrientation;
    //         WithLever = stringInstrument.WithLever;
    //         Color = stringInstrument.Color;
    //         NumberStrings = stringInstrument.NumberStrings;
    //         NumberPickups = stringInstrument.NumberPickups;
    //         Photo = stringInstrument.Photo;

            
    //    }
    }
}