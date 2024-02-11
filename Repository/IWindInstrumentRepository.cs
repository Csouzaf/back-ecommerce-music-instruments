using ecommerce_music_back.Models;

namespace ecommerce_music_back.Repository
{
    public interface IWindInstrumentRepository
    {
        Task<WindInstrument> FindAsyncById(int id);

        Task<WindInstrument> CreateAsync(WindInstrument windInstrument);

        // Task<WindInstrument> UpdateAsync(WindInstrument updateWindInstrument, int id);

        // Task<bool> DeleteAsync(int id);
    }
}