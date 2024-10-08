namespace ecommerce_music_back.Models.response
{
    public class BrandResponse
    {
        public int id;

        public string name; 

        public ICollection<ModelResponse> modelResponse = new List<ModelResponse>();

        public BrandResponse()
        {
            
        }
        public BrandResponse(Brand brand)
        {
            id = brand.id;
            name = brand.name;

            var models = brand.models;

            modelResponse = new List<ModelResponse>();

            foreach(var forModelResponse in models)
            {
                ModelResponse modelResponses = new ModelResponse();
                modelResponses.id = forModelResponse.id;
                modelResponses.name = forModelResponse.name;
                modelResponse.Add(modelResponses);
            } 
           
        }
        
        
    }
}