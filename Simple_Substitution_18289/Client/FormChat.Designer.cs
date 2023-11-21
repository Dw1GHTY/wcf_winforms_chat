namespace Client
{
    partial class FormChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            this.txbChatRoom = new System.Windows.Forms.TextBox();
            this.cbxToggleCryption = new System.Windows.Forms.CheckBox();
            this.txbMessageBox = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txbChatRoomCrypted = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbChatRoom
            // 
            this.txbChatRoom.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbChatRoom.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbChatRoom.Location = new System.Drawing.Point(12, 93);
            this.txbChatRoom.Multiline = true;
            this.txbChatRoom.Name = "txbChatRoom";
            this.txbChatRoom.ReadOnly = true;
            this.txbChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbChatRoom.Size = new System.Drawing.Size(377, 300);
            this.txbChatRoom.TabIndex = 0;
            // 
            // cbxToggleCryption
            // 
            this.cbxToggleCryption.AutoSize = true;
            this.cbxToggleCryption.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxToggleCryption.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbxToggleCryption.Location = new System.Drawing.Point(12, 399);
            this.cbxToggleCryption.Name = "cbxToggleCryption";
            this.cbxToggleCryption.Size = new System.Drawing.Size(166, 27);
            this.cbxToggleCryption.TabIndex = 1;
            this.cbxToggleCryption.Text = "Toggle Cryption";
            this.cbxToggleCryption.UseVisualStyleBackColor = true;
            this.cbxToggleCryption.CheckedChanged += new System.EventHandler(this.cbxToggleCryption_CheckedChanged);
            // 
            // txbMessageBox
            // 
            this.txbMessageBox.AcceptsTab = true;
            this.txbMessageBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMessageBox.Location = new System.Drawing.Point(12, 429);
            this.txbMessageBox.Multiline = true;
            this.txbMessageBox.Name = "txbMessageBox";
            this.txbMessageBox.Size = new System.Drawing.Size(654, 67);
            this.txbMessageBox.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Purple;
            this.btnSend.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.Transparent;
            this.btnSend.Location = new System.Drawing.Point(672, 429);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 67);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.DimGray;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Location = new System.Drawing.Point(344, 59);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(76, 31);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Chat";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(105, 25);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Welcome, ";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Purple;
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUserName.Location = new System.Drawing.Point(113, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(72, 27);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "label1";
            // 
            // txbChatRoomCrypted
            // 
            this.txbChatRoomCrypted.BackColor = System.Drawing.SystemColors.Control;
            this.txbChatRoomCrypted.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbChatRoomCrypted.Font = new System.Drawing.Font("Arial", 15F);
            this.txbChatRoomCrypted.Location = new System.Drawing.Point(395, 93);
            this.txbChatRoomCrypted.Multiline = true;
            this.txbChatRoomCrypted.Name = "txbChatRoomCrypted";
            this.txbChatRoomCrypted.ReadOnly = true;
            this.txbChatRoomCrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbChatRoomCrypted.Size = new System.Drawing.Size(367, 300);
            this.txbChatRoomCrypted.TabIndex = 7;
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(774, 519);
            this.Controls.Add(this.txbChatRoomCrypted);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txbMessageBox);
            this.Controls.Add(this.cbxToggleCryption);
            this.Controls.Add(this.txbChatRoom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbChatRoom;
        private System.Windows.Forms.CheckBox cbxToggleCryption;
        private System.Windows.Forms.TextBox txbMessageBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txbChatRoomCrypted;
    }
}

