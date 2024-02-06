using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;

namespace ecommerce_music_back.Services
{
    
    public class StringInstrumentsService : IStringInstrumentsRepository
    {
        private readonly AppDbContext _appDbContext;

        public StringInstrumentsService(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        public List<StringInstrument> findAll(){
            return _appDbContext.stringInstruments.ToList();
        }

        public StringInstrument findById(int stringId){
            return _appDbContext.stringInstruments.FirstOrDefault(result => result.Id == stringId);
        }
        
    }
}