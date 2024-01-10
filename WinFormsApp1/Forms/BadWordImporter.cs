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
    public partial class BadWordImporter : Form
    {
        public BadWordImporter()
        {
            InitializeComponent();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            if(fileDialog.FileName != "")
            {
                textBox1.Text = fileDialog.FileName;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            bool merge = comboBox1.Text == "Merge";
            string[] newwords = new string[1];
            try
            {
                newwords = File.ReadAllLines(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (merge)
            {
                var badwords = File.ReadAllLines("./settings/badwords.txt").ToList<string>();
                
                
                foreach(var n in badwords)
                {
                    if(!badwords.Contains(n)) badwords.Add(n);
                }

                File.WriteAllLines("./settings/badwords.txt", badwords);
                WinFormsApp1.ChatFilter.reloadBadwords();
                return;
            }
            else
            {
                File.AppendAllLines("./settings/badwords.txt", newwords);
                WinFormsApp1.ChatFilter.reloadBadwords();
                return;
            }

        }
    }
}
