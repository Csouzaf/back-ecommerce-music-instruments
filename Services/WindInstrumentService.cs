using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class WindInstrumentService : IWindInstrumentRepository
    {
        private readonly AppDbContext _appDbContext;

        public WindInstrumentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<WindInstrument> FindAsyncById(int id)
        {
            return await _appDbContext.windInstruments.FirstOrDefaultAsync(result => result.Id == id);
        }

        public async Task<List<WindInstrument>> FindAll()
        {
            return await _appDbContext.windInstruments.ToListAsync();
        }

        public async Task<WindInstrument> CreateAsync(WindInstrument windInstrument)
        {
            await _appDbContext.windInstruments.AddAsync(windInstrument);
            await _appDbContext.SaveChangesAsync();
            return windInstrument;
        }

        // public async Task<WindInstrument> UpdateAsync(WindInstrument updateWindInstrument, int id)
        // {
        //     var windInstrumentArealdeyExist = _appDbContext.windInstruments.FindAsync(id);

        //     if(windInstrumentArealdeyExist == null)
        //     {
        //         throw new BadRequestError("Id doesn't exist")
        //     }

            

        // }

        
    }
}