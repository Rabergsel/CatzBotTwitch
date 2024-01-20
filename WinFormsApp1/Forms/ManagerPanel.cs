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
    public partial class ManagerPanel : Form
    {
        public ManagerPanel()
        {
            InitializeComponent();
        }

        private void updateStats()
        {

        }

        private void ManagerPanel_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (250); // 10 secs
            timer.Tick += new EventHandler(updateStats);
            timer.Start();
        }

        private void updateStats(object sender, EventArgs e)
        {
            if (showRelative.Checked)
            {
                spamUnit.Text = "%";
                spamRate.Text = (Math.Round(Convert.ToSingle(WinFormsApp1.Settings.model.spamCounter.occurencesInTimeSpan(60)) / Convert.ToSingle(WinFormsApp1.Settings.model.msgCounter.occurencesInTimeSpan(60)), 4) *100).ToString();
            }
            else
            {
                spamUnit.Text = "msg/min";
                spamRate.Text = WinFormsApp1.Settings.model.spamCounter.occurencesInTimeSpan(60).ToString();
            }

            if(chatActivityTotal.Checked)
            {
                chatActivityUnit.Text = "msgs";
                chatActivity.Text = WinFormsApp1.Settings.model.msgCounter.occurencesInTimeSpan(int.MaxValue).ToString();
            }
            else
            {
                chatActivityUnit.Text = "msgs/min";
                chatActivity.Text = WinFormsApp1.Settings.model.msgCounter.occurencesInTimeSpan(60).ToString();
            }

            lastTTS.Text = WinFormsApp1.Settings.lastTTSmessage;
            lastTTSAuthor.Text = WinFormsApp1.Settings.lastTTSauthor;

            if (WinFormsApp1.Settings.model.isFollowerOnlyChatOn) { followerChat.Text = "Follower Chat On"; followerChat.ForeColor = Color.Red; }
            else { followerChat.Text = "Follower Chat Off"; followerChat.ForeColor = Color.Lime; }

            chat.Text = WinFormsApp1.Settings.getChatMsgs;
        }

        private void spamRate_Click(object sender, EventArgs e)
        {

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lastTTS_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
