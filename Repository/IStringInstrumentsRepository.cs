using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_music_back.Models;

namespace ecommerce_music_back.Repository
{
    public interface IStringInstrumentsRepository
    {
       Task<List<StringInstrument>> FindAllAsync();
       Task<StringInstrument> FindByIdAsync(int stringId);

       Task<StringInstrument> CreateAsync(StringInstrument stringInstrument);

       Task<StringInstrument> UpdateAsync(StringInstrument stringInstrument, int stringId);

      Task<bool> DeleteAsync( int stringId);
    }
}