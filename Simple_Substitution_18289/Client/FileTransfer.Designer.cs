namespace Client
{
    partial class FormFileTransfer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileTransfer));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txbFilePreview = new System.Windows.Forms.TextBox();
            this.lblFilePreview = new System.Windows.Forms.Label();
            this.txbCryptedFilePreview = new System.Windows.Forms.TextBox();
            this.cboxCryptionChoice = new System.Windows.Forms.ComboBox();
            this.lblChooseCryptionAlgorithm = new System.Windows.Forms.Label();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(320, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(327, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Crypted File Transfer";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseFile.Font = new System.Drawing.Font("Arial", 15F);
            this.btnChooseFile.ForeColor = System.Drawing.Color.Purple;
            this.btnChooseFile.Location = new System.Drawing.Point(12, 437);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(150, 88);
            this.btnChooseFile.TabIndex = 1;
            this.btnChooseFile.Text = "Select file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txbFilePreview
            // 
            this.txbFilePreview.Location = new System.Drawing.Point(12, 89);
            this.txbFilePreview.Multiline = true;
            this.txbFilePreview.Name = "txbFilePreview";
            this.txbFilePreview.ReadOnly = true;
            this.txbFilePreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbFilePreview.Size = new System.Drawing.Size(445, 322);
            this.txbFilePreview.TabIndex = 2;
            // 
            // lblFilePreview
            // 
            this.lblFilePreview.AutoSize = true;
            this.lblFilePreview.Font = new System.Drawing.Font("Arial", 15F);
            this.lblFilePreview.ForeColor = System.Drawing.Color.White;
            this.lblFilePreview.Location = new System.Drawing.Point(12, 63);
            this.lblFilePreview.Name = "lblFilePreview";
            this.lblFilePreview.Size = new System.Drawing.Size(121, 23);
            this.lblFilePreview.TabIndex = 3;
            this.lblFilePreview.Text = "File preview:";
            // 
            // txbCryptedFilePreview
            // 
            this.txbCryptedFilePreview.Location = new System.Drawing.Point(489, 89);
            this.txbCryptedFilePreview.Multiline = true;
            this.txbCryptedFilePreview.Name = "txbCryptedFilePreview";
            this.txbCryptedFilePreview.ReadOnly = true;
            this.txbCryptedFilePreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbCryptedFilePreview.Size = new System.Drawing.Size(421, 322);
            this.txbCryptedFilePreview.TabIndex = 4;
            // 
            // cboxCryptionChoice
            // 
            this.cboxCryptionChoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboxCryptionChoice.FormattingEnabled = true;
            this.cboxCryptionChoice.IntegralHeight = false;
            this.cboxCryptionChoice.Location = new System.Drawing.Point(168, 475);
            this.cboxCryptionChoice.Name = "cboxCryptionChoice";
            this.cboxCryptionChoice.Size = new System.Drawing.Size(154, 21);
            this.cboxCryptionChoice.TabIndex = 5;
            this.cboxCryptionChoice.SelectedIndexChanged += new System.EventHandler(this.cboxCryptionChoice_SelectedIndexChanged);
            // 
            // lblChooseCryptionAlgorithm
            // 
            this.lblChooseCryptionAlgorithm.AutoSize = true;
            this.lblChooseCryptionAlgorithm.Font = new System.Drawing.Font("Arial", 15F);
            this.lblChooseCryptionAlgorithm.ForeColor = System.Drawing.Color.White;
            this.lblChooseCryptionAlgorithm.Location = new System.Drawing.Point(164, 449);
            this.lblChooseCryptionAlgorithm.Name = "lblChooseCryptionAlgorithm";
            this.lblChooseCryptionAlgorithm.Size = new System.Drawing.Size(158, 23);
            this.lblChooseCryptionAlgorithm.TabIndex = 6;
            this.lblChooseCryptionAlgorithm.Text = "Choose cryption:";
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncryptFile.Font = new System.Drawing.Font("Arial", 15F);
            this.btnEncryptFile.ForeColor = System.Drawing.Color.Purple;
            this.btnEncryptFile.Location = new System.Drawing.Point(328, 437);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(129, 88);
            this.btnEncryptFile.TabIndex = 7;
            this.btnEncryptFile.Text = "Encrypt file";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendFile.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.btnSendFile.ForeColor = System.Drawing.Color.Purple;
            this.btnSendFile.Location = new System.Drawing.Point(772, 437);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(138, 88);
            this.btnSendFile.TabIndex = 8;
            this.btnSendFile.Text = "Send file";
            this.btnSendFile.UseVisualStyleBackColor = true;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Italic);
            this.lblFileName.ForeColor = System.Drawing.Color.White;
            this.lblFileName.Location = new System.Drawing.Point(139, 63);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(131, 24);
            this.lblFileName.TabIndex = 9;
            this.lblFileName.Text = "<File_Name>";
            // 
            // FormFileTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(922, 558);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnEncryptFile);
            this.Controls.Add(this.lblChooseCryptionAlgorithm);
            this.Controls.Add(this.cboxCryptionChoice);
            this.Controls.Add(this.txbCryptedFilePreview);
            this.Controls.Add(this.lblFilePreview);
            this.Controls.Add(this.txbFilePreview);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFileTransfer";
            this.Text = "File Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txbFilePreview;
        private System.Windows.Forms.Label lblFilePreview;
        private System.Windows.Forms.TextBox txbCryptedFilePreview;
        private System.Windows.Forms.ComboBox cboxCryptionChoice;
        private System.Windows.Forms.Label lblChooseCryptionAlgorithm;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Label lblFileName;
    }
}