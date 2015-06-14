using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace client_part
{
    public class Client
    {        
        public Client(int port, string connect_ip)
        {
            _client = new TcpClient();
            _client.Connect(IPAddress.Parse(connect_ip), port);
            set_format();
        }

        public void work()
        {
            _client_listener = new Thread(reader);
            _client_listener.Start();
        }

        private void reader()
        {
            while (true)
            {
                    //  получаем поток, который связан с сервером
                NetworkStream network_stream = _client.GetStream();
                List<byte> buffer = new List<byte>();
                    //  если в потоке что-то есть, то считываем
                while (network_stream.DataAvailable)
                {
                    int read_byte = network_stream.ReadByte();
                    if (read_byte != -1)
                        buffer.Add((byte)read_byte);
                }


                if (buffer.Count > 0)
                {
                    //Chat.messages.Add(deserialize(buffer.ToArray()));
                    //
                    byte[] test = buffer.ToArray();

                    Manager cryptManager = new Manager(new CryptoFactory());
                    string message = UTF8Encoding.UTF8.GetString(test);
                    byte[] decrypted = cryptManager.decrypt64(message);
                    //
                    Chat.messages.Add(UTF8Encoding.UTF8.GetString(decrypted));
                }
                    

            }
        }

        public void send_message(string message)
        {
            message.Trim();
            //byte[] buffer = serialize(message);
            byte[] buffer = UTF8Encoding.UTF8.GetBytes(message);
            //_client.GetStream().Write(buffer, 0, buffer.Length);

            //
            Manager cryptManager = new Manager(new CryptoFactory());
            string encrypted = cryptManager.encrypt64(buffer);

            byte[] newMessage = UTF8Encoding.UTF8.GetBytes(encrypted);

            _client.GetStream().Flush();
            _client.GetStream().Write(newMessage, 0, newMessage.Length);
            
            //

            if (message.Substring(0, 6) != "<file>")
                Chat.messages.Add(message);
        }


        public void send_file(string path)
        {
            if (File.Exists(path))
            {
                FileInformation file_info = new FileInformation(path);               
                send_message(file_info.for_send);
            }
        }

        private byte[] serialize(string message)
        {
            MemoryStream stream = new MemoryStream();
            _serializator.Serialize(stream, message);
            return stream.ToArray();
        }

        public string deserialize(byte[] binary_data)
        {
            MemoryStream stream = new MemoryStream(binary_data);
            return (string)_serializator.Deserialize(stream);
        }

        public void disconnect()
        {
            _client_listener.Abort();
            _client_listener.Join();
            if (_client != null)
                _client.Close();
        }
        ~Client()
        {
            _client_listener.Abort();
            _client_listener.Join();
            if (_client != null)
                _client.Close();
        }

        public void set_format(string variant = "binary")
        {
            switch (variant)
            {
                case "binary":
                    _serializator = new BinaryFormatter();                    
                    break;
                case "soap":
                    _serializator = new SoapFormatter();
                    break;
                default:
                    _serializator = new BinaryFormatter();
                    break;
            }
        }


        public string nickname
        {
            get
            {
                return _nickname;
            }

            set
            {
                _nickname = value;
            }
        }

        public string path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
            }
        }

        private IFormatter _serializator;
        private Thread _client_listener;
        private static TcpClient _client;
        private string _nickname;
        private string _path = "C:\\";
    }
}
