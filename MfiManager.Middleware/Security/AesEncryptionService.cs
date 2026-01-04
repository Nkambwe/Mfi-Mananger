using System.Security.Cryptography;
using System.Text;

namespace MfiManager.Middleware.Security {
    public sealed class AesEncryptionService : IEncryptionService {
        private readonly byte[] _key;

        public AesEncryptionService(IConfiguration configuration) {
            var keyBase64 = configuration["Encryption:Key"];

            if (string.IsNullOrWhiteSpace(keyBase64))
                throw new InvalidOperationException("Encryption key not configured");

            _key = Convert.FromBase64String(keyBase64);
        }

        public string Encrypt(string value) {
            if (string.IsNullOrEmpty(value))
                return value;

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();
            var plainBytes = Encoding.UTF8.GetBytes(value);
            var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            // prepend IV
            var result = new byte[aes.IV.Length + cipherBytes.Length];
            Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
            Buffer.BlockCopy(cipherBytes, 0, result, aes.IV.Length, cipherBytes.Length);

            return Convert.ToBase64String(result);
        }

        public string Decrypt(string value) {
            if (string.IsNullOrEmpty(value))
                return value;

            var fullCipher = Convert.FromBase64String(value);

            using var aes = Aes.Create();
            aes.Key = _key;

            var iv = new byte[aes.BlockSize / 8];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            var plainBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }

}
