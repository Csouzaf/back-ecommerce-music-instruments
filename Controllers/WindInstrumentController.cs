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

        public WindInstrumentController(IWindInstrumentRepository windInstrumentRepository)
        {
            _windInstrumentRepository = windInstrumentRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<List<WindInstrument>>> FindAllAsync()
        {
            var findAllByRepository = await _windInstrumentRepository.FindAllAsync();
            var selectNewListWindStruments = findAllByRepository.Select(windIstrument => new WindInstrumentResponse(windIstrument));
            return Ok(selectNewListWindStruments);

        }

        [HttpPost()]
        public async Task<ActionResult<WindInstrument>> CreateAsync([FromBody] WindInstrument windInstrument)
        {
            var createAsync = await _windInstrumentRepository.CreateAsync(windInstrument);
            
            return Created("success", new WindInstrumentResponse(createAsync));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WindInstrument>> Update([FromBody] WindInstrument windInstrument, int id)
        {
            var updateAsync = await _windInstrumentRepository.UpdateAsync(windInstrument, id);

            return Ok(new WindInstrumentResponse(updateAsync));
  
        }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            await _windInstrumentRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}