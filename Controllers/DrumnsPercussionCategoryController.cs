using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("drumsCategory")]
    public class DrumnsPercussionCategoryController : Controller
    {
        private readonly IDrumnsPercussionCategoryRepository _drumnsPercussionCategoryRepository;
    
        public DrumnsPercussionCategoryController(IDrumnsPercussionCategoryRepository drumnsPercussionCategoryRepository)
        {
            _drumnsPercussionCategoryRepository = drumnsPercussionCategoryRepository;
        }
    
        [HttpGet()]
        public async Task<ActionResult<List<DrumnsCategory>>> FindAllAsync()
        {
            return Ok(_drumnsPercussionCategoryRepository.FindAllAsync());
        }
    }
}