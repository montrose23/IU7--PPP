namespace client_part
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbChat = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbNickname = new System.Windows.Forms.TextBox();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnSoap = new System.Windows.Forms.RadioButton();
            this.rbtnBinary = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbChat
            // 
            this.lbChat.FormattingEnabled = true;
            this.lbChat.Location = new System.Drawing.Point(12, 12);
            this.lbChat.Name = "lbChat";
            this.lbChat.Size = new System.Drawing.Size(225, 108);
            this.lbChat.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.tbNickname);
            this.groupBox1.Location = new System.Drawing.Point(243, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 106);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nickname:";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(71, 74);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(71, 45);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbNickname
            // 
            this.tbNickname.Location = new System.Drawing.Point(71, 19);
            this.tbNickname.Name = "tbNickname";
            this.tbNickname.Size = new System.Drawing.Size(75, 20);
            this.tbNickname.TabIndex = 1;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(12, 126);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(225, 70);
            this.rtbMessage.TabIndex = 3;
            this.rtbMessage.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(162, 202);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(12, 202);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(75, 23);
            this.btnAttach.TabIndex = 5;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnSoap);
            this.groupBox2.Controls.Add(this.rbtnBinary);
            this.groupBox2.Location = new System.Drawing.Point(243, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 69);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Formatters";
            // 
            // rbtnSoap
            // 
            this.rbtnSoap.AutoSize = true;
            this.rbtnSoap.Location = new System.Drawing.Point(6, 43);
            this.rbtnSoap.Name = "rbtnSoap";
            this.rbtnSoap.Size = new System.Drawing.Size(50, 17);
            this.rbtnSoap.TabIndex = 1;
            this.rbtnSoap.TabStop = true;
            this.rbtnSoap.Text = "Soap";
            this.rbtnSoap.UseVisualStyleBackColor = true;
            this.rbtnSoap.CheckedChanged += new System.EventHandler(this.rbtnSoap_CheckedChanged);
            // 
            // rbtnBinary
            // 
            this.rbtnBinary.AutoSize = true;
            this.rbtnBinary.Location = new System.Drawing.Point(6, 19);
            this.rbtnBinary.Name = "rbtnBinary";
            this.rbtnBinary.Size = new System.Drawing.Size(54, 17);
            this.rbtnBinary.TabIndex = 0;
            this.rbtnBinary.TabStop = true;
            this.rbtnBinary.Text = "Binary";
            this.rbtnBinary.UseVisualStyleBackColor = true;
            this.rbtnBinary.CheckedChanged += new System.EventHandler(this.rbtnBinary_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(421, 236);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbChat);
            this.Name = "Form1";
            this.Text = "Messanger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbChat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbNickname;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnSoap;
        private System.Windows.Forms.RadioButton rbtnBinary;
        private System.Windows.Forms.Label label1;
    }
}

