using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;

namespace ecommerce_music_back.Repository
{
    public interface IWindInstrumentRepository
    {   
        Task<List<WindInstrument>> FindAllAsync();

        Task<WindInstrumentResponse> FindAsyncById(int id);

        Task<WindInstrumentResponse> CreateAsync(WindInstrument windInstrument);

        Task<WindInstrumentResponse> UpdateAsync(WindInstrument windInstrument, int id);

        Task<bool> DeleteAsync(int id);
    }
}