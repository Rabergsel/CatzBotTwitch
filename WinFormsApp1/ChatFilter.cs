using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class ChatFilter
    {
        public static string[] badwords = File.ReadAllLines("./settings/badwords.txt");

            
            public static bool containsBadWord(string msg)
            {

                foreach(var s in badwords)
                {
                    if (msg.ToLower().Contains(s.ToLower())) return true;
                }
                return false;
            }

        

    }
}
