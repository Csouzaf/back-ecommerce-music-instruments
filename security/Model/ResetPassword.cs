using System.ComponentModel.DataAnnotations;

namespace ecommerce_music_back.security.Model
{
    public class ResetPassword
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "A senha e confirmação não são as mesmas")]
        public string ConfirmNewPassword { get; set; }

        public string Token { get; set; }

        public string OTP { get; set; }

        public DateTime Date { get; set; }



        public ResetPassword()
        {
          
        }
    }
}