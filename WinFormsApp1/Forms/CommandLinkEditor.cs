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
    public partial class CommandLinkEditor : Form
    {
        public CommandLinkEditor()
        {
            InitializeComponent();
        }

        private void CommandLinkEditor_Load(object sender, EventArgs e)
        {
            prefix.Text = WinFormsApp1.Settings.model.commandPrefix;
            updatePreviews(prefix.Text);

            textBox1.Text = WinFormsApp1.Settings.model.dcLink;
            textBox2.Text = WinFormsApp1.Settings.model.ytLink;
        }

        private void updatePreviews(string prefix)
        {
            dcPreview.Text = $"Discord: {prefix}dc {prefix}discord";
            ytPreview.Text = $"YouTube: {prefix}yt {prefix}youtube";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            WinFormsApp1.Settings.model.dcLink = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            WinFormsApp1.Settings.model.ytLink = textBox2.Text;
        }

        private void prefix_TextChanged(object sender, EventArgs e)
        {
            WinFormsApp1.Settings.model.commandPrefix = prefix.Text;
            updatePreviews(prefix.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
