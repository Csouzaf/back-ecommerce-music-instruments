namespace ecommerce_music_back.Models.response
{
    public class ModelResponse
    {
         public int id;
        
        public string name;

        public ModelResponse()
        {
        
        }

        public ModelResponse(Model model)
        {
            id = model.id;
            name = model.name;
        }

       
    }
}