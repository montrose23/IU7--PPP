using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace client_part
{
    public class SymCryptoAlgorithm : SymCryptoBase
    {
        public  byte[] encrypt(byte[] message, byte[] key)
        {
            byte[] result = null;
            
            try
            {
                DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();
          //      desCryptoServiceProvider.KeySize = 128*8;
                desCryptoServiceProvider.GenerateKey();
                desCryptoServiceProvider.GenerateIV();
                ICryptoTransform destrasformator = desCryptoServiceProvider.CreateEncryptor();
                result = destrasformator.TransformFinalBlock(message, 0, message.Length);
                byte[] temp = desCryptoServiceProvider.Key;
                
                /*for (int i = 0; i < 119; i++)
                    key[i] = 0;*/
                for (int i = 0; i < desCryptoServiceProvider.KeySize/8; i++)
                    key[i] = temp[i];
            }
            catch (KeyNotFoundException e)
            {
                e.GetBaseException();
            }

            return result;
        }

        public  byte[] decrypt(byte[] message, byte[] key)
        {
            byte[] result = null;
            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();
            
            try
            {
                desCryptoServiceProvider.Key = key;
                desCryptoServiceProvider.GenerateIV();
                ICryptoTransform desretransformator = desCryptoServiceProvider.CreateDecryptor();
                result = desretransformator.TransformFinalBlock(message, 0, message.Length);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
                
            return result;
        }
    }
}
