using System.Security.Cryptography;
using Parkable.Core.Users.Inferfaces;

namespace Parkable.Core.Users
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        private readonly HashAlgorithmName Alogrithm = HashAlgorithmName.SHA512;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Alogrithm, HashSize);

            var hashedPassword = $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";

            return hashedPassword;
        }

        public bool Verify(string password, string hashedPassword)
        {
            string[] parts = hashedPassword.Split('-');
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Alogrithm, HashSize);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}
