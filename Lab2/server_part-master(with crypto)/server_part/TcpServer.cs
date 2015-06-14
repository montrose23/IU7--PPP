using server_part.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server_part
{
    public class TcpServer: IServer
    {
        /*public static TcpServer get_instance(int port, System.IO.TextWriter out_writer)
        {
            if (_instance == null)
                _instance = new TcpServer(port, out_writer);
            return _instance;
        }*/

        public TcpServer(int port, System.IO.TextWriter out_writer)
        {
            _port = port;
            _out_writer = out_writer;
            
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
        }

        public void work()
        {
            listen();
        }

        public void listen()
        {
            _client_listener = new Thread(listen_to_clients);
            _client_listener.Start();
        }

        public void listen_to_clients()
        {
            while (true)
            {
                if (accept_new_client != null)
                {
                    EventHandler<ClientArgs> handler = accept_new_client;
                    accept_new_client(this, new ClientArgs(new ClientInfo(_listener.AcceptTcpClient())));
                }
            }
        }

        public event EventHandler<ClientArgs> accept_new_client;

        public void interrapt_work()
        {
            if (_listener != null)
                _listener.Stop();
            if (_client_listener.ThreadState == ThreadState.Running)
                _client_listener.Abort();
        }
     
        //private static TcpServer _instance = null;
        public TcpListener _listener { get; private set; }
        private int _port;
        public Thread _client_listener { get; private set; }
        public System.IO.TextWriter _out_writer { get; private set; }
    }
}
