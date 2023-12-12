namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Settings.generateFileStructure();
                try
                {
                    Punishment.load("./files/punishedUsers.txt");
                }
                catch
                {
                    Punishment.punishments = new List<PunishmentRecord>();
                    File.WriteAllText("./files/punishedUsers.txt", Punishment.save());
                }
                Logger.filename = "./logs/" + DateTime.Now.ToString().Replace(' ', '_').Replace(".", "").Replace(":", "") + "_LOG.txt";
                Logger.log("Started bot!", "SYSTEM");
                try
                {
                    Settings.load();
                }
                catch
                {
                    Settings.model = new SettingsModel();
                    Settings.save();
                }

                Settings.model.bot = new Bot();
                Settings.RunInBackground(TimeSpan.FromSeconds(3), () => outputCounter());
                Settings.RunInBackground(TimeSpan.FromSeconds(120), () => savePunishments());
                Settings.RunInBackground(TimeSpan.FromSeconds(30), () => saveSettings());
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                Logger.log("ERROR: " + ex, "CRASH");
                MessageBox.Show("It seems like an error occured:\n" + ex + "\n\nPlease report this error with your logfile to the developers. They may help you!");
            }
        }




        public static void outputCounter()
        {
            File.WriteAllText("./counter/L_counter.txt", Settings.model.L_counter.occurencesInTimeSpan(60).ToString());
            File.WriteAllText("./counter/W_counter.txt", Settings.model.W_counter.occurencesInTimeSpan(60).ToString());
            File.WriteAllText("./counter/GG_counter.txt", Settings.model.GG_counter.occurencesInTimeSpan(60).ToString());
            //File.WriteAllText("massstats.txt", Settings.bot.massStats());
            System.Diagnostics.Debug.WriteLine("Output");
            
        }
        public static void savePunishments()
        {
            string text = Punishment.save();
            File.WriteAllText("./files/punishedUsers.txt", text);
            Logger.log("Saved all punishments ( =" + text.Length + " bytes)", "SYSTEM");
        }

        public static void saveSettings()
        {
            Settings.save();
        }
        

    }
}