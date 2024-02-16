using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("brand")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        private readonly BrandService _brandService;
        private readonly BrandResponse _brandResponse;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;

        }
      
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Brand>>> FindAll()
        {
            var brands = await _brandRepository.FindAllAsync();
            var brandResponses = brands.Select(brand => new BrandResponse(brand)).ToList();
            return Ok(brandResponses);
           
        }


    }
}