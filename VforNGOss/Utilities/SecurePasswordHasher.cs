using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

public static class SecurePasswordHasher
{
    public static string HashPassword(string password)
    {
    byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

    // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: password!,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA256,
        iterationCount: 100000,
        numBytesRequested: 256 / 8));

    return hashed;
    }
}
