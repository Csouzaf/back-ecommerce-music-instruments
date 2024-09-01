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
        private readonly IAdminUser _AdminUser;
        private readonly ICommonUser _commonUser;

        public JwtService( IAdminUser AdminUser, ICommonUser commonUser)
        {
            _AdminUser = AdminUser;
            _commonUser = commonUser;
        }
        private string masterKey = "66bfde1acdd9b8c228a8b8d66100c5734188d64d917dd5c5bfbbd92b39b5a0cc";
        
        public string generateJwt(Guid uuId, string Name)
        {
            var econdeKey = Convert.FromHexString(masterKey);

            var verifySymmetricBytesEncodeKey = new SymmetricSecurityKey(econdeKey);

            var verifySimmetricBytesAndAlgorithmsSignature = new SigningCredentials(verifySymmetricBytesEncodeKey, SecurityAlgorithms.HmacSha256Signature);

            var getName = _AdminUser.findByName(Name);
            var getNameCommonUser = _commonUser.findByName(Name);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, uuId.ToString()),
                new Claim("uuid", uuId.ToString()),
                new Claim("name", getName.FirstName), 
                new Claim("nameCommonUser", getNameCommonUser.FirstName),
                new Claim("roleAdmin", getName.Role),
                new Claim("roleUser", getNameCommonUser.Role),
           
                //Guid.NewGuid().ToString()
            };

            var header = new JwtHeader(verifySimmetricBytesAndAlgorithmsSignature);

            var payload = new JwtPayload(null, null, claims, DateTime.UtcNow, DateTime.UtcNow.AddHours(2));

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