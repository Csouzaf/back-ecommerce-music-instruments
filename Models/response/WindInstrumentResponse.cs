namespace ecommerce_music_back.Models.response
{
    public class WindInstrumentResponse
    {
        public int Id { get; set; }
        
        public string Name { get; set; } 
        
        public string? Width { get; set; }

        public string? Color { get; set; }

        public Model? Model{ get; set; }

        public int BrandId { get; set; }

        public string Photo { get; set; }

        public WindInstrumentResponse(){
            
        }

        public WindInstrumentResponse(WindInstrument windInstrument)
        {
           Id = windInstrument.Id;
           Name = windInstrument.Name;
           Width = windInstrument.Width;
           Color = windInstrument.Color;
           Photo = windInstrument.Photo;
           BrandId = windInstrument.BrandId;

          

        }
    }
}