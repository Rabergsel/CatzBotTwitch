using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Settings
    {
        public static Bot bot;

        public static string channel_name = File.ReadAllText("./settings/channel.txt");
        public static string token = File.ReadAllText("./settings/token.txt");
        public static string APIclientID = File.ReadAllLines("./settings/APIAuth.txt")[0];
        public static string APIsecret = File.ReadAllLines("./settings/APIAuth.txt")[1];

        public static bool tts = true;
        public static bool chatfilter = true;

        public static RateCounter W_counter = new RateCounter();
        public static RateCounter L_counter = new RateCounter();
        public static RateCounter GG_counter = new RateCounter();


        public static async Task RunInBackground(TimeSpan timeSpan, Action action)
        {
            var periodicTimer = new PeriodicTimer(timeSpan);
            while (await periodicTimer.WaitForNextTickAsync())
            {
                action();
            }
        }

    }
}
