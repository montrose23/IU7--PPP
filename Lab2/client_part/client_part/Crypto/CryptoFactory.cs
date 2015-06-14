using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_part
{
    public class CryptoFactory : FactoryBase
    {
        public  SymCryptoAlgorithm CreateSymAlgorithm()
        {
            return new SymCryptoAlgorithm();
        }
        public  AsymCryptoAlgoritm CreateAsymAlgorithm()
        {
            return new AsymCryptoAlgoritm();
        }

        public B64CryptoAlgorithm CreateB64Algorithm()
        {
            return new B64CryptoAlgorithm();
        }
    }
}
