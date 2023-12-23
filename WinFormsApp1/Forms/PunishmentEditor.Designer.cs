namespace TwitchBot.Forms
{
    partial class PunishmentEditor
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
            this.Back = new System.Windows.Forms.Button();
            this.Further = new System.Windows.Forms.Button();
            this.minPunishments = new System.Windows.Forms.NumericUpDown();
            this.min = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxPunishments = new System.Windows.Forms.NumericUpDown();
            this.toMin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Ban = new System.Windows.Forms.CheckBox();
            this.reason = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.beautyTime = new System.Windows.Forms.Label();
            this.createNew = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.minPunishments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPunishments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toMin)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 248);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(68, 39);
            this.Back.TabIndex = 1;
            this.Back.Text = "<<";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Further
            // 
            this.Further.Location = new System.Drawing.Point(170, 248);
            this.Further.Name = "Further";
            this.Further.Size = new System.Drawing.Size(68, 39);
            this.Further.TabIndex = 2;
            this.Further.Text = ">>";
            this.Further.UseVisualStyleBackColor = true;
            this.Further.Click += new System.EventHandler(this.Further_Click);
            // 
            // minPunishments
            // 
            this.minPunishments.Location = new System.Drawing.Point(182, 61);
            this.minPunishments.Name = "minPunishments";
            this.minPunishments.Size = new System.Drawing.Size(55, 23);
            this.minPunishments.TabIndex = 4;
            // 
            // min
            // 
            this.min.AutoSize = true;
            this.min.Location = new System.Drawing.Point(12, 63);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(138, 15);
            this.min.TabIndex = 5;
            this.min.Text = "Minimum Punishments: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Maximum Punishments";
            // 
            // maxPunishments
            // 
            this.maxPunishments.Location = new System.Drawing.Point(182, 104);
            this.maxPunishments.Name = "maxPunishments";
            this.maxPunishments.Size = new System.Drawing.Size(55, 23);
            this.maxPunishments.TabIndex = 7;
            // 
            // toMin
            // 
            this.toMin.Location = new System.Drawing.Point(117, 152);
            this.toMin.Name = "toMin";
            this.toMin.Size = new System.Drawing.Size(120, 23);
            this.toMin.TabIndex = 8;
            this.toMin.ValueChanged += new System.EventHandler(this.toMin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Timout Seconds";
            // 
            // Ban
            // 
            this.Ban.AutoSize = true;
            this.Ban.Location = new System.Drawing.Point(13, 174);
            this.Ban.Name = "Ban";
            this.Ban.Size = new System.Drawing.Size(72, 19);
            this.Ban.TabIndex = 10;
            this.Ban.Text = "Ban User";
            this.Ban.UseVisualStyleBackColor = true;
            this.Ban.CheckedChanged += new System.EventHandler(this.Ban_CheckedChanged);
            // 
            // reason
            // 
            this.reason.FormattingEnabled = true;
            this.reason.Items.AddRange(new object[] {
            "BADWORD",
            "DISGUISEDBADWORD"});
            this.reason.Location = new System.Drawing.Point(12, 12);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(226, 23);
            this.reason.TabIndex = 11;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(86, 248);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(78, 39);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // delete
            // 
            this.delete.ForeColor = System.Drawing.Color.Red;
            this.delete.Location = new System.Drawing.Point(13, 287);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(225, 26);
            this.delete.TabIndex = 13;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // beautyTime
            // 
            this.beautyTime.AutoSize = true;
            this.beautyTime.Location = new System.Drawing.Point(117, 178);
            this.beautyTime.Name = "beautyTime";
            this.beautyTime.Size = new System.Drawing.Size(63, 15);
            this.beautyTime.TabIndex = 14;
            this.beautyTime.Text = " = 00:00:00";
            // 
            // createNew
            // 
            this.createNew.AutoSize = true;
            this.createNew.Location = new System.Drawing.Point(13, 223);
            this.createNew.Name = "createNew";
            this.createNew.Size = new System.Drawing.Size(160, 19);
            this.createNew.TabIndex = 15;
            this.createNew.Text = "Save As New Punishment";
            this.createNew.UseVisualStyleBackColor = true;
            this.createNew.CheckedChanged += new System.EventHandler(this.createNew_CheckedChanged);
            // 
            // PunishmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 316);
            this.Controls.Add(this.createNew);
            this.Controls.Add(this.beautyTime);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.Ban);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toMin);
            this.Controls.Add(this.maxPunishments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.min);
            this.Controls.Add(this.minPunishments);
            this.Controls.Add(this.Further);
            this.Controls.Add(this.Back);
            this.Name = "PunishmentEditor";
            this.Text = "PunishmentEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PunishmentEditor_FormClosing);
            this.Load += new System.EventHandler(this.PunishmentEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minPunishments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPunishments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button Back;
        private Button Further;
        private NumericUpDown minPunishments;
        private Label min;
        private Label label2;
        private NumericUpDown maxPunishments;
        private NumericUpDown toMin;
        private Label label3;
        private CheckBox Ban;
        private ComboBox reason;
        private Button okButton;
        private Button delete;
        private Label beautyTime;
        private CheckBox createNew;
    }
}