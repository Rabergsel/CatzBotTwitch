namespace WinFormsApp1
{
    public static class Punishment
    {
        public static List<PunishmentRecord> punishments { get; set; }
        public static string[] setPunished = File.ReadAllLines("./settings/punishments.txt");

        public static void load(string path)
        {
            punishments = System.Text.Json.JsonSerializer.Deserialize<List<PunishmentRecord>>(File.ReadAllText(path));
        }

        public static string save()
        {
            return System.Text.Json.JsonSerializer.Serialize(punishments);
        }

        public static int punishUser(string username, string reason, int generalPunishmentSec = 60)
        {
            int punishmentNr = 1;
            bool found = false;
            foreach (var record in punishments)
            {
                if (record.username == username)
                {
                    punishmentNr = record.increasePunishmentCounter(reason);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                punishments.Add(new PunishmentRecord() { username = username });
            }

            foreach (var s in setPunished)
            {
                var _reason = s.Split(';')[0];
                var _numberLow = int.Parse(s.Split(';')[1]);
                var _numberHigh = int.Parse(s.Split(';')[2]);
                var _secs = int.Parse(s.Split(';')[3]);

                if (_reason.ToLower() == reason.ToLower()
                    & _numberLow <= punishmentNr
                    & _numberHigh > punishmentNr)
                {
                    return _secs;
                }

            }

            return generalPunishmentSec;

        }

    }
}
