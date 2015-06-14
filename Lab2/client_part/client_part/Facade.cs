using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_part
{
    public static class Facade
    {
        public static void connect_event(string nickname, RadioButton rbtnBinary, RadioButton rbtnSoap, ListBox lbChat, Button btnConnect, Button btnDisconnect)
        {
            Chat chat = Chat.get_instance();
            if (nickname != "")
            {
                chat.start(11000, "127.0.0.1", lbChat, nickname);                
                chat.client.send_message("Client " + nickname + " connected to conversation");

                rbtnBinary.Enabled = true;
                rbtnSoap.Enabled = true;
                rbtnBinary.Checked = true;

                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
            }
            else
                MessageBox.Show("Error", "Input your name", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        public static void send_message_event(string message, RichTextBox rtbMessage)
        {
            Chat chat = Chat.get_instance();
            chat.client.send_message(chat.client.nickname + ": " + rtbMessage.Text);
            rtbMessage.Clear();
            
        }

        public static void disconnect_event(Button btnConnect, Button btnDisconnect)
        {
            Chat chat = Chat.get_instance();
            chat.client.send_message("Client " + chat.client.nickname + " disconnected from conversation");
            chat.stop();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        public static void change_format(RadioButton rbtnBinary, RadioButton rbtnSoap)
        {
            Chat chat = Chat.get_instance();

            if (rbtnSoap.Checked == true)
                chat.client.set_format("soap");
            else
                chat.client.set_format("binary");
        }

        public static void attach_event(string path)
        {
            Chat chat = Chat.get_instance();
            chat.client.send_file(path);
        }
    }
}
