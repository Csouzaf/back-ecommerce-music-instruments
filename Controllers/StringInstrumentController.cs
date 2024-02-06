using System.Diagnostics;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using ecommerce_music_back.Services;
using Microsoft.AspNetCore.Mvc;
// using ecommerce_music_back.Models;

namespace ecommerce_music_back.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class StringInstrumentController : Controller
{
    private readonly IStringInstrumentsRepository _stringInstrumentsRepository;

    public StringInstrumentController(IStringInstrumentsRepository stringInstrumentsRepository){
        _stringInstrumentsRepository = stringInstrumentsRepository;
    }

    [HttpGet()]
    public ActionResult<IEnumerable<StringInstrument>> findAll(){
        return _stringInstrumentsRepository.findAll();
    }

    [HttpGet("{stringId}")]
    public IActionResult findById(int stringId){
        return Ok(_stringInstrumentsRepository.findById(stringId));
    }
}