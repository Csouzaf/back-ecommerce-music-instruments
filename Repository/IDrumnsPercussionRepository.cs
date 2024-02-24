using ecommerce_music_back.Models;

namespace ecommerce_music_back.Repository
{
    public interface IDrumnsPercussionRepository
    {
        Task<List<DrumnsPercussion>> FindAllAsync();
        Task<DrumnsPercussion> FindByIdAsync(int id);
        Task<DrumnsPercussion> CreateAsync(DrumnsPercussion drumnsPercussion);
        Task<DrumnsPercussion> UpdateAsync(DrumnsPercussion drumnsPercussion, int id);
        Task<bool> DeleteAsync(int id);
    }
}