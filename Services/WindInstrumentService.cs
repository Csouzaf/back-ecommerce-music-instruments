using ecommerce_music_back.data;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class WindInstrumentervice : IWindInstrumentRepository
    {
        private readonly AppDbContext _appDbContext;

        public WindInstrumentervice(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<WindInstrument> FindAsyncById(int id)
        {
            return await _appDbContext.wind_instrument.FirstOrDefaultAsync(result => result.Id == id);
        }

        public async Task<List<WindInstrument>> FindAllAsync()
        {
            return await _appDbContext.wind_instrument.Include(wind => wind.Brand.Models).ToListAsync();
        }

        public async Task<WindInstrument> CreateAsync(WindInstrument windInstrument)
        {
            await _appDbContext.wind_instrument.AddAsync(windInstrument);
            await _appDbContext.SaveChangesAsync();
            return windInstrument;
        }

        public async Task<WindInstrument> UpdateAsync(WindInstrument updateWindInstrument, int id)
        {
            var windInstrumentArealdeyExist = await _appDbContext.wind_instrument.FindAsync(id);

            if(windInstrumentArealdeyExist == null)
            {
                throw new BadRequestError("Id doesn't exist");
            }

            windInstrumentArealdeyExist.Name = updateWindInstrument.Name;
            windInstrumentArealdeyExist.Width = updateWindInstrument.Width;
            windInstrumentArealdeyExist.Color = updateWindInstrument.Color;
            windInstrumentArealdeyExist.BrandId = updateWindInstrument.BrandId;
            windInstrumentArealdeyExist.Photo = updateWindInstrument.Photo;
            windInstrumentArealdeyExist.WindInstrumentCategoryId = updateWindInstrument.WindInstrumentCategoryId;
            windInstrumentArealdeyExist.ModelId = updateWindInstrument.ModelId;

            _appDbContext.Update(windInstrumentArealdeyExist);
            await _appDbContext.SaveChangesAsync();
            
            return windInstrumentArealdeyExist;

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