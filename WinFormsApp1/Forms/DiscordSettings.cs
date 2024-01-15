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
    public partial class DiscordSettings : Form
    {
        public DiscordSettings()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            WinFormsApp1.Settings.model.DiscordToken = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DC.StartDCBot.StartDCBotAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }

        private void DiscordSettings_Load(object sender, EventArgs e)
        {
            textBox1.Text = WinFormsApp1.Settings.model.DiscordToken;
        }
    }
}
