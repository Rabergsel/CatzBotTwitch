using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TwitchBot;

namespace TwitchBot.Forms
{
    public partial class PunishmentEditor : Form
    {

        int line = 0;

        public PunishmentEditor()
        {
            InitializeComponent();
        }

        private void Ban_CheckedChanged(object sender, EventArgs e)
        {
            toMin.Enabled = !Ban.Checked;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(createNew.Checked)
            {
                File.AppendAllLines("./settings/punishments.txt", new string[] { createString() });
            }
            else
            {
                var lines = File.ReadAllLines("./settings/punishments.txt");
                List<string> newLines = new List<string>(lines);
                newLines[line] = createString();

                File.WriteAllLines("./settings/punishments.txt", newLines.ToArray());
            }
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("./settings/punishments.txt");
            List<string> newLines = new List<string>(lines);
            newLines.RemoveAt(line);

            File.WriteAllLines("./settings/punishments.txt", newLines.ToArray());

        }

        private void showLine()
        {
            try
            {
                var s = File.ReadAllLines("./settings/punishments.txt")[line];
                var _reason = s.Split(';')[0];
                var _numberLow = int.Parse(s.Split(';')[1]);
                var _numberHigh = int.Parse(s.Split(';')[2]);
                var _secs = int.Parse(s.Split(';')[3]);

                reason.Text = _reason;
                minPunishments.Value = _numberLow;
                maxPunishments.Value = _numberHigh;
                toMin.Value = _secs;
            }
            catch
            {
                MessageBox.Show("End of File reached. To save this punishment, make sure that the \"Override\" check box is not clicked!");
            }
        }

        private string createString()
        {
            if (Ban.Checked) toMin.Value = -1;
            return $"{reason.Text};{minPunishments.Value};{maxPunishments.Value};{toMin.Value}";
        }

        private void toMin_ValueChanged(object sender, EventArgs e)
        {
            beautyTime.Text = "= " + TimeSpan.FromSeconds((double)toMin.Value).ToString();
        }

        private void Further_Click(object sender, EventArgs e)
        {
            line++;
            showLine();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            line--;
            line = Math.Max(0, line);
            showLine();
        }

        private void createNew_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PunishmentEditor_Load(object sender, EventArgs e)
        {
            showLine();
        }

        private void PunishmentEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            WinFormsApp1.Punishment.setPunished = File.ReadAllLines("./settings/punishments.txt");
        }
    }
}
