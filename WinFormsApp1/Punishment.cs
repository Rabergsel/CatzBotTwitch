using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class Punishment
    {
        public static List<Tuple<string, string, int>> punishments {get; set;}
        public static string[] setPunished = File.ReadAllLines("./settings/punishments.txt");

        public static void load()
        {
            try
            {
                punishments = System.Text.Json.JsonSerializer.Deserialize<List<Tuple<string, string, int>>>(File.ReadAllText("./settings/punishedUsers.txt"));
            }
            catch (Exception ex)
            {
                punishments = new List<Tuple<string, string, int>>();
            }
        }

        public static string save()
        {
            return System.Text.Json.JsonSerializer.Serialize(punishments);
        }

        public static int punishUser(string username, string reason)
        {
            for(int i = 0; i < punishments.Count; i++)
            {
                var p = punishments[i];

                if(punishments[i].Item1 == username & punishments[i].Item2 == reason)
                {
                    punishments[i] = new Tuple<string, string, int>(username, reason, punishments[i].Item3+1);
                    foreach(var s in setPunished)
                    {
                        if(s.StartsWith(reason + ";" + punishments[i].Item3))
                        {
                            string secs = s.Split(';')[2];
                            Logger.log("Punishing " + username + " due to " + reason + " x" + punishments[i].Item3 + " --> " + secs, "PUNISH");

                            if (secs == "ban") return -1;
                            return Convert.ToInt32(secs);
                        }
                    }

                    foreach (var s in setPunished)
                    {
                        if (s.StartsWith(reason + ";x;"))
                        {
                            return Convert.ToInt32(s.Split(';')[2]);
                        }
                    }
                }

            }
            return 0;

        }

    }
}
