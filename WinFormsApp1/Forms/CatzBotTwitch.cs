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
            checkBox2.Checked = Settings.model.useDisguisedBadwordDetector;

            levenshteinSetter.Value = Settings.model.LevenshteinDistanceThreshold;
            LevenshteinDisplay.Text = Settings.model.LevenshteinDistanceThreshold.ToString();

            levenshteinSetter.Enabled = checkBox2.Checked;
            LevenshteinDisplay.Enabled = checkBox2.Checked;
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

            levenshteinSetter.Enabled = checkBox2.Checked;
            LevenshteinDisplay.Enabled = checkBox2.Checked;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Settings.model.LevenshteinDistanceThreshold = levenshteinSetter.Value;
            LevenshteinDisplay.Text = levenshteinSetter.Value.ToString();
            Logger.log("Toggled Levenshtein threshold to: " + levenshteinSetter.Value, "SETTINGS");
        }

        private void punishmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwitchBot.Forms.PunishmentEditor editor = new TwitchBot.Forms.PunishmentEditor();
            editor.ShowDialog();

        }

        private void linkCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           TwitchBot.Forms.CommandLinkEditor editor = new TwitchBot.Forms.CommandLinkEditor();
            editor.ShowDialog();
        }

        private void badWordEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwitchBot.Forms.BadWordEditor editor = new TwitchBot.Forms.BadWordEditor();
            editor.ShowDialog();
        }

        private void moderationActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwitchBot.Forms.ModActionMenu menu = new TwitchBot.Forms.ModActionMenu();
            menu.ShowDialog();
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsmenu = new TwitchBot.Forms.DiscordSettings();
            settingsmenu.ShowDialog();
        }
    }
}