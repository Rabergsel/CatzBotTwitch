namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectionLabel = new System.Windows.Forms.Label();
            this.ttsActivated = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moderationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punishmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.badWordEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moderationActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.levenshteinSetter = new System.Windows.Forms.TrackBar();
            this.LevenshteinDisplay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flagWordEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levenshteinSetter)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionLabel.Location = new System.Drawing.Point(12, 41);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(166, 30);
            this.connectionLabel.TabIndex = 0;
            this.connectionLabel.Text = "Not connected...";
            // 
            // ttsActivated
            // 
            this.ttsActivated.AutoSize = true;
            this.ttsActivated.Location = new System.Drawing.Point(12, 74);
            this.ttsActivated.Name = "ttsActivated";
            this.ttsActivated.Size = new System.Drawing.Size(121, 19);
            this.ttsActivated.TabIndex = 1;
            this.ttsActivated.Text = "TTS (for everyone)";
            this.ttsActivated.UseVisualStyleBackColor = true;
            this.ttsActivated.CheckedChanged += new System.EventHandler(this.ttsActivated_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.moderationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(299, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.linkCommandsToolStripMenuItem,
            this.discordToolStripMenuItem,
            this.settingsToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // linkCommandsToolStripMenuItem
            // 
            this.linkCommandsToolStripMenuItem.Name = "linkCommandsToolStripMenuItem";
            this.linkCommandsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.linkCommandsToolStripMenuItem.Text = "Link Commands";
            this.linkCommandsToolStripMenuItem.Click += new System.EventHandler(this.linkCommandsToolStripMenuItem_Click);
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBackupToolStripMenuItem});
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            // 
            // createBackupToolStripMenuItem
            // 
            this.createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            this.createBackupToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.createBackupToolStripMenuItem.Text = "Create Backup";
            this.createBackupToolStripMenuItem.Click += new System.EventHandler(this.createBackupToolStripMenuItem_Click);
            // 
            // moderationToolStripMenuItem
            // 
            this.moderationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.punishmentsToolStripMenuItem,
            this.badWordEditorToolStripMenuItem,
            this.flagWordEditorToolStripMenuItem,
            this.moderationActionToolStripMenuItem});
            this.moderationToolStripMenuItem.Name = "moderationToolStripMenuItem";
            this.moderationToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.moderationToolStripMenuItem.Text = "Moderation";
            // 
            // punishmentsToolStripMenuItem
            // 
            this.punishmentsToolStripMenuItem.Name = "punishmentsToolStripMenuItem";
            this.punishmentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.punishmentsToolStripMenuItem.Text = "Punishments";
            this.punishmentsToolStripMenuItem.Click += new System.EventHandler(this.punishmentsToolStripMenuItem_Click);
            // 
            // badWordEditorToolStripMenuItem
            // 
            this.badWordEditorToolStripMenuItem.Name = "badWordEditorToolStripMenuItem";
            this.badWordEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.badWordEditorToolStripMenuItem.Text = "Bad Word Editor";
            this.badWordEditorToolStripMenuItem.Click += new System.EventHandler(this.badWordEditorToolStripMenuItem_Click);
            // 
            // moderationActionToolStripMenuItem
            // 
            this.moderationActionToolStripMenuItem.Name = "moderationActionToolStripMenuItem";
            this.moderationActionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.moderationActionToolStripMenuItem.Text = "Moderation Action";
            this.moderationActionToolStripMenuItem.Click += new System.EventHandler(this.moderationActionToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 99);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Chatfilter";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 124);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(131, 19);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Advanced Chatfilter";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // levenshteinSetter
            // 
            this.levenshteinSetter.LargeChange = 3;
            this.levenshteinSetter.Location = new System.Drawing.Point(68, 149);
            this.levenshteinSetter.Maximum = 20;
            this.levenshteinSetter.Name = "levenshteinSetter";
            this.levenshteinSetter.Size = new System.Drawing.Size(219, 45);
            this.levenshteinSetter.TabIndex = 5;
            this.levenshteinSetter.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // LevenshteinDisplay
            // 
            this.LevenshteinDisplay.Location = new System.Drawing.Point(12, 149);
            this.LevenshteinDisplay.Name = "LevenshteinDisplay";
            this.LevenshteinDisplay.Size = new System.Drawing.Size(50, 23);
            this.LevenshteinDisplay.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Levenshtein distance (lower = more similiar)";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(299, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // flagWordEditorToolStripMenuItem
            // 
            this.flagWordEditorToolStripMenuItem.Name = "flagWordEditorToolStripMenuItem";
            this.flagWordEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.flagWordEditorToolStripMenuItem.Text = "Flag Word Editor";
            this.flagWordEditorToolStripMenuItem.Click += new System.EventHandler(this.flagWordEditorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(299, 420);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LevenshteinDisplay);
            this.Controls.Add(this.levenshteinSetter);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ttsActivated);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CatzBot Twitch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levenshteinSetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label connectionLabel;
        private CheckBox ttsActivated;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem connectionToolStripMenuItem;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TrackBar levenshteinSetter;
        private TextBox LevenshteinDisplay;
        private Label label1;
        private ToolStripMenuItem moderationToolStripMenuItem;
        private ToolStripMenuItem punishmentsToolStripMenuItem;
        private ToolStripMenuItem linkCommandsToolStripMenuItem;
        private ToolStripMenuItem badWordEditorToolStripMenuItem;
        private ToolStripMenuItem moderationActionToolStripMenuItem;
        private ToolStripMenuItem discordToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem1;
        private ToolStripMenuItem createBackupToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem flagWordEditorToolStripMenuItem;
    }
}