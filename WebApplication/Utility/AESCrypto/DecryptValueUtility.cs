namespace Utility.AESCrypto
{
    public class DecryptValueUtility
    {
        private readonly AesCrypto crypto = new AesCrypto();
        public string GetDecryptValue(string item)
        {
            crypto.InitSetup(null);
            var value = crypto.Decrypt(item);
            return value;
        }
        public string GetEncryptValue(string item)
        {
            crypto.InitSetup(null);
            var value = crypto.Encrypt(item);
            return value;
        }
    }
}
