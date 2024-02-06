using System.Diagnostics;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Mvc;
// using ecommerce_music_back.Models;

namespace ecommerce_music_back.Controllers;

[ApiController]
[Route("string")]
public class StringInstrumentController : Controller
{
    private readonly IStringInstrumentsRepository _stringInstrumentsRepository;

    public StringInstrumentController(IStringInstrumentsRepository stringInstrumentsRepository){
        _stringInstrumentsRepository = stringInstrumentsRepository;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<StringInstrument>>> FindAll(){
        return await _stringInstrumentsRepository.FindAllAsync();
    }

    [HttpGet("{stringId}")]
    public async Task<IActionResult> FindById(int stringId){
        var findId = await _stringInstrumentsRepository.FindByIdAsync(stringId);
        if(findId == null) return NotFound("Não foi possível achar um instrumento");

        return Ok(findId);
    }
}