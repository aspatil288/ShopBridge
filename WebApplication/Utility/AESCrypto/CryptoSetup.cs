using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.AESCrypto
{
    public class CryptoSetup
    {
        public string Password { get; set; } //Password
        public string Salt { get; set; } // Salt
        public string InitVector { get; set; } // Initialization Vector

        public string CertificatePath { get; set; } // incase certiticate is stored in a physicial path
        public byte[] CertificateData { get; set; } // incase certiticate is stored in memory

        public string CertificatePassword { get; set; }
        public System.Security.Cryptography.CipherMode Mode { get; set; }

    }
}
