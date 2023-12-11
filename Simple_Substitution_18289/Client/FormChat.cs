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
        public string cryptionAlgorithm = null;

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

            //dodavanje izbora algoritama u combobox
            cboxCryptionChoice.Items.Insert(0, "Simple substitution");
            cboxCryptionChoice.Items.Insert(1, "A5/2");
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

            //check selected algorithm | if null then fuck off

            //send to client2
            if (!string.IsNullOrEmpty(message))
                pServer.SendMessage(message);


            txbChatRoom.AppendText(username.ToUpper() + ": " + message + Environment.NewLine);
            //if simplesub then this
            txbChatRoomCrypted.AppendText(username.ToUpper() + ": " + simpleSubMachine.Encrypt(message) + Environment.NewLine);
            //else a5/2


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

        private void cboxCryptionChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cryptionAlgorithm = cboxCryptionChoice.SelectedItem.ToString();
        }
    }
}
