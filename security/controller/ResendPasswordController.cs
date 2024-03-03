using System.Security.Claims;
using ecommerce_music_back.Models.admin;
using ecommerce_music_back.security.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ecommerce_music_back.security.controller
{

    public class ResendPasswordController : Controller
    {   
        private readonly UserManager<UserModel> _userManager;
        private readonly DbContext _dbContext;

        public ResendPasswordController(UserManager<UserModel> userManager, DbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [Route("forgot")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassowordModel forgotPassowordModel)
        {
        
            if(!ModelState.IsValid)  
            {
                return BadRequest("Insira um e-mail válido ou o e-mail está nulo");
            }

            var userEmail = await _userManager.FindByEmailAsync(forgotPassowordModel.Email);

            if(userEmail == null)
            {
                return BadRequest("E-mail errado ou não cadastrado");
            }

            var tokenPasswordReset = await _userManager.GeneratePasswordResetTokenAsync(userEmail);

            var otp = RandomNumberGenerate.Generate(10000, 9999);

            var resetPasswordModel = new ResetPassword()
            {
                Email = forgotPassowordModel.Email,
                OTP = otp.ToString(),
                Token = tokenPasswordReset,
                Date = DateTime.Now
            };
            
            await _dbContext.AddAsync(resetPasswordModel);
            await _dbContext.SaveChangesAsync();

            return Ok("Token de redefinição de senha enviado com sucesso");
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
                
        [Route("reset")]
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
         {
            
            if(!ModelState.IsValid)
            {
                // return View(resetPassword);
                return BadRequest("Form invalido");
            }

            var userEmail = await _userManager.FindByEmailAsync(resetPassword.Email);

            if(userEmail == null)
            {
                // RedirectToAction(nameof(ResetPasswordConfirmation));
                return BadRequest("Email nulo");
            }

            var resetPassResult  = await _userManager.ResetPasswordAsync(userEmail, resetPassword.Token, resetPassword.NewPassword);

            if(!resetPassResult.Succeeded)
            {
                foreach(var erro in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(erro.Code, erro.Description);
                }

                return Ok();
            }

            return Ok("Resetado");
        }
    }
}