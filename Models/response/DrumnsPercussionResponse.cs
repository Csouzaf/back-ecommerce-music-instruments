namespace ecommerce_music_back.Models.response
{
    public class DrumnsPercussionResponse
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Photo { get; set; }

        public string? Material { get; set; }

        public string? Height { get; set; }

        public string? Width { get; set; }

        public string Description { get; set; }
        
        public bool HasBaqueta { get; set; }

        public bool IsNewOrUsed { get; set; }

        public int BrandId { get; set; }

        public Model? Model { get; set; }


        public int ModelId { get; set; }

        public DrumnsCategory DrumnsCategory { get; set; }

        public int DrumnsPercussionCategoryId { get; set; }

        public DrumnsPercussionResponse()
        {
            
        }

          public DrumnsPercussionResponse(DrumnsPercussion drumnsPercussion)
        {
          
        }
    }
}