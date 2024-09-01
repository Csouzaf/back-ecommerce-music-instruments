

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
        private readonly IAdminUser _AdminUser;
        private readonly ICommonUser _commonUser;
        private readonly AppDbContext _appDbContext;
        private readonly JwtService _jwtService;
        public AuthenticationController(IAdminUser AdminUser, AppDbContext appDbContext, JwtService jwtService, ICommonUser commonUser)
        {
            _AdminUser = AdminUser;
            _appDbContext = appDbContext;
            _jwtService = jwtService;
            _commonUser = commonUser;
        }

        [HttpPost("signup")]
        public IActionResult signup([FromBody] RegisterDtos registerDtos)
        {

            if (registerDtos.Role == "ADMIN")
            {

                var adminUser = new AdminUser
                {

                    FirstName = registerDtos.FirstName,

                    LastName = registerDtos.LastName,

                    Email = registerDtos.Email,

                    Password = BCrypt.Net.BCrypt.HashPassword(registerDtos.Password),

                    Address = registerDtos.Address,

                    Cep = registerDtos.Cep,

                    Cnpj = registerDtos.Cnpj
                };

                var createdUserAdm = _AdminUser.Create(adminUser);

                if (createdUserAdm == null)
                {
                    return BadRequest(new { message = "Failed" });
                }

                return Created("success", new { createdUserAdm });
            }

            else
            {
                var commonUser = new CommonUser
                {

                    FirstName = registerDtos.FirstName,

                    LastName = registerDtos.LastName,

                    Email = registerDtos.Email,

                    Password = BCrypt.Net.BCrypt.HashPassword(registerDtos.Password),

                    Address = registerDtos.Address,

                    Cep = registerDtos.Cep,

                };

                var createdCommonUser = _commonUser.Create(commonUser);

                if (createdCommonUser == null)
                {
                    return BadRequest(new { message = "Failed" });
                }

                return Created("success", new { createdCommonUser });
            }



        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDtos loginDtos)
        {
            //Admin
            var verifyAdminUserEmailAlreadyRegister = _AdminUser.FindByEmail(loginDtos.Email);

            var verifyAdminUserPassword = verifyAdminUserEmailAlreadyRegister.Password;

            //User
            var verifyUserEmailAlreadyRegister = _commonUser.FindByEmail(loginDtos.Email);

            var verifyUserPassword = verifyUserEmailAlreadyRegister.Password;

            if (verifyAdminUserEmailAlreadyRegister != null && verifyAdminUserPassword != null)
            {

                var createJwtTokenAdmin = _jwtService.generateJwt(verifyUserEmailAlreadyRegister.Id, verifyUserEmailAlreadyRegister.FirstName);

                Response.Cookies.Append("jwt", createJwtTokenAdmin, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    //for retrieve jwt cookies without warning
                    SameSite = SameSiteMode.None
                });
                return Ok(new { message = "User Logged", createJwtTokenAdmin });

            }

            else if (verifyUserEmailAlreadyRegister != null && verifyUserPassword != null)
            {
                var createJwtTokenUser = _jwtService.generateJwt(verifyUserEmailAlreadyRegister.Id, verifyUserEmailAlreadyRegister.FirstName);

                Response.Cookies.Append("jwt", createJwtTokenUser, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    //for retrieve jwt cookies without warning
                    SameSite = SameSiteMode.None
                });
                return Ok(new { message = "User Logged", createJwtTokenUser });
              
            }

            else
            {
                return BadRequest(new { message = "Email or Password incorrect" });
            }
        }

    }


}