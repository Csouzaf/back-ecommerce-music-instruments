using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;

namespace ecommerce_music_back.Repository
{
    public interface IAddressRepository
    {
        Task<GenericResponse<AddressResponse>> findAddresByCep(string cep);

    }
}