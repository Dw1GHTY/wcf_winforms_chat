using Client.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Client
{
    public partial class FormChat : Form
    {

        public SimpleSubstitution simpleSubMachine = new SimpleSubstitution(); 

        ChatServiceClient pServer;

        private string username;
        private bool showCrypted = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public FormChat(string userName)
        {
            InitializeComponent();

            txbChatRoomCrypted.Visible = showCrypted;
            username = userName;
            InstanceContext context = new InstanceContext(new MyCallback(this));
            Proxy.ChatServiceClient server = new Proxy.ChatServiceClient(context);
            pServer = server;  

            pServer.Join(username);
            lblUserName.Text = username;
        }

        public void UpdateChatRoom(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateChatRoom), message);
            }
            else
            {
                txbChatRoom.AppendText(message + Environment.NewLine);

                txbChatRoomCrypted.AppendText(simpleSubMachine.Encrypt(message) + Environment.NewLine);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message;
            message = txbMessageBox.Text;

            //send to client2
            if (!string.IsNullOrEmpty(message))
                pServer.SendMessage(message);


            txbChatRoom.AppendText(username.ToUpper() + ": " + message + Environment.NewLine);

            txbChatRoomCrypted.AppendText(username.ToUpper() + ": " + simpleSubMachine.Encrypt(message) + Environment.NewLine);

            txbMessageBox.Clear();
        }

        private void cbxToggleCryption_CheckedChanged(object sender, EventArgs e)
        {
            showCrypted = !showCrypted;
            if (showCrypted)
                txbChatRoomCrypted.Visible = showCrypted;
            else
                txbChatRoomCrypted.Visible = showCrypted;
        }
    }
}
