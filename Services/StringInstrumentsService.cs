using AutoMapper;
using ecommerce_music_back.data;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    
    public class StringInstrumentsService : IStringInstrumentsRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _iMapper;

        public StringInstrumentsService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _iMapper = mapper;

        }

        public async Task<List<StringInstrument>> FindAllAsync()
        {
            return await _appDbContext.stringInstruments.ToListAsync();
        }

        public async Task<StringInstrument> FindByIdAsync(int stringId)
        {
            return await _appDbContext.stringInstruments.FirstOrDefaultAsync(result => result.Id == stringId);
        }
        
        public async Task<StringInstrument> CreateAsync(StringInstrument stringInstrument)
        {
            await _appDbContext.stringInstruments.AddAsync(stringInstrument);
            await _appDbContext.SaveChangesAsync();
            return stringInstrument;
        }

        public async Task<StringInstrument> UpdateAsync(StringInstrument stringInstrument, int stringId)
        {
            var existStringInstument = await _appDbContext.stringInstruments.FindAsync(stringId);
            
            if(existStringInstument == null)
            {
                throw new BadRequestError("Id doesn't exist");
            }
            existStringInstument.Name = stringInstrument.Name;
            existStringInstument.WithLever = stringInstrument.WithLever;
            existStringInstument.NumberPickups = stringInstrument.NumberPickups;
            existStringInstument.NumberStrings = stringInstrument.NumberPickups;
            existStringInstument.HandOrientation = stringInstrument.HandOrientation;
            existStringInstument.BrandId = stringInstrument.BrandId;
            existStringInstument.Color = stringInstrument.Color;
            existStringInstument.Photo = stringInstrument.Photo;
            existStringInstument.WoodType = stringInstrument.WoodType;
            existStringInstument.StringsInstrumentCategoryId = stringInstrument.StringsInstrumentCategoryId;
            
            _appDbContext.stringInstruments.Update(existStringInstument);
            await _appDbContext.SaveChangesAsync();
            return existStringInstument;
        }

        public async Task<bool> DeleteAsync( int stringId)
        {
            StringInstrument existStringInstument = await _appDbContext.stringInstruments.FindAsync(stringId);
            
            if(existStringInstument == null)
            {
                throw new BadRequestError("Id doesn't exist");
            }
            _appDbContext.stringInstruments.Remove(existStringInstument);

            await _appDbContext.SaveChangesAsync();
            return true;
        }
        
    }
}