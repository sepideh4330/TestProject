using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Project.Common.Helpers
{
    public class StringEncryption
    {
        private readonly Random _random;
        private readonly byte[] _key;
        private readonly RijndaelManaged _rm;
        private readonly UTF8Encoding _encoder;

        public StringEncryption()
        {
            this._random = new Random();
            this._rm = new RijndaelManaged();
            this._encoder = new UTF8Encoding();
            this._key = Convert.FromBase64String("Your+Secret+Static+Encryption+Key+Goes+Here=");
        }

        public string Encrypt(string unencrypted)
        {
            var vector = new byte[16];
            this._random.NextBytes(vector);
            var cryptogram = vector.Concat(this.Encrypt(this._encoder.GetBytes(unencrypted), vector));
            return Convert.ToBase64String(cryptogram.ToArray());
        }

        public string Decrypt(string encrypted)
        {
            var cryptogram = Convert.FromBase64String(encrypted);
            if (cryptogram.Length < 17)
            {
                throw new ArgumentException("Not a valid encrypted string", nameof(encrypted));
            }

            var vector = cryptogram.Take(16).ToArray();
            var buffer = cryptogram.Skip(16).ToArray();
            return this._encoder.GetString(this.Decrypt(buffer, vector));
        }

        #region Private Members

        private IEnumerable<byte> Encrypt(byte[] buffer, byte[] vector)
        {
            var encryptor = this._rm.CreateEncryptor(this._key, vector);
            return Transform(buffer, encryptor);
        }

        private byte[] Decrypt(byte[] buffer, byte[] vector)
        {
            var decryptor = this._rm.CreateDecryptor(this._key, vector);
            return Transform(buffer, decryptor);
        }

        private static byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            var stream = new MemoryStream();
            using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }

            return stream.ToArray();
        }

        #endregion
    }
}
