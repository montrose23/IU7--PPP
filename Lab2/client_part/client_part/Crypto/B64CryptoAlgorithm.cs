using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace client_part
{
    public class B64CryptoAlgorithm : B64CryptoBase
    {
        public  string encrypt64(byte[] message)
        {
            string result = Convert.ToBase64String(message);
            return result;
        }


        public  byte[] decrypt64(string message)
        {
            byte[] result = Convert.FromBase64String(message);
            return result;
        }
    }
}

