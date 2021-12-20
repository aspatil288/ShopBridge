
using System.Text;
using Utility.AESCrypto;

namespace Utility
{
    public class CommonUtility
    {
        AesCrypto _crypto = new AesCrypto();
        private readonly CryptoSetup cryptoSetup;
        public string EncryptDecryptData(string data, char dataType)
        {
            _crypto.InitSetup(cryptoSetup);
            return dataType.Equals("E") ? _crypto.Encrypt(data) : _crypto.Decrypt(data);
        }

        public string CreateConnectionString(string host, string database, string userId, string password)
        {
            StringBuilder sbCon = new StringBuilder();
            sbCon.Append("Server=" + EncryptDecryptData(host, 'D') + ";");
            sbCon.Append("Database=" + EncryptDecryptData(database, 'D') + ";");
            sbCon.Append("Uid=" + EncryptDecryptData(userId, 'D') + ";");
            sbCon.Append("Pwd=" + EncryptDecryptData(password, 'D') + ";");
            sbCon.Append("Allow User Variables = True;");
            sbCon.Append("AllowLoadLocalInfile = true;");
            return sbCon.ToString();
        }

    }
}
