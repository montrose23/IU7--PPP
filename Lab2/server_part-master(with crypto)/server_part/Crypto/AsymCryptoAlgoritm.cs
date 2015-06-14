using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace server_part
{
    public class AsymCryptoAlgoritm : AsymCryptoBase
    {
        private RSAParameters keysInfo;
        private RSACryptoServiceProvider rsaCryptoServiceProvider;
        public AsymCryptoAlgoritm() 
        {
            rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            keysInfo = rsaCryptoServiceProvider.ExportParameters(true);
            //File.Create("public.key");
            //byte[] encodedPublicKey = new byte[(int)File.]

        }
        public  byte[] encrypt(byte[] message)
        {
            byte[] result = null;
            
                   // генерирует открытый ключ
            /*byte[] publicKey = new byte[keysInfo.Modulus.Length];
            for (int i = 0; i < keysInfo.Modulus.Length; i++)
                publicKey[i] = keysInfo.Modulus[i];*/
            //rsaCryptoServiceProvider.ImportParameters(keysInfo);
            result = rsaCryptoServiceProvider.Encrypt(message, false);

            return result;
        }

        public  byte[] decrypt(byte[] message)
        {
            byte[] result = null;
          //  RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            //RSAParameters keysInfo = rsaCryptoServiceProvider.ExportParameters(true);
            //rsaCryptoServiceProvider.ImportParameters(keysInfo);
            result = rsaCryptoServiceProvider.Decrypt(message, false);

            return result;
        }
    }
}
