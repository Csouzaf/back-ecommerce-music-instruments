
using System.Net;
using AutoMapper;
using ecommerce_music_back.Dtos;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IMapper mapper, IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
      
        [HttpGet("{cep}")]
        public async Task<ActionResult<GenericResponse<AddressResponse>>> findAddress([FromRoute] string cep)
        {
            var address = await _addressRepository.findAddresByCep(cep);

            if (address.httpStatusCode == HttpStatusCode.OK)
            {
                return Json(new {
                    address.returnData.cep,
                    address.returnData.city,
                    address.returnData.neighborhood,
                    address.returnData.state,
                    address.returnData.street

                });
        
            }
            else 
            {
                return StatusCode((int) address.httpStatusCode, address.returnError);
            }
           
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