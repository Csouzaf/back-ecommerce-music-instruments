namespace ecommerce_music_back.Models.response
{
    public class ModelResponse
    {
         public int Id { get; set; }
        
        public string Name { get; set; }

        public ModelResponse()
        {
        
        }

        public ModelResponse(Model model)
        {
            Id = model.Id;
            Name = model.Name;
        }

       
    }
}