using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_music_back.Controllers
{
    [ApiController]
    [Route("model")]
    public class ModelController : Controller
    {
        private readonly IModelRepository _modelRepository;

        public ModelController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Model>>> FindAllAsync()
        {

            var modelResponse = new ModelResponse();
            var modelRepository = await _modelRepository.FindAllAsync();
            var selectNewListModels = modelRepository.Select(model => new ModelResponse(model)).ToList();
            return Ok(selectNewListModels);
           
        }

        [HttpPost()]
        public async Task<ActionResult<ModelResponse>> Save(Model model)
        {
            var modelResponse = await _modelRepository.Create(model);
            return Created("success", modelResponse);
        }
    }
}