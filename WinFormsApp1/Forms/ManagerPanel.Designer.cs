namespace TwitchBot.Forms
{
    partial class ManagerPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.spamUnit = new System.Windows.Forms.Label();
            this.spamRate = new System.Windows.Forms.Label();
            this.showRelative = new System.Windows.Forms.CheckBox();
            this.chatActivity = new System.Windows.Forms.Label();
            this.chatActivityUnit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chatActivityTotal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastTTS = new System.Windows.Forms.RichTextBox();
            this.lastTTSAuthor = new System.Windows.Forms.Label();
            this.followerChat = new System.Windows.Forms.Label();
            this.chat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(58, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Spam Rate";
            // 
            // spamUnit
            // 
            this.spamUnit.AutoSize = true;
            this.spamUnit.ForeColor = System.Drawing.SystemColors.Control;
            this.spamUnit.Location = new System.Drawing.Point(176, 80);
            this.spamUnit.Name = "spamUnit";
            this.spamUnit.Size = new System.Drawing.Size(34, 15);
            this.spamUnit.TabIndex = 1;
            this.spamUnit.Text = "Units";
            // 
            // spamRate
            // 
            this.spamRate.AutoSize = true;
            this.spamRate.Font = new System.Drawing.Font("Siemens AD Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.spamRate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.spamRate.Location = new System.Drawing.Point(58, 47);
            this.spamRate.Name = "spamRate";
            this.spamRate.Size = new System.Drawing.Size(96, 48);
            this.spamRate.TabIndex = 2;
            this.spamRate.Text = "NaN";
            this.spamRate.Click += new System.EventHandler(this.spamRate_Click);
            // 
            // showRelative
            // 
            this.showRelative.AutoSize = true;
            this.showRelative.ForeColor = System.Drawing.SystemColors.Control;
            this.showRelative.Location = new System.Drawing.Point(170, 100);
            this.showRelative.Name = "showRelative";
            this.showRelative.Size = new System.Drawing.Size(49, 19);
            this.showRelative.TabIndex = 3;
            this.showRelative.Text = "in %";
            this.showRelative.UseVisualStyleBackColor = true;
            // 
            // chatActivity
            // 
            this.chatActivity.AutoSize = true;
            this.chatActivity.Font = new System.Drawing.Font("Siemens AD Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chatActivity.ForeColor = System.Drawing.Color.Lime;
            this.chatActivity.Location = new System.Drawing.Point(261, 51);
            this.chatActivity.Name = "chatActivity";
            this.chatActivity.Size = new System.Drawing.Size(96, 48);
            this.chatActivity.TabIndex = 6;
            this.chatActivity.Text = "NaN";
            this.chatActivity.Click += new System.EventHandler(this.label2_Click);
            // 
            // chatActivityUnit
            // 
            this.chatActivityUnit.AutoSize = true;
            this.chatActivityUnit.ForeColor = System.Drawing.SystemColors.Control;
            this.chatActivityUnit.Location = new System.Drawing.Point(379, 84);
            this.chatActivityUnit.Name = "chatActivityUnit";
            this.chatActivityUnit.Size = new System.Drawing.Size(61, 15);
            this.chatActivityUnit.TabIndex = 5;
            this.chatActivityUnit.Text = "msgs/min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(261, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Current Chat Activity";
            // 
            // chatActivityTotal
            // 
            this.chatActivityTotal.AutoSize = true;
            this.chatActivityTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.chatActivityTotal.Location = new System.Drawing.Point(385, 102);
            this.chatActivityTotal.Name = "chatActivityTotal";
            this.chatActivityTotal.Size = new System.Drawing.Size(51, 19);
            this.chatActivityTotal.TabIndex = 7;
            this.chatActivityTotal.Text = "Total";
            this.chatActivityTotal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(58, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last TTS message";
            // 
            // lastTTS
            // 
            this.lastTTS.BackColor = System.Drawing.SystemColors.InfoText;
            this.lastTTS.Font = new System.Drawing.Font("Siemens AD Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lastTTS.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lastTTS.Location = new System.Drawing.Point(58, 330);
            this.lastTTS.Name = "lastTTS";
            this.lastTTS.Size = new System.Drawing.Size(466, 189);
            this.lastTTS.TabIndex = 10;
            this.lastTTS.Text = "";
            this.lastTTS.TextChanged += new System.EventHandler(this.lastTTS_TextChanged);
            // 
            // lastTTSAuthor
            // 
            this.lastTTSAuthor.AutoSize = true;
            this.lastTTSAuthor.Font = new System.Drawing.Font("Siemens AD Sans", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lastTTSAuthor.ForeColor = System.Drawing.SystemColors.Info;
            this.lastTTSAuthor.Location = new System.Drawing.Point(58, 522);
            this.lastTTSAuthor.Name = "lastTTSAuthor";
            this.lastTTSAuthor.Size = new System.Drawing.Size(61, 29);
            this.lastTTSAuthor.TabIndex = 11;
            this.lastTTSAuthor.Text = "NaN";
            // 
            // followerChat
            // 
            this.followerChat.AutoSize = true;
            this.followerChat.Font = new System.Drawing.Font("Siemens AD Sans", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.followerChat.ForeColor = System.Drawing.Color.Lime;
            this.followerChat.Location = new System.Drawing.Point(58, 164);
            this.followerChat.Name = "followerChat";
            this.followerChat.Size = new System.Drawing.Size(211, 29);
            this.followerChat.TabIndex = 12;
            this.followerChat.Text = "Follower Chat Off";
            this.followerChat.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // chat
            // 
            this.chat.BackColor = System.Drawing.SystemColors.InfoText;
            this.chat.Font = new System.Drawing.Font("Siemens AD Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chat.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.chat.Location = new System.Drawing.Point(545, 12);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(331, 507);
            this.chat.TabIndex = 13;
            this.chat.Text = "";
            this.chat.TextChanged += new System.EventHandler(this.chat_TextChanged);
            // 
            // ManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1283, 618);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.followerChat);
            this.Controls.Add(this.lastTTSAuthor);
            this.Controls.Add(this.lastTTS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chatActivityTotal);
            this.Controls.Add(this.chatActivity);
            this.Controls.Add(this.chatActivityUnit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.showRelative);
            this.Controls.Add(this.spamRate);
            this.Controls.Add(this.spamUnit);
            this.Controls.Add(this.label1);
            this.Name = "ManagerPanel";
            this.Text = "ManagerPanel";
            this.Load += new System.EventHandler(this.ManagerPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label spamUnit;
        private Label spamRate;
        private CheckBox showRelative;
        private Label chatActivity;
        private Label chatActivityUnit;
        private Label label4;
        private CheckBox chatActivityTotal;
        private Label label3;
        private RichTextBox lastTTS;
        private Label lastTTSAuthor;
        private Label followerChat;
        private RichTextBox chat;
    }
}