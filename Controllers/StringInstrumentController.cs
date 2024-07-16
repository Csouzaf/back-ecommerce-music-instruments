using System.Diagnostics;
using System.Security.Claims;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using ecommerce_music_back.Models;

namespace ecommerce_music_back.Controllers;

[Authorize] 
[ApiController]
[Route("instrumentos-cordas")]
public class StringInstrumentController : Controller
{
    private readonly IStringInstrumentsRepository _stringInstrumentsRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public StringInstrumentController(IStringInstrumentsRepository stringInstrumentsRepository,  IHttpContextAccessor httpContextAccessor){
        _stringInstrumentsRepository = stringInstrumentsRepository;
        _httpContextAccessor = httpContextAccessor;
    }



    [AllowAnonymous]
    [HttpGet()]
    public async Task<ActionResult<List<StringInstrument>>> FindAll() {
        return Ok(await _stringInstrumentsRepository.FindAllAsync());
    }

    [AllowAnonymous]
    [HttpGet("categorias/{id}")]
    public async Task<ActionResult<StringInstrument>> CountStrumentsByCategoryId([FromRoute] int id) {
        return Ok(await _stringInstrumentsRepository.CountStringInstruments(id));
    }

    [AllowAnonymous]
    [HttpGet("{stringId}")]
    public async Task<IActionResult> FindById(int stringId){
        var findId = await _stringInstrumentsRepository.FindByIdAsync(stringId);
        if(findId == null) return NotFound("Não foi possível achar um instrumento");

        return Ok(findId);
    }


    [HttpPost()]
    public async Task<ActionResult<StringInstrumentResponse>> Create([FromBody] StringInstrument stringInstrument){
    
        var createStringInstrument = await _stringInstrumentsRepository.CreateAsync(stringInstrument);

        if (createStringInstrument != null)
        {

            return Created("Success", new {createStringInstrument});
        }
        return BadRequest("erro");
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