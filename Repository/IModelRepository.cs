using ecommerce_music_back.Models;

namespace ecommerce_music_back.Repository
{
    public interface IModelRepository
    {
        Task<List<Model>> FindAllAsync();
        Task<Model> Create(Model model);
    }
}