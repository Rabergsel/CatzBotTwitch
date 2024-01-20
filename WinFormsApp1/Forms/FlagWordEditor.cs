using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchBot.Forms
{
    public partial class FlagWordEditor : Form
    {
        public FlagWordEditor()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("./settings/flagwords.txt", richTextBox1.Text);
        }

        private void FlagWordEditor_Load(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = File.ReadAllText("./settings/flagwords.txt");
            }
            catch
            {
                File.WriteAllText("./settings/flagwords.txt", "");
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            WinFormsApp1.ChatFilter.flagwords = File.ReadAllLines("./settings/flagwords.txt");
            this.Close();
        }
    }
}
