using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class ModelService : IModelRepository
    {
       private readonly AppDbContext _appDbContext;

       public ModelService(AppDbContext appDbContext)
       {
            _appDbContext = appDbContext;
       }

       public Task<List<Model>> FindAllAsync()
       {
            return _appDbContext.model.ToListAsync();
       }

        public async Task<Model> Create(Model model)
        {
            _appDbContext.model.Add(model);
            await _appDbContext.SaveChangesAsync();
            return model;
        }
    }
}