using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_music_back.security.Dtos
{
    public class LoginDtos
    {
        public string Email { get; set; }
        
        public string Password { get; }
    }
}