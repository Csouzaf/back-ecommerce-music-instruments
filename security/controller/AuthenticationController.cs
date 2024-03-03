

using ecommerce_music_back.security.Dtos;
using Microsoft.AspNetCore.Mvc;
using ecommerce_music_back.security.Data;
using ecommerce_music_back.Models.admin;
using ecommerce_music_back.data;
using ecommerce_music_back.security.jwt;

namespace ecommerce_music_back.security.controller
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly IUserModel _userModel;
        private readonly AppDbContext _appDbContext;
        private readonly JwtService _jwtService;
        public AuthenticationController(IUserModel userModel, AppDbContext appDbContext, JwtService jwtService)
        {
            _userModel = userModel;
            _appDbContext = appDbContext;
            _jwtService = jwtService;
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] RegisterDtos registerDtos){

            var userModel = new UserModel
            {
            
                FirstName = registerDtos.FirstName,
                
                LastName = registerDtos.LastName,
                
                Email = registerDtos.Email,

                Password = BCrypt.Net.BCrypt.HashPassword(registerDtos.Password)
            };


            var createdUserAdm = _userModel.Create(userModel);

            if(createdUserAdm == null){
                return BadRequest(new {message = "Failed"});
            }

            return Created("success", new {createdUserAdm});
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDtos loginDtos){
            
            var verifyUserEmailAlreadyRegister =_userModel.FindByEmail(loginDtos.Email);
            
            var verifyUserPassword = verifyUserEmailAlreadyRegister.Password;

            if(verifyUserEmailAlreadyRegister == null || verifyUserPassword == null)
            {
                return BadRequest(new {message = "Email or Password incorrect"});
            }

            var createJwtToken = _jwtService.generateJwt(verifyUserEmailAlreadyRegister.Id, verifyUserEmailAlreadyRegister.FirstName, verifyUserEmailAlreadyRegister.Email);
            
            return Ok(new {message = "User Logged", createJwtToken});
        } 

    }

 
}