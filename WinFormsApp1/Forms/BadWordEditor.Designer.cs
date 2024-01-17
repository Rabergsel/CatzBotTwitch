namespace TwitchBot.Forms
{
    partial class BadWordEditor
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.OK = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 282);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(12, 331);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(260, 34);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(12, 3);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(260, 34);
            this.import.TabIndex = 3;
            this.import.Text = "Import Files";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.button1_Click);
            // 
            // BadWordEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 373);
            this.Controls.Add(this.import);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.richTextBox1);
            this.Name = "BadWordEditor";
            this.Text = "Bad Word List Editor";
            this.Load += new System.EventHandler(this.BadWordEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox richTextBox1;
        private Button OK;
        private Button import;
    }
}