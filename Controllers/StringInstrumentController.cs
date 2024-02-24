using System.Diagnostics;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult<List<StringInstrument>>> FindAll() {
        return Ok(await _stringInstrumentsRepository.FindAllAsync());
    }

    [HttpGet("{stringId}")]
    public async Task<IActionResult> FindById(int stringId){
        var findId = await _stringInstrumentsRepository.FindByIdAsync(stringId);
        if(findId == null) return NotFound("Não foi possível achar um instrumento");

        return Ok(findId);
    }

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] StringInstrument stringInstrument){
        var createStringInstrument = await _stringInstrumentsRepository.CreateAsync(stringInstrument);
        return Created("Success", new {createStringInstrument});
    }

    [HttpPut("{stringId}")]
    public async Task<IActionResult> Update([FromBody] StringInstrument stringInstrument, int stringId){
        var update = await _stringInstrumentsRepository.UpdateAsync(stringInstrument, stringId);
        return Ok(update);
    }
    
    [HttpDelete("{stringId}")]
    public async Task<IActionResult> DeleteAsync(int stringId){
        
        await _stringInstrumentsRepository.DeleteAsync(stringId);
        return NoContent();
        
    }

}