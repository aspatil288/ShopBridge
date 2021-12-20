using System;

namespace Utility.AESCrypto
{
    public interface ICrypto : IDisposable
    {

        void InitSetup(CryptoSetup setup);

        string Decrypt(string encrypted);
        string Encrypt(string raw);


    }
}
