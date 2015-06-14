using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_part
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Facade.connect_event(tbNickname.Text, rbtnBinary, rbtnSoap, lbChat, btnConnect, btnDisconnect);     
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Facade.send_message_event(rtbMessage.Text, rtbMessage);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Facade.disconnect_event(btnConnect, btnDisconnect);
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                string path = openFileDialog1.FileName;
                Facade.attach_event(path);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbtnBinary.Enabled = false;
            rbtnSoap.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Chat chat = Chat.get_instance();
            chat.stop();
        }

        private void rbtnSoap_CheckedChanged(object sender, EventArgs e)
        {
            Facade.change_format(rbtnBinary, rbtnSoap);
        }

        private void rbtnBinary_CheckedChanged(object sender, EventArgs e)
        {
            Facade.change_format(rbtnBinary, rbtnSoap);
        }
    }
}
