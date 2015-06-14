using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_part
{
    public  interface FactoryBase
    {
          SymCryptoAlgorithm CreateSymAlgorithm();
          AsymCryptoAlgoritm CreateAsymAlgorithm();

          B64CryptoAlgorithm CreateB64Algorithm();
    }
}
