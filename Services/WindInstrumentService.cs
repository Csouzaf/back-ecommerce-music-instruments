using AutoMapper;
using ecommerce_music_back.data;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class WindInstrumentervice : IWindInstrumentRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public WindInstrumentervice(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<WindInstrumentResponse> FindAsyncById(int id)
        {
            
            var findWindInstrumentById = await _appDbContext.wind_instrument.FirstOrDefaultAsync(result => result.id == id);
            return _mapper.Map<WindInstrumentResponse>(findWindInstrumentById);
        }

        public async Task<List<WindInstrument>> FindAllAsync()
        {
            return await _appDbContext.wind_instrument.Include(wind => wind.brand.models).ToListAsync();

        }

        public async Task<WindInstrumentResponse> CreateAsync(WindInstrument windInstrument)
        {
            await _appDbContext.wind_instrument.AddAsync(windInstrument);
            await _appDbContext.SaveChangesAsync();

            var responseWindInstrument = _mapper.Map<WindInstrumentResponse>(windInstrument);
            return responseWindInstrument;
        }

        public async Task<WindInstrumentResponse> UpdateAsync(WindInstrument windInstrument, int id)
        {
            var windInstrumentArealdeyExist = await _appDbContext.wind_instrument.FindAsync(id);

            if(windInstrumentArealdeyExist == null)
            {
                throw new BadRequestError("Id doesn't exist");
            }

            
            windInstrumentArealdeyExist = _mapper.Map(windInstrument, windInstrumentArealdeyExist);
            
            
            _appDbContext.Update(windInstrumentArealdeyExist);
            await _appDbContext.SaveChangesAsync();
            
            var windResponse = _mapper.Map<WindInstrumentResponse>(windInstrumentArealdeyExist);

            return windResponse;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var verifyIfIdExist = await _appDbContext.wind_instrument.FindAsync(id);

            if(verifyIfIdExist == null){
                throw new BadRequestError("Id não existe");
            }

            _appDbContext.Remove(verifyIfIdExist);
            await _appDbContext.SaveChangesAsync();
            return true;
            
        }

        
    }
}