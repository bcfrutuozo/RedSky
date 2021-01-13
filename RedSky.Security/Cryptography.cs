using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RedSky.Security
{
    // Author: Bruno Corrêa Frutuozo
    // Date: 07/08/2014

    /// <summary>
    ///     Provides encryption logic and algorithms
    /// </summary>
    public static class Cryptography
    {
        /// <summary>
        ///     Computes an AES encryption on a plaintext, specifying both the AES key and its Initialization Vector
        /// </summary>
        /// <param name="plainText">Text which will be encrypted</param>
        /// <param name="Key">AES Key</param>
        /// <param name="IV">Initialization Vector</param>
        /// <returns>Encrypted byte array</returns>
        public static byte[] AES(string plainText, byte[] Key, byte[] IV)
        {
            using (var objAlg = Aes.Create())
            {
                objAlg.BlockSize = 128;
                objAlg.Mode = CipherMode.CBC;
                objAlg.KeySize = 256;
                objAlg.Key = Key;
                objAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                var encryptor = objAlg.CreateEncryptor(objAlg.Key, objAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        /// <summary>
        ///     Encrypts a common text
        /// </summary>
        /// <param name="clearText">Text to be encrypted</param>
        /// <param name="salt">Salt to be used as hash</param>
        /// <returns>Encrypted text</returns>
        public static string EncryptWithSalt(string clearText, string salt)
        {
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(salt,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return clearText;
        }

        /// <summary>
        ///     Decrypts a common text
        /// </summary>
        /// <param name="cipherText">Text to be decrypted</param>
        /// <param name="salt">Salt to be used as hash</param>
        /// <returns>Decrypted text</returns>
        public static string DecryptWithSalt(string cipherText, string salt)
        {
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(salt,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return cipherText;
        }

        /// <summary>
        ///     Computes a MD5 encryption on a string and return the ciphertext on hexadecimal string format
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>Ciphertext on hexadecimal format</returns>
        public static string MD5(string plainText)
        {
            using (MD5 objMD5 = new MD5CryptoServiceProvider())
            {
                return Encoding.Default.GetString(objMD5.ComputeHash(Encoding.Default.GetBytes(plainText)));
            }
        }

        /// <summary>
        ///     Computes a SHA1 encryption on a string and return the ciphertext on hexadecimal string format
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>Ciphertext on hexadecimal format</returns>
        public static string SHA1(string plainText)
        {
            using (SHA1 objSha = new SHA1Managed())
            {
                return Encoding.Default.GetString(objSha.ComputeHash(Encoding.Default.GetBytes(plainText)));
            }
        }

        /// <summary>
        ///     Computes a SHA256 encryption on a string and return the ciphertext on hexadecimal string format
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>Ciphertext on hexadecimal format</returns>
        public static string SHA256(string plainText)
        {
            using (SHA256 objSha = new SHA256Managed())
            {
                return Encoding.Default.GetString(objSha.ComputeHash(Encoding.Default.GetBytes(plainText)));
            }
        }

        /// <summary>
        ///     Computes a SHA384 encryption on a string and return the ciphertext on hexadecimal string format
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>Ciphertext on hexadecimal format</returns>
        public static string SHA384(string plainText)
        {
            using (SHA384 objSha = new SHA384Managed())
            {
                return Encoding.Default.GetString(objSha.ComputeHash(Encoding.Default.GetBytes(plainText)));
            }
        }

        /// <summary>
        ///     Computes a SHA512 encryption on a string and return the ciphertext on hexadecimal string format
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>Ciphertext on hexadecimal format</returns>
        public static string SHA512(string plainText)
        {
            using (SHA512 objSha = new SHA512Managed())
            {
                return Encoding.Default.GetString(objSha.ComputeHash(Encoding.Default.GetBytes(plainText)));
            }
        }

        /// <summary>
        ///     Computes a SHA1 encryption on a string and return the byte array from the 64 encoded hash.
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>SHA converted to base64 string</returns>
        public static string GetBase64SHA1(string plainText)
        {
            using (var sha = new SHA1Managed())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        /// <summary>
        ///     Computes a SHA256 encryption on a string and return the byte array from the 64 encoded hash.
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>SHA converted to base64 string</returns>
        public static string GetBase64SHA256(string plainText)
        {
            using (var sha = new SHA256Managed())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        /// <summary>
        ///     Computes a SHA384 encryption on a string and return the byte array from the 64 encoded hash.
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>SHA converted to base64 string</returns>
        public static string GetBase64SHA384(string plainText)
        {
            using (var sha = new SHA384Managed())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        /// <summary>
        ///     Computes a SHA512 encryption on a string and return the byte array from the 64 encoded hash.
        /// </summary>
        /// <param name="plainText">Plaintext which will be encrypted</param>
        /// <returns>SHA converted to base64 string</returns>
        public static string GetBase64SHA512(string plainText)
        {
            using (var sha = new SHA512Managed())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (var b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}