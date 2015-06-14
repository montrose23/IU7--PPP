using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part
{
    public class Manager
    {
        private SymCryptoAlgorithm des;
        private AsymCryptoAlgoritm rsa;
        private B64CryptoAlgorithm base64;


        public Manager(FactoryBase factory)
        {
            //des = factory.CreateSymAlgorithm();
            //rsa = factory.CreateAsymAlgorithm();
            base64 = factory.CreateB64Algorithm();
        }

        public byte[] encrypt(byte[] message, byte[] key)
        {
            return des.encrypt(message, key);
        }

        public byte[] encrypt(byte[] message)
        {
            return rsa.encrypt(message);
        }

        public byte[] decrypt(byte[] message, byte[] key)
        {
            return des.decrypt(message, key);
        }

        public byte[] decrypt(byte[] message)
        {
            return rsa.decrypt(message);
        }

        public string encrypt64(byte[] message)
        {
            return base64.encrypt64(message);
        }

        public byte[] decrypt64(string message)
        {
            return base64.decrypt64(message);
        }
    }
}
