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
    public partial class BadWordEditor : Form
    {
        public BadWordEditor()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("./settings/badwords.txt", richTextBox1.Text);
        }

        private void BadWordEditor_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText("./settings/badwords.txt");
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TwitchBot.Forms.BadWordImporter importer = new BadWordImporter();
            importer.ShowDialog();
            richTextBox1.Text = File.ReadAllText("./settings/badwords.txt");
        }
    }
}
