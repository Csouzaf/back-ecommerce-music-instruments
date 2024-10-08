using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ecommerce_music_back.Models.response
{
    public class StringInstrumentResponse
    {

        public int id;
        
        public string name;

        public DateTime dateTime;

        public int brandId;

        public int modelId;

        public string color;

        public string numberStrings;

        public string numberPickups;

        public string woodType;

        public string handOrientation;

        public bool withLever;

        public string photo;

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