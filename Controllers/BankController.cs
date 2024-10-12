
using AutoMapper;
using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("bank")]
    public class BankController : Controller
    {
        private readonly IBankRepository _bankRepository;

        public BankController(IMapper mapper, IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
      
        [HttpGet()]
        public async Task<ActionResult<List<BankResponse>>>  FindAll()
        {
            var bankResponse = await _bankRepository.FindAllAsync();
            var banks = bankResponse.Select(m => new {m.code, m.fullName, m.name}).ToList();
         
            return Ok(banks);
           
        }

        // [HttpPost()]
        // public async Task<ActionResult<BrandResponse>> Save(Brand brand)
        // {
        //     var brandService = await _brandRepository.Create(brand);
        //     var brandResponse = new BrandResponse(brandService);
        //     return Created("success", brandResponse);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<BrandResponse>> Update(Brand brand, [FromRoute] int id)
        // {
        //     var brandService = await _brandRepository.Update(brand, id);
        //     var brandResponse = new BrandResponse(brandService);
        //     return Ok(brandResponse);
        // }


    }
}