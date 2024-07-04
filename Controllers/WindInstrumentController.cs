using AutoMapper;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("windInstrument")]
    public class WindInstrumentController : Controller
    {
        private readonly IWindInstrumentRepository _windInstrumentRepository;
        private readonly IMapper _mapper;

        public WindInstrumentController(IWindInstrumentRepository windInstrumentRepository, IMapper mapper)
        {
            _windInstrumentRepository = windInstrumentRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<WindInstrument>>> FindAllAsync()
        {
            var findAllByRepository = await _windInstrumentRepository.FindAllAsync();

            return Ok(findAllByRepository);


        }

        [HttpPost()]
        public async Task<ActionResult<WindInstrumentResponse>> CreateAsync([FromBody] WindInstrument windInstrument)
        {
            var createAsync = await _windInstrumentRepository.CreateAsync(windInstrument);
            
            return Created("success", createAsync);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WindInstrumentResponse>> Update([FromBody] WindInstrument windInstrument, [FromRoute] int id)
        {
            var updateAsync = await _windInstrumentRepository.UpdateAsync(windInstrument, id);
         
            return Ok(updateAsync);
  
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            await _windInstrumentRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}