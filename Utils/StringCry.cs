 
using System.Security.Cryptography;
using System.Text;

namespace PeoplePro.Utils;

public static class StringCry
{
    public static string Encrypt(string input, string salt)
    {
        var bytes1 = Encoding.UTF8.GetBytes(input);
        var bytes2 = Encoding.UTF8.GetBytes(salt);
        var hash = SHA256.Create().ComputeHash(bytes2);
        return Convert.ToBase64String(AES_Encrypt(bytes1, hash));
    }

    public static string Decrypt(string input, string salt)
    {
        var bytesToBeDecrypted = Convert.FromBase64String(input);
        var bytes = Encoding.UTF8.GetBytes(salt);
        var hash = SHA256.Create().ComputeHash(bytes);
        return Encoding.UTF8.GetString(AES_Decrypt(bytesToBeDecrypted, hash));
    }

    public static string EncryptString(string text, string salt)
    {
        var bytes1 = Encoding.UTF8.GetBytes(salt);
        var hash = SHA256.Create().ComputeHash(bytes1);
        var bytes2 = Encoding.UTF8.GetBytes(text);
        var randomBytes = GetRandomBytes();
        var bytesToBeEncrypted = new byte[randomBytes.Length + bytes2.Length];
        for (var index = 0; index < randomBytes.Length; ++index)
            bytesToBeEncrypted[index] = randomBytes[index];
        for (var index = 0; index < bytes2.Length; ++index)
            bytesToBeEncrypted[index + randomBytes.Length] = bytes2[index];
        return Convert.ToBase64String(AES_Encrypt(bytesToBeEncrypted, hash));
    }

    public static string DecryptString(string text, string salt)
    {
        var bytes1 = Encoding.UTF8.GetBytes(salt);
        var hash = SHA256.Create().ComputeHash(bytes1);
        var numArray = AES_Decrypt(Convert.FromBase64String(text), hash);
        var saltLength = GetSaltLength();
        var bytes2 = new byte[numArray.Length - saltLength];
        for (var index = 0; index < bytes2.Length; ++index)
            bytes2[index] = numArray[index + saltLength];
        return Encoding.UTF8.GetString(bytes2);
    }

    private static byte[] GetRandomBytes()
    {
        var data = new byte[GetSaltLength()];
        RandomNumberGenerator.Create().GetBytes(data);
        return data;
    }

    private static int GetSaltLength() => 8;

    private static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] saltBytes)
    {
        var salt = new byte[8]
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8
        };
        using (var memoryStream = new MemoryStream())
        {
            using (var rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.KeySize = 256;
                rijndaelManaged.BlockSize = 128;
                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(saltBytes, salt, 1000);
                rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
                rijndaelManaged.Mode = CipherMode.CBC;
                using (var cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cryptoStream.Close();
                }
                return memoryStream.ToArray();
            }
        }
    }

    private static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] saltBytes)
    {
        var salt = new byte[8]
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8
        };
        using (var memoryStream = new MemoryStream())
        {
            using (var rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.KeySize = 256;
                rijndaelManaged.BlockSize = 128;
                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(saltBytes, salt, 1000);
                rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
                rijndaelManaged.Mode = CipherMode.CBC;
                using (var cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cryptoStream.Close();
                }
                return memoryStream.ToArray();
            }
        }
    }
}