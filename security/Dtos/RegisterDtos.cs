using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_music_back.security.Dtos
{
    public class RegisterDtos
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Cep { get; set; }

        public string Cpf { get; set; }
        
        public string Cnpj { get; set; }
    }
}