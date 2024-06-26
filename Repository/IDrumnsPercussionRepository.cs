using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;

namespace ecommerce_music_back.Repository
{
    public interface IDrumnsPercussionRepository
    {
        Task<List<DrumnsPercussion>> FindAllAsync();
        Task<DrumnsPercussion> FindByIdAsync(int id);
        Task<DrumnsPercussion> CreateAsync(DrumnsPercussion drumnsPercussion);
        Task<DrumnsPercussionResponse> UpdateAsync(DrumnsPercussion drumnsPercussion, int id);
        Task<bool> DeleteAsync(int id);
    }
}