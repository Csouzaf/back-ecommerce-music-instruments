using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;

namespace ecommerce_music_back.Repository
{
    public interface IBrasilApiRepository
    {
        //Task<GenericResponse<Bank>> findBankByCode(string code);

        Task<GenericResponse<Address>> findAddressByCep(string cep);

        Task<GenericResponse<List<Bank>>> findAllBanks();

    }
}