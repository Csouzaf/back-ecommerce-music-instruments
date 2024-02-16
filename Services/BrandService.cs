using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class BrandService : IBrandRepository
    {
        private readonly AppDbContext _appDbContext;

        public BrandService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Brand>> FindAllAsync()
        {
            return _appDbContext.brand.Include(brand => brand.Models).ToListAsync();
        }
    }
}