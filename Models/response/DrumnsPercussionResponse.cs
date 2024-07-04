namespace ecommerce_music_back.Models.response
{
    public class DrumnsPercussionResponse
    {
        
        public string? name;

        public string? photo;

        public string? material;

        public string? height;

        public string? width;

        public string? description;
        
        public bool hasBaqueta;

        public bool isNewOrUsed;

        public int brandId;

        public int modelId;

        public int drumnsPercussionCategoryId;

        public DrumnsPercussionResponse()
        {
            
        }

        public DrumnsPercussionResponse(DrumnsPercussion drumnsPercussion)
         {}
        //   Id = drumnsPercussion.Id;
        //   Name = drumnsPercussion.Name;
        //   Photo = drumnsPercussion.Photo;
        //   Material = drumnsPercussion.Material;
        //   Height = drumnsPercussion.Height;
        //   Width = drumnsPercussion.Width;
        //   Description = drumnsPercussion.Description;
        //   HasBaqueta = drumnsPercussion.HasBaqueta;
        //   BrandId = drumnsPercussion.BrandId;
        //   ModelId = drumnsPercussion.ModelId;
        //   DrumnsPercussionCategoryId = drumnsPercussion.DrumnsPercussionCategoryId;
        // }
    }
}