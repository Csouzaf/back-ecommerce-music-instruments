
using AutoMapper;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("bank")]
    public class BancoController : Controller
    {
        // private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BancoController(IMapper mapper)
        {
            // _brandRepository = brandRepository;
            _mapper = mapper;
        }
      
        // [HttpGet()]
        // public async Task<ActionResult<IEnumerable<Brand>>> FindAll()
        // {
        //     var brands = await _brandRepository.FindAllAsync();
        //     var brandResponses = brands.Select(brand => new BrandResponse(brand)).ToList();
        //     return Ok(brandResponses);
           
        // }

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