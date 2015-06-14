using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server_part.EventArguments
{
    public class ClientArgs: EventArgs
    {
        public ClientArgs(ClientInfo client)
        {
            _client = client;
        }

        public ClientInfo _client { get; private set; }
    }
}
