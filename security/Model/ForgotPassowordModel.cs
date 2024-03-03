using System.ComponentModel.DataAnnotations;

namespace ecommerce_music_back.security.Model
{
    public class ForgotPassowordModel
    {

        [Required]
        [EmailAddress]    
        public string Email { get; set; }

     
    }
}