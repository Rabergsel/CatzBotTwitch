using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Logger
    {
        public static string filename = "generallog.txt";

        public static void log(string s, string action)
        {
            File.AppendAllLines(filename, new string[] { DateTime.Now + " [" + action.ToUpper() + "]\t" + s });
        }

    }
}
