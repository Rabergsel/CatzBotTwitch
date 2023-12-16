using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{

    public class Settings
    {
        public static SettingsModel model { get; set; }

        public static void save()
        {
            File.WriteAllText("./settings/settings.json", System.Text.Json.JsonSerializer.Serialize(model, typeof(SettingsModel), new System.Text.Json.JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }

        public static void load()
        {
            model = System.Text.Json.JsonSerializer.Deserialize<SettingsModel>(File.ReadAllText("./settings/settings.json"));
        }

        public static async Task RunInBackground(TimeSpan timeSpan, Action action)
        {
            var periodicTimer = new PeriodicTimer(timeSpan);
            while (await periodicTimer.WaitForNextTickAsync())
            {
                action();
            }
        }

        public static void generateFileStructure()
        {
            if (File.Exists("setup.ok")) return;
            Directory.CreateDirectory("./files");
            Directory.CreateDirectory("./logs");
            Directory.CreateDirectory("./settings");
            Directory.CreateDirectory("./counter");
            File.WriteAllText("./settings/settings.json", System.Text.Json.JsonSerializer.Serialize(new SettingsModel(), typeof(SettingsModel), new System.Text.Json.JsonSerializerOptions()
            {
                WriteIndented = true
            }));
            File.WriteAllText("./settings/punishments.txt", "REASON;minCount;maxCount;secsTimeout (-1=ban)");
            File.WriteAllText("./settings/badwords.txt", "Write each badword into a line.");
            File.Create("setup.ok");
        }

    }

    public class SettingsModel
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Bot bot;

        public string channel_name { get; set; }
        public string token { get; set; }
        public string APIclientID { get; set; }
        public string APIsecret {get; set; }

        public string APIaccess { get; set; }

        public bool tts {get; set; }
        public bool chatfilter {get; set; }
        public bool botIsBroadcaster {get; set; }
        public string broadcasterID { get; set; }
        public bool excludeModerators { get; set; }

        public bool useDisguisedBadwordDetector { get; set; }
        public int LevenshteinDistanceThreshold { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter W_counter = new RateCounter();
        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter L_counter = new RateCounter();
        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter GG_counter = new RateCounter();


        public SettingsModel()
        {
            channel_name = "channel name";
            token = "token";
            APIclientID = "Client ID for API";
            APIsecret = "API secret for client";
            tts = false;
            chatfilter = true;
            botIsBroadcaster = true;
            broadcasterID = "broadcaster ID (numerical value assigned by twitch)";
            excludeModerators = true;

            useDisguisedBadwordDetector = true;
            LevenshteinDistanceThreshold = 1;
        }



    }
}
