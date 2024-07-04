namespace ecommerce_music_back.Models.response
{
    public class WindInstrumentResponse
    {
        public int id;
        
        public string name; 
        
        public string width;

        public string color;

        public int brandId;

        public int modelId;

        public string photo;

        public WindInstrumentResponse(){
            
        }

        public WindInstrumentResponse(WindInstrument windInstrument)
        {
           id = windInstrument.id;
           name = windInstrument.name;
           width = windInstrument.width;
           color = windInstrument.color;
           photo = windInstrument.photo;
           brandId = windInstrument.brandId;

          //Criar obj q venha com a lista de modelresponse

        }
    }
}