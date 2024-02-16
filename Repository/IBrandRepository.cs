using ecommerce_music_back.Models;

namespace ecommerce_music_back.Repository
{
    public interface IBrandRepository
    {
        Task<List<Brand>> FindAllAsync();
    }
}