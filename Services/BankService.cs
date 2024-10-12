using AutoMapper;
using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;

namespace ecommerce_music_back.Services
{
 
    public class BankService : IBankRepository
    {
      
        private readonly IBrasilApiRepository _brasilApiRepository;
        private readonly IMapper _mapper;

        public BankService(IBrasilApiRepository brasilApiRepository, IMapper mapper)
        {
            _brasilApiRepository =  brasilApiRepository;
            _mapper = mapper;
        }

        public async Task<List<BankResponse>> FindAllAsync()
        {
            var banksResult = await _brasilApiRepository.findAllBanks();
            var banks = banksResult.returnData;
            var bankResponse = _mapper.Map<List<BankResponse>>(banks);

            return bankResponse;
        }
    }
}