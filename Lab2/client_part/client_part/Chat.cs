using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace client_part
{
    public sealed class Chat
    {
        public static Chat get_instance()
        {
            if (_instance == null)
                _instance = new Chat();
            return _instance;
        }

        private Chat()
        {

        }

        public void start(int port, string address, System.Windows.Forms.ListBox lb, string nickname/*System.IO.TextWriter text_writer*/)
        {
            _client = new Client(port, address); //  local
            _client.work();
            _lb = lb;
            _client.nickname = nickname;
            _update_messages = new Thread(non_stop_update);
            _update_messages.Start();
        }

        public void stop()
        {
            if (_update_messages.ThreadState == ThreadState.Running)
                _update_messages.Abort();
            _client.disconnect();
        }

        public static List<string> messages
        {
            get
            {
                return _messages;
            }
        }

        public static List<string> online_clients
        {
            get
            {
                return _online_clients;
            }
        }

        public Client client
        {
            get
            {
                return _client;
            }
        }

        public void non_stop_update()
        {
            while (true)
            {
                if (_messages.Count > 0)
                {
                    foreach (string msg in _messages)
                    {
                        if (msg.Substring(0, 6) == "<file>")
                        {
                            receive_file_data(msg);                            
                            _lb.Items.Add("file recieved");
                        }
                        else
                            _lb.Items.Add(msg);
                    }
                    _lb.SelectedIndex = _lb.Items.Count - 1;
                    _lb.SelectedIndex = -1;
                    _messages.Clear();
                }
            }
        }

        private void receive_file_data(string data)
        {
            int from, to;            

            from = data.IndexOf("<name>");
            to = data.IndexOf("</name>");
            string name = data.Substring(from + 6, to - from - 6);
            //System.Windows.Forms.MessageBox.Show(name);
            from = data.IndexOf("<extension>");
            to = data.IndexOf("</extension>");
            string extension = data.Substring(from + 11, to - from - 11);
            //System.Windows.Forms.MessageBox.Show(extension);
            from = data.IndexOf("<data>");
            to = data.IndexOf("</data>");
            string content = data.Substring(from + 6, to - from - 6);
            //System.Windows.Forms.MessageBox.Show(content);

            create_file(/*_client.path,*/ name, extension, content);
        }

        private void create_file(/*string path, */string name, string extension, string content)
        {
            //System.Windows.Forms.MessageBox.Show(path + name + extension);
            File.WriteAllText(name + extension, content);
        }

        private static Chat _instance = null;
        private static Client _client;
        private static List<string> _messages = new List<string>();
        private static List<string> _online_clients = new List<string>();
        private static System.Windows.Forms.ListBox _lb;
        private static Thread _update_messages;
    }
}
