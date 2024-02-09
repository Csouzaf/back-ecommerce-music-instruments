

using ecommerce_music_back.security.Dtos;
using Microsoft.AspNetCore.Mvc;
using ecommerce_music_back.security.Data;
using ecommerce_music_back.Models.admin;
using ecommerce_music_back.data;

namespace ecommerce_music_back.security.controller
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly IUserModel _userModel;
        private readonly AppDbContext _appDbContext;

        public AuthenticationController(IUserModel userModel, AppDbContext appDbContext)
        {
            _userModel = userModel;
            _appDbContext = appDbContext;
        }

        [HttpPost("signup")]
        public IActionResult Signup(RegisterDtos registerDtos){

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

    }
}