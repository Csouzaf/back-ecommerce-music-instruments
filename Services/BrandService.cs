using AutoMapper;
using ecommerce_music_back.data;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class BrandService : IBrandRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public BrandService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public Task<List<Brand>> FindAllAsync()
        {
            return _appDbContext.brand.Include(brand => brand.Models).ToListAsync();
        }

        public async Task<Brand> Update(Brand brand, int id)
        {
            
            var findById = await _appDbContext.brand.FindAsync(id);
            if (findById == null)
            {
                throw new BadRequestError("id null");
            }

            brand.Id = id;
            findById = _mapper.Map(brand, findById);

            await _appDbContext.SaveChangesAsync();

            return findById;
        }
    }
}