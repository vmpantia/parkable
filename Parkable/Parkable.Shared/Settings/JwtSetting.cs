using Microsoft.Extensions.Configuration;

namespace Parkable.Shared.Settings
{
    public class JwtSetting
    {
        public JwtSetting(string secret, string issuer, string audience, int expirationInMinutes)
        {
            Secret = secret;
            Issuer = issuer;
            Audience = audience;
            ExpirationInMinutes = expirationInMinutes;
        }

        public string Secret { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public int ExpirationInMinutes { get; init; }

        public static JwtSetting FromConfiguration(IConfiguration configuration)
        {
            var secret = configuration[$"{nameof(JwtSetting)}:{nameof(Secret)}"]!;
            var issuer = configuration[$"{nameof(JwtSetting)}:{nameof(Issuer)}"]!;
            var audience = configuration[$"{nameof(JwtSetting)}:{nameof(Audience)}"]!;
            var expirationInMinutes = int.Parse(configuration[$"{nameof(JwtSetting)}:{nameof(ExpirationInMinutes)}"]!);

            return new JwtSetting(secret, issuer, audience, expirationInMinutes);
        }
    }
}
