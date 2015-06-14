using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace server_part
{
    public class ClientInfo
    {
        public ClientInfo(TcpClient client)
        {
            _client = client;
            _is_connected = true;
            _buffer = new List<byte>();
        }

        public TcpClient _client { get; private set; }
        public List<byte> _buffer { get; private set; }
        public bool _is_connected { get; set; }
    }
}
