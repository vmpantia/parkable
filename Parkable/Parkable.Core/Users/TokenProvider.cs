using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Parkable.Core.Users.Inferfaces;
using Parkable.Infra.Databases.Entities;
using Parkable.Shared.Settings;
using System.Security.Claims;
using System.Text;

namespace Parkable.Core.Users
{
    public sealed class TokenProvider : ITokenProvider
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
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.Role, user.Type.ToString()),
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
