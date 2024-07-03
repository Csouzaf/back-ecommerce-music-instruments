using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ecommerce_music_back.Models.response
{
    public class StringInstrumentResponse
    {

        public int Id;
        
        public string Name;

        public DateTime dateTime;

        public int BrandId;

        public int ModelId;

        public string Color {get; set; }

        public string NumberStrings;

        public string NumberPickups;

        public string WoodType;

        public string HandOrientation;

        public bool WithLever;

        public string Photo;

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