using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("drumsPercussion")]
    public class DrumnsPercussionController : Controller
    {
        private readonly IDrumnsPercussionRepository _iDrumnsPercussionRepository;

        public DrumnsPercussionController(IDrumnsPercussionRepository iDrumnsPercussionRepository)
        {
            _iDrumnsPercussionRepository = iDrumnsPercussionRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<List<DrumnsPercussion>>> FindAllAsync()
        {
            return Ok(await _iDrumnsPercussionRepository.FindAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DrumnsPercussion>> FindByIdAsync([FromQuery] int id)
        {
            return Ok(await _iDrumnsPercussionRepository.FindByIdAsync(id));
        }

        // [HttpPost()]
        // public async Task<ActionResult<DrumnsPercussion>> CreateAsync([FromBody] DrumnsPercussion drumnsPercussion)
        // {
        //     var createDrumnsPercussion = await _iDrumnsPercussionRepository.CreateAsync(drumnsPercussion);
        //     return Created("success", new DrumnsPercussionResponse(createDrumnsPercussion));
        // }

        [HttpPut("{id}")]
        public async Task<ActionResult<DrumnsPercussionResponse>> UpdateAsync([FromBody] DrumnsPercussion drumnsPercussion, int id)
        {
            var updateDrumnsPercussion = await _iDrumnsPercussionRepository.UpdateAsync(drumnsPercussion, id);
            return Ok(updateDrumnsPercussion);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            await _iDrumnsPercussionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}