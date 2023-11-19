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
        private string message;

        public FormChat(string userName)
        {
            InitializeComponent();

            //initialize login

            string username = userName;

            InstanceContext context = new InstanceContext(new MyCallback());
            Proxy.ChatServiceClient server = new Proxy.ChatServiceClient(context);

            server.Join(username);
            lblUserName.Text = username;       //Welcome, <username>


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
