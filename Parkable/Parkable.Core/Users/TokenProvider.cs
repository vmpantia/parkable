using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Parkable.Infra.Databases.Entities;
using Parkable.Shared.Settings;
using System.Security.Claims;
using System.Text;

namespace Parkable.Core.Users
{
    public sealed class TokenProvider
    {
        private readonly JwtSetting _jwtSetting;

        public TokenProvider(JwtSetting jwtSetting) => 
            _jwtSetting = jwtSetting;

        public string Create(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress),
                ]),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSetting.ExpirationInMinutes),
                SigningCredentials = credentials,
                Issuer = _jwtSetting.Issuer,
                Audience = _jwtSetting.Audience,
            };

            var handler = new JsonWebTokenHandler();

            var token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
