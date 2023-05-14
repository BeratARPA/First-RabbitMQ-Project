namespace WinFormUIProducer
{
    partial class MainForm
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
            btnConnect = new System.Windows.Forms.Button();
            lstBoxLog = new System.Windows.Forms.ListBox();
            btnSendMessage = new System.Windows.Forms.Button();
            txtBoxMessage = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConnect.Location = new System.Drawing.Point(12, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(100, 30);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // lstBoxLog
            // 
            lstBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lstBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            lstBoxLog.FormattingEnabled = true;
            lstBoxLog.ItemHeight = 15;
            lstBoxLog.Location = new System.Drawing.Point(0, 195);
            lstBoxLog.Name = "lstBoxLog";
            lstBoxLog.Size = new System.Drawing.Size(430, 242);
            lstBoxLog.TabIndex = 1;
            // 
            // btnSendMessage
            // 
            btnSendMessage.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnSendMessage.Enabled = false;
            btnSendMessage.FlatAppearance.BorderSize = 0;
            btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSendMessage.Location = new System.Drawing.Point(118, 12);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new System.Drawing.Size(100, 30);
            btnSendMessage.TabIndex = 0;
            btnSendMessage.Text = "Send Message";
            btnSendMessage.UseVisualStyleBackColor = false;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // txtBoxMessage
            // 
            txtBoxMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBoxMessage.Location = new System.Drawing.Point(12, 63);
            txtBoxMessage.Multiline = true;
            txtBoxMessage.Name = "txtBoxMessage";
            txtBoxMessage.Size = new System.Drawing.Size(406, 126);
            txtBoxMessage.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 45);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 15);
            label1.TabIndex = 3;
            label1.Text = "Message";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(430, 437);
            Controls.Add(label1);
            Controls.Add(txtBoxMessage);
            Controls.Add(lstBoxLog);
            Controls.Add(btnSendMessage);
            Controls.Add(btnConnect);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lstBoxLog;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtBoxMessage;
        private System.Windows.Forms.Label label1;
    }
}