using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_part
{
    public  interface B64CryptoBase
    {
          string encrypt64(byte[] message);
          byte[] decrypt64(string message);
    }
}
