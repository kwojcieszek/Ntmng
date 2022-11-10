using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Ntmng.Common;

public class PasswordSha256 : IPasswordService
{
    public static byte[] Salt { get; set; }

    public string HashPassword(string password)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: Salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
    }

    public bool ComparePassword(string password, string hashPassword)
    {
        return HashPassword(password) == hashPassword;
    }
}