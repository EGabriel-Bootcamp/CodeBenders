using System;
using System.Security.Cryptography;
using System.Text;

namespace BankingSoftware.Common;

// to hash input values
public class Hash
{
    private const int keySize = 16;
    private const int iterations = 350000;
    private readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

    public string HashValues(string[] values)
    {
        var joinedValues = string.Join("", values);

        var salt = new UTF8Encoding(true).GetBytes(joinedValues);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(joinedValues),
            salt,
            iterations,
            hashAlgorithm,
            keySize);

        return Convert.ToHexString(hash);
    }
}