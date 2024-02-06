using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    
    public class StringInstrumentsService : IStringInstrumentsRepository
    {
        private readonly AppDbContext _appDbContext;

        public StringInstrumentsService(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        public async Task<List<StringInstrument>> FindAllAsync(){
            return await _appDbContext.stringInstruments.ToListAsync();
        }

        public async Task<StringInstrument> FindByIdAsync(int stringId){
            return await _appDbContext.stringInstruments.FirstOrDefaultAsync(result => result.Id == stringId);
        }
        
    }
}