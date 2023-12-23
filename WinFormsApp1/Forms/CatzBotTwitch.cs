namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "Connected to: " + Settings.model.channel_name;
            ttsActivated.Checked = Settings.model.tts;
            checkBox1.Checked = Settings.model.chatfilter;
        }

        private void ttsActivated_CheckedChanged(object sender, EventArgs e)
        {
            Settings.model.tts = ttsActivated.Checked;
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var csform = new ConnectionSettings();
            csform.ShowDialog();
        }

        private void spamToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.model.chatfilter = checkBox1.Checked;
            Logger.log("Toggled chatfilter to: " + checkBox1.Checked, "SETTINGS");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.model.useDisguisedBadwordDetector = checkBox2.Checked;
            Logger.log("Toggled disguised chatfilter to: " + checkBox1.Checked, "SETTINGS");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Settings.model.LevenshteinDistanceThreshold = trackBar1.Value;
            textBox1.Text = trackBar1.Value.ToString();
            Logger.log("Toggled Levenshtein threshold to: " + trackBar1.Value, "SETTINGS");
        }

        private void punishmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwitchBot.Forms.PunishmentEditor editor = new TwitchBot.Forms.PunishmentEditor();
            editor.ShowDialog();

        }
    }
}