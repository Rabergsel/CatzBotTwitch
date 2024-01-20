namespace TwitchBot.Forms
{
    partial class ModActionMenu
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
            this.followChatOnWhen = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.followChatOffWhen = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.followChatOnWhen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followChatOffWhen)).BeginInit();
            this.SuspendLayout();
            // 
            // followChatOnWhen
            // 
            this.followChatOnWhen.Location = new System.Drawing.Point(12, 61);
            this.followChatOnWhen.Name = "followChatOnWhen";
            this.followChatOnWhen.Size = new System.Drawing.Size(104, 23);
            this.followChatOnWhen.TabIndex = 5;
            this.followChatOnWhen.ValueChanged += new System.EventHandler(this.followChatOnWhen_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(159, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 19);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Calculate as relative";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Turn Follower Chat On when more than";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "are spam, and deactivate when less than";
            // 
            // followChatOffWhen
            // 
            this.followChatOffWhen.Location = new System.Drawing.Point(12, 105);
            this.followChatOffWhen.Name = "followChatOffWhen";
            this.followChatOffWhen.Size = new System.Drawing.Size(104, 23);
            this.followChatOffWhen.TabIndex = 10;
            this.followChatOffWhen.ValueChanged += new System.EventHandler(this.followChatOffWhen_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "are spam";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(12, 149);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(369, 31);
            this.OK.TabIndex = 13;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // ModActionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 185);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.followChatOffWhen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.followChatOnWhen);
            this.Name = "ModActionMenu";
            this.Text = "ModActionMenu";
            this.Load += new System.EventHandler(this.ModActionMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.followChatOnWhen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followChatOffWhen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown followChatOnWhen;
        private CheckBox checkBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown followChatOffWhen;
        private Label label4;
        private Label label5;
        private Button OK;
    }
}