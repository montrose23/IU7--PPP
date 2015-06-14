using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using server_part.ChainOfResponsibility;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace server_part
{
    public class ServerManager
    {
        public ServerManager(int port, System.IO.TextWriter out_writer)
        {
            _server = new TcpServer(port, out_writer);
            _clients = new List<ClientInfo>();
            _new_clients = new List<ClientInfo>();
        }

        private void client_acception()
        {
            _server.accept_new_client += _server_accept_new_client;            
        }

        void _server_accept_new_client(object sender, EventArguments.ClientArgs e)
        {
            _new_clients.Add(e._client);
            Console.WriteLine("New client");
        }

        private void get_host()
        {
            //  получение имени компьютера
            string host = System.Net.Dns.GetHostName();
            //  получение ip-адреса
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
            Console.WriteLine("IP address: " + ip.ToString());
        }

        private void delete_inaccessible_clients()
        {
            _clients.RemoveAll(delegate(ClientInfo client_info)
            {
                if (!client_info._is_connected)
                {
                    Console.WriteLine("Client disconnected");
                    return true;
                }
                return false;
            });
        }

        private void replace_clients()
        {
            if (_new_clients.Count > 0)
            {
                _clients.AddRange(_new_clients);
                _new_clients.Clear();
            }
        }


        public void start_work()
        {
            get_host();
            _server.work();
            client_acception();
            start_receiving();
        }

        private void interrapt_work()
        {
            _server.interrapt_work();
            foreach (ClientInfo client in _clients)
            {
                client._client.Close();
                Console.WriteLine("Client disconnected");
            }
        }

        public void start_receiving()
        {
            _receiving_messages = new Thread(get_massages);
            _receiving_messages.Start();
        }

        private void get_massages()
        {
            int[] requests = { 1, 2, 3 };
            Handler decrypt_handler = new DecryptHandler();                        
            Handler log_nadler = new LogHandler();
            Handler encrypt_handler = new EncryptHandler();
            Handler resend_handler = new ResendHandler();
            decrypt_handler.set_successor(log_nadler);
            log_nadler.set_successor(encrypt_handler);
            encrypt_handler.set_successor(resend_handler);
            

            while (true)
            {
                delete_inaccessible_clients();
                replace_clients();
                foreach (ClientInfo client in _clients)
                {
                    if (client._is_connected)
                    {
                        ClientInfo temp = client;
                        NetworkStream stream = temp._client.GetStream();
                        read_from_stream(stream, temp);

                     //   Console.WriteLine(String.Concat("Client sent: ", UTF8Encoding.UTF8.GetString(temp._buffer.ToArray()), " --- "));
                       
                        foreach (int request in requests)
                            decrypt_handler.handle_request(request, ref temp);

                      //  Console.WriteLine(String.Concat("Server decrypted to: ", UTF8Encoding.UTF8.GetString(temp._buffer.ToArray()), " --- "));

                        foreach (int request in requests)
                            encrypt_handler.handle_request(request, ref temp);

                       // Console.WriteLine(String.Concat("Server encrypted again to: ", UTF8Encoding.UTF8.GetString(temp._buffer.ToArray()), "\n"));

                        resend_messages(client);
                    }
                }
            }
        }

        private void resend_messages(ClientInfo client)
        {
            if (client._buffer.Count > 0)
            {
                {
                    byte[] message = client._buffer.ToArray();
                    client._buffer.Clear();

                    foreach (ClientInfo other_client_ in _clients)
                    {
                        if (other_client_ != client)
                        {
                            try
                            {
                                other_client_._client.GetStream().Write(message, 0, message.Length);
                            }
                            catch
                            {
                                other_client_._is_connected = false;
                                other_client_._client.Close();
                            }
                        }
                    }
                }
            }
        }

        private void read_from_stream(NetworkStream stream, ClientInfo client)
        {
            while (stream.DataAvailable)
            {
                int read_byte = stream.ReadByte();
                if (read_byte != -1)
                {
                    client._buffer.Add((byte)read_byte);
                }
            }
        }

        private TcpServer _server;
        private List<ClientInfo> _clients;
        private List<ClientInfo> _new_clients;
        private Thread _receiving_messages;
    }
}
