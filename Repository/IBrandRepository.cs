using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;

namespace ecommerce_music_back.Repository
{
    public interface IBrandRepository
    {
        Task<List<Brand>> FindAllAsync();

        Task<Brand> Update(Brand brand, int id);

        Task<Brand> Create(Brand brand);

    }
}