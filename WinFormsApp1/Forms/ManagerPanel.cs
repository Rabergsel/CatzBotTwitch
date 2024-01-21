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
            spamIndicator.Minimum = WinFormsApp1.Settings.model.FollowerChatOffSpamValue;
            spamIndicator.Maximum = WinFormsApp1.Settings.model.FollowerChatOnSpamValue;

            if (showRelative.Checked)
            {
                spamUnit.Text = "%";
                var rate = (Math.Round(Convert.ToSingle(WinFormsApp1.Settings.model.spamCounter.occurencesInTimeSpan(60)) / Convert.ToSingle(WinFormsApp1.Settings.model.msgCounter.occurencesInTimeSpan(60)), 4) * 100);
                spamRate.Text = rate.ToString();
                spamIndicator.Value = Math.Min(Math.Max((int)rate, spamIndicator.Minimum), spamIndicator.Maximum);
                if (rate < spamIndicator.Minimum) spamIndicator.BackColor = Color.DarkGreen;
                else if (rate > spamIndicator.Maximum) spamIndicator.BackColor = Color.DarkRed;
                else spamIndicator.BackColor = Color.Yellow;
            }
            else
            {
                spamUnit.Text = "msg/min";
                var rate = WinFormsApp1.Settings.model.spamCounter.occurencesInTimeSpan(60);
                spamRate.Text = rate.ToString();
                spamIndicator.Value = Math.Min(Math.Max((int)rate, spamIndicator.Minimum), spamIndicator.Maximum);
                if (rate < spamIndicator.Minimum) spamIndicator.BackColor = Color.DarkGreen;
                else if (rate > spamIndicator.Maximum) spamIndicator.BackColor = Color.DarkRed;
                else spamIndicator.BackColor = Color.Yellow;
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


            if (WinFormsApp1.Settings.model.tts) { }
            else { lastTTS.BackColor = Color.DarkRed; lastTTS.Text = "Deactivated TTS"; }

        }

        private void spamRate_Click(object sender, EventArgs e)
        {
            ModActionMenu menu = new ModActionMenu();
            menu.ShowDialog();
           
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

        private void button1_Click(object sender, EventArgs e)
        {
            WinFormsApp1.Settings.model.tts = !WinFormsApp1.Settings.model.tts;

            if (WinFormsApp1.Settings.model.tts) { lastTTS.BackColor = Color.Black; }
            else if (WinFormsApp1.Settings.model.tts_OnlyMod) { lastTTS.BackColor = Color.DarkBlue; }
            else { lastTTS.BackColor = Color.DarkRed; }
        }

    }
}
