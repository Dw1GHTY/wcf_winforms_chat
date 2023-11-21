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


namespace Client
{
    public partial class FormChat : Form
    {
        SimpleSubstitution simpleSubMachine = 
        new SimpleSubstitution("abcdefghijklmnopqrstuvwxyz", "zyxwvutsrqponmlkjihgfedcba");

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
            //LOGIN && SERVICE INITIALIZATION
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

            //append text to current user in standartChatRoom
            txbChatRoomCrypted.AppendText(username.ToUpper() + ": " + message + Environment.NewLine);

            //append text to current user in CryptedChatRoom
            txbChatRoom.AppendText(username.ToUpper() + ": " + simpleSubMachine.Encrypt(message) + Environment.NewLine);

            //send to client2
            if (!string.IsNullOrEmpty(message))
                pServer.SendMessage(message);

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
