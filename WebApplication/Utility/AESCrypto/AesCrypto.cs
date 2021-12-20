using System;
using System.Security.Cryptography;
using System.Text;

namespace Utility.AESCrypto
{
    public enum CryptoMode
    {
        Encrypt = 1,
        Decrypt = 2
    }
    public class AesCrypto : ICrypto
    {

        private readonly object syncLockObj = new object();
        private ICryptoTransform e;
        private readonly AesCryptoServiceProvider csp;

       public AesCrypto()
        {
            csp = new AesCryptoServiceProvider();
        }
        public void InitSetup(CryptoSetup setup)
        {

            // throw new NotImplementedException();
            csp.Mode = CipherMode.CBC;
            csp.Padding = PaddingMode.PKCS7;
            string passWord = setup != null && !string.IsNullOrWhiteSpace(setup.Password) ? setup.Password : "Pass@word1";
            string salt = setup != null && !string.IsNullOrWhiteSpace(setup.Salt) ? setup.Salt : "S@1tS@lt";

            //a random Init. Vector. just for testing
            string iv = setup != null && !string.IsNullOrWhiteSpace(setup.InitVector) ? setup.InitVector : "e675f725e675f725";

            var spec = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(passWord), Encoding.UTF8.GetBytes(salt), 1);
            byte[] key = spec.GetBytes(16);

            csp.IV = Encoding.UTF8.GetBytes(iv);
            csp.Key = key;
        }

        public string Encrypt(string raw)
        {
            lock (syncLockObj)
            {
                if (e == null)
                { e = csp.CreateEncryptor(); }
                byte[] inputBuffer = Encoding.UTF8.GetBytes(raw);
                byte[] output = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                e = null;
                string encrypted = Convert.ToBase64String(output);

                return encrypted;
            }
        }
        public string Decrypt(string encrypted)
        {
            lock (syncLockObj)
            {
                if (e == null)
                { e = csp.CreateDecryptor(); }
                byte[] output = Convert.FromBase64String(encrypted);
                byte[] decryptedOutput = e.TransformFinalBlock(output, 0, output.Length);
                e = null;
                string decypted = Encoding.UTF8.GetString(decryptedOutput);
                return decypted;
            }
        }

        public void Dispose()
        {

            csp.Clear();
            csp.Dispose();
        }


    }
}
