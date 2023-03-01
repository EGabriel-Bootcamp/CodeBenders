using System;
using System.Security.Cryptography;
using System.Text;

namespace BankingSoftware.Common;

public class Hash
{
    const int keySize = 16;
    const int iterations = 350000;
    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

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