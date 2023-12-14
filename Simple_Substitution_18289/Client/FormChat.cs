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
        public A52_CTR a52Machine = new A52_CTR();

        ChatServiceClient pServer;

        private string username;
        private bool showCrypted = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void SetCryptionAlgorithm(string cryptionAlgorithm)
        {
            cryptionAlgorithm = cryptionAlgorithm; 
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

        public void UpdateChatRoom(string message, string cryptionAlgorithm)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, string>(UpdateChatRoom), message);
            }
            else
            {
                SetCryptionAlgorithm(cryptionAlgorithm); // Postavi vrednost cryptionAlgorithm

                txbChatRoom.AppendText(message + Environment.NewLine);

                if (cryptionAlgorithm == "Simple substitution")
                    txbChatRoomCrypted.AppendText(simpleSubMachine.Encrypt(message) + Environment.NewLine);
                else if (cryptionAlgorithm == "A5/2")
                    txbChatRoomCrypted.AppendText(BitConverter.ToString(a52Machine.EncryptCTR(message)));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message;
            message = txbMessageBox.Text.ToLower();

            
            if (cryptionAlgorithm != null)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    pServer.SendMessage(message, cryptionAlgorithm); 



                    #region lokalniDeo

                    
                    txbChatRoom.AppendText(username.ToUpper() + ": " + message + Environment.NewLine);

                    
                    if (cryptionAlgorithm == "Simple substitution")
                    {
                        txbChatRoomCrypted.AppendText(username.ToUpper() + ": " + simpleSubMachine.Encrypt(message) + Environment.NewLine);
                        txbMessageBox.Clear();
                    }
                    else if (cryptionAlgorithm == "A5/2") 
                    {
                        txbChatRoomCrypted.AppendText(username.ToUpper() + ": " + BitConverter.ToString(a52Machine.EncryptCTR(message)) + Environment.NewLine);
                        txbMessageBox.Clear();
                    }
                    #endregion

                    

                }
            }
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
