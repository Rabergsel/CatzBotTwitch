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
    public partial class ModActionMenu : Form
    {
        public ModActionMenu()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if   (checkBox1.Checked) label2.Text = "% of messages";
            else label2.Text = "messages per minute";
            label4.Text = label2.Text;

            WinFormsApp1.Settings.model.FollowerChatRelative = checkBox1.Checked;

        }

        private void followChatOnWhen_ValueChanged(object sender, EventArgs e)
        {
            WinFormsApp1.Settings.model.FollowerChatOnSpamValue = (int)followChatOnWhen.Value;
        }

        private void followChatOffWhen_ValueChanged(object sender, EventArgs e)
        {
            WinFormsApp1.Settings.model.FollowerChatOffSpamValue = (int)followChatOffWhen.Value;
        }

        private void ModActionMenu_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = WinFormsApp1.Settings.model.FollowerChatRelative;
            followChatOnWhen.Value = WinFormsApp1.Settings.model.FollowerChatOnSpamValue;
            followChatOffWhen.Value = WinFormsApp1.Settings.model.FollowerChatOffSpamValue;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
