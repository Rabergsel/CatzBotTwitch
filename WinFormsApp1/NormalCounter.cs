using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot
{
    public class NormalCounter
    {
        public string word = "GoatEmotey";
        public int counter = 0;

        public void analyze(string msg)
        {
            if(msg.Contains(word))
            {
                counter += msg.Split(word).Length - 1;
            }
        }
    }
}
