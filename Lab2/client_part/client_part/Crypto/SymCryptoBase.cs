using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_part
{
    public interface SymCryptoBase
    {
          byte[] encrypt(byte[] message, byte[] key);
          byte[] decrypt(byte[] message, byte[] key);
    }
}
