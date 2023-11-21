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
        ChatServiceClient pServer;
        private string username;    //current user username
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public FormChat(string userName)
        {
            InitializeComponent();

            

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
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message;
            message = txbMessageBox.Text;

            //append text to current user

            txbChatRoom.AppendText(username.ToUpper()+ ": " + message + Environment.NewLine);
            //send to client2
            if (!string.IsNullOrEmpty(message))
                pServer.SendMessage(message);

            txbMessageBox.Clear();
        }
    }
}
