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
            if (File.Exists("setup.ok"))
            {
                return;
            }

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
        public string APIsecret { get; set; }

        public string APIaccess { get; set; }

        public bool tts { get; set; }
        public bool chatfilter { get; set; }
        public bool botIsBroadcaster { get; set; }
        public string broadcasterID { get; set; }
        public bool excludeModerators { get; set; }

        public string dcLink { get; set; }
        public string ytLink { get; set; }

        public bool useDisguisedBadwordDetector { get; set; }
        public int LevenshteinDistanceThreshold { get; set; }

        public bool FollowerChatRelative { get; set; }
        public int FollowerChatOnSpamValue { get; set; }
        public int FollowerChatOffSpamValue { get; set; }

        public string commandPrefix { get; set; }

        public string DiscordToken { get; set; }

        public bool isFollowerOnlyChatOn { get; set; }

        public ulong DCChannel { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter W_counter = new RateCounter();
        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter L_counter = new RateCounter();
        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter GG_counter = new RateCounter();

        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter spamCounter = new RateCounter();

        [System.Text.Json.Serialization.JsonIgnore]
        public RateCounter msgCounter = new RateCounter();


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

            dcLink = "";
            ytLink = "";

            commandPrefix = "!";

            useDisguisedBadwordDetector = true;
            LevenshteinDistanceThreshold = 1;


            FollowerChatOffSpamValue = 10;
            FollowerChatOnSpamValue = 20;
            FollowerChatRelative = true;

            isFollowerOnlyChatOn = false;
            DiscordToken = "";

            DCChannel = 0;
        }



    }
}
