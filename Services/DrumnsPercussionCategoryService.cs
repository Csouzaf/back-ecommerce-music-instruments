using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class DrumnsPercussionCategoryService :IDrumnsPercussionCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public DrumnsPercussionCategoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    
        public async Task<List<DrumnsCategory>> FindAllAsync()
        {
            return await _appDbContext.DrumnsCategory.ToListAsync();
        } 
    
    }
}