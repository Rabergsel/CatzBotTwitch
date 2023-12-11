using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ConnectionSettings : Form
    {
        public ConnectionSettings()
        {
            InitializeComponent();
        }

        private void ConnectionSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.model.channel_name;
            textBox2.Text = Settings.model.token;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("channel.txt", textBox1.Text);
            Settings.model.channel_name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText("token.txt", textBox2.Text);
            Settings.model.token = textBox2.Text;
        }

        private void ConnectionSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.model.bot = new Bot();
        }
    }
}
