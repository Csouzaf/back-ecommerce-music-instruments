using ecommerce_music_back.Models;

namespace ecommerce_music_back.Repository
{
    public interface IDrumnsPercussionCategoryRepository
    {
        Task<List<DrumnsCategory>> FindAllAsync(); 
    }
}