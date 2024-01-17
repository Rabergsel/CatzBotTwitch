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

            textBox3.Text = Settings.model.APIclientID;
            textBox3.UseSystemPasswordChar = false;

            textBox4.Text = Settings.model.APIsecret;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            Settings.model.channel_name = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            Settings.model.token = textBox2.Text;
        }

        private void ConnectionSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.model.bot = new Bot();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://twitchapps.com/tmi/",
                UseShellExecute = true
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://twitchtokengenerator.com",
                UseShellExecute = true
            });
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Settings.model.APIclientID = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Settings.model.APIsecret = textBox4.Text;
        }
    }
}
