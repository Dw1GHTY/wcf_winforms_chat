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
        A52_CTR a52_machine = new A52_CTR();
        SimpleSubstitution simpleSubMachine =  new SimpleSubstitution();

        public string cryptionAlgorithm = null;
        private string fileName = null;
        private string fileContent = null;
        private string fileContentCrypted = null;

        public FormFileTransfer()
        {
            InitializeComponent();


            //dodavanje opcija za kriptovanje
            cboxCryptionChoice.Items.Insert(0, "Simple substitution");
            cboxCryptionChoice.Items.Insert(1, "A5/2");
        }


        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Izaberite fajl";
            openFileDialog.Filter = "Svi fajlovi (*.*)|*.*";

            // File Explorer
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName);
                fileContent = ReadFile(openFileDialog.FileName);

                SetFilePreviewText(fileContent);
                SetFileName(fileName);
            }

        }

        private void SetFilePreviewText(string text) 
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
        private void SaveCryptedFile(string cryptedContent)
        {
            // Provera da li je prethodni fajl učitan
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("No file loaded.", "Error");
                return;
            }

            try
            {
                Console.WriteLine("File path: " + fileName);

                // StreamWriter
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(cryptedContent.ToLower());       //dbg: sw = {System.IO.StreamWriter}
                }

                MessageBox.Show("File successfully encrypted and saved.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving encrypted file: {ex.Message}", "Error");
            }
        }
        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            if (cryptionAlgorithm == "Simple substitution")
            {
                fileContentCrypted = simpleSubMachine.Encrypt(fileContent);
                SaveCryptedFile(fileContentCrypted);
            }
            else if (cryptionAlgorithm == "A5/2")
            {
                fileContentCrypted = BitConverter.ToString(a52_machine.Encrypt(fileContent));
                SaveCryptedFile(fileContentCrypted);
            }
            else 
            {
                MessageBox.Show("Select encryption algorithm", "Error");
            }
        }
    }
}
