namespace ecommerce_music_back.Models.response
{
    public class BrandResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ModelResponse> ModelResponse { get; } = new List<ModelResponse>();

        public BrandResponse()
        {
        
        }
        public BrandResponse(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;

            var models = brand.Models;

            ModelResponse = new List<ModelResponse>();

            foreach(var forModelResponse in models)
            {
                ModelResponse modelResponse = new ModelResponse();
                modelResponse.Id = forModelResponse.Id;
                modelResponse.Name = forModelResponse.Name;
                ModelResponse.Add(modelResponse);
            } 
           
        }
        
    }
}