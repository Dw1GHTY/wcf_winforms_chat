using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void OpenFormChat() 
        {
            FormChat p = new FormChat(txbLoginUsername.Text);

            this.Hide();
            Cursor.Current = Cursors.WaitCursor;
            p.ShowDialog();
            this.Close();
        }      
        //na enter ili klik na login dugme se prenosi username do chat forme
        private void btnLogin_Click(object sender, EventArgs e)
        {    
            OpenFormChat();
        }
        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                OpenFormChat();
            }
        }

    }
}
