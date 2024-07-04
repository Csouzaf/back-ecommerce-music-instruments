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

        public async Task<List<Brand>> FindAllAsync()
        {
            return await _appDbContext.brand.Include(brand => brand.models).ToListAsync();
        }

        public async Task<Brand> Create(Brand brand)
        {
            _appDbContext.brand.Add(brand);
            await _appDbContext.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> Update(Brand brand, int id)
        {
            
            var findById = await _appDbContext.brand.FindAsync(id);
            if (findById == null)
            {
                throw new BadRequestError("id null");
            }

            brand.id = id;
            findById = _mapper.Map(brand, findById);

            await _appDbContext.SaveChangesAsync();

            return findById;
        }
    }
}