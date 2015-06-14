using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_part
{
    public  interface AsymCryptoBase
    {
          byte[] encrypt(byte[] message);
          byte[] decrypt(byte[] message);
    }
}
