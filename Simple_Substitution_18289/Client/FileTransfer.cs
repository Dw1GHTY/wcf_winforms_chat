using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{

    public partial class FormFileTransfer : Form
    {
        public string cryptionAlgorithm = null;

        private string fileName = null;

        public FormFileTransfer()
        {
            InitializeComponent();


            //dodavanje opcija za kriptovanje
            cboxCryptionChoice.Items.Insert(0, "Simple substitution");
            cboxCryptionChoice.Items.Insert(1, "A5/2");
        }

        //biranje fajla
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Postavite opcije po potrebi
            openFileDialog.Title = "Izaberite fajl";
            openFileDialog.Filter = "Svi fajlovi (*.*)|*.*";

            // Prikazivanje File Explorer dijaloga
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName);
                string fileContent = ReadFile(openFileDialog.FileName);

                SetText(fileContent);
                SetFileName(fileName);
            }
        }

        private void SetText(string text) 
        {
            txbFilePreview.Text = text;
        }
        private void SetFileName(string fileName) 
        {
            this.fileName = fileName;
            lblFileName.Text = this.fileName;
        }
        private void cboxCryptionChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cryptionAlgorithm = cboxCryptionChoice.SelectedItem.ToString();
        }

        private string ReadFile(string filePath)
        {
            try
            {
                // Koristite StreamReader za čitanje sadržaja fajla
                using (StreamReader sr = new StreamReader(filePath))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom čitanja fajla: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}
