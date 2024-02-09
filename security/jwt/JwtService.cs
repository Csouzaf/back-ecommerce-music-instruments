using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ecommerce_music_back.security.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ecommerce_music_back.security.jwt
{
    public class JwtService
    {
        private readonly IUserModel _userModel;
       private readonly UserManager<IdentityUser> _userManager;
        public JwtService( IUserModel userModel, UserManager<IdentityUser> userManager)
        {
            _userModel = userModel;
            _userManager = userManager;
        }
        private string masterKey = "MIHcAgEBBEIBX7Q9A5fOJRSY1XzR9KMMxj/LQZSW4npKdao4CrLqqUwYlPe7y4wFxQ3H0QhQw0QE0TZ8aD9ykP3HpENkydBs2yKgBwYFK4EEACOhgYkDgYYABAHEuENJgOmydp+0/W9jbguTJqqoKGqhV9IosloYa336oe+hRpTC0gKo+BZDTTesTq9QEWmAYjF6fJnr/pA8e6ZnxAANpRm5uN2K4Zr5ySEOyPql1sPS0YUSLtrSmykfcrPB7wz05BBfDpqpN/IGGR/HeDsmjLa+7qkh+W4hbD7skvSWtA==";
        
        public string generateJwt(Guid uId, string Name)
        {
            var econdeKey = Encoding.ASCII.GetBytes(masterKey);

            var verifySymmetricBytesEncodeKey = new SymmetricSecurityKey(econdeKey);

            var verifySimmetricBytesAndAlgorithmsSignature = new SigningCredentials(verifySymmetricBytesEncodeKey, SecurityAlgorithms.HmacSha512Signature);

            var getName = _userModel.findByName(Name);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, getName.FirstName),
             
            };

            var header = new JwtHeader(verifySimmetricBytesAndAlgorithmsSignature);

            var payload = new JwtPayload(Guid.NewGuid().ToString(), null, claims, null, DateTime.UtcNow.AddHours(2));

            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }

        public JwtSecurityToken verifyJwtToken(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var encodeKey = Encoding.ASCII.GetBytes(masterKey);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(encodeKey),

                ValidateIssuerSigningKey = true,

                ValidateIssuer = false,

                ValidateAudience = false,

                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken) validatedToken;
        }

    }
}