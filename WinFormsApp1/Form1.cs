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
            connectionLabel.Text = "Connected to: " + Settings.channel_name;
            ttsActivated.Checked = Settings.tts;
        }

        private void ttsActivated_CheckedChanged(object sender, EventArgs e)
        {
            Settings.tts = ttsActivated.Checked;
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
            Settings.chatfilter = checkBox1.Checked;
        }
    }
}