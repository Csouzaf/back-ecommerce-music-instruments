using ecommerce_music_back.Dtos;

namespace ecommerce_music_back.Repository
{
    public interface IBankRepository
{
        Task<List<BankResponse>> FindAllAsync();

        // Task<Bank> Update(Bank bank, int id);

        // Task<Bank> Create(Bank bank);

    }
}