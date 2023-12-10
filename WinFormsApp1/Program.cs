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
            Punishment.load();
            Settings.bot = new Bot();
            Settings.RunInBackground(TimeSpan.FromSeconds(3), () => outputCounter());
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }




        public static void outputCounter()
        {
            File.WriteAllText("./counter/L_counter.txt", Settings.L_counter.occurencesInTimeSpan(60).ToString());
            File.WriteAllText("./counter/W_counter.txt", Settings.W_counter.occurencesInTimeSpan(60).ToString());
            File.WriteAllText("./counter/GG_counter.txt", Settings.GG_counter.occurencesInTimeSpan(60).ToString());
            //File.WriteAllText("massstats.txt", Settings.bot.massStats());
            System.Diagnostics.Debug.WriteLine("Output");
            File.WriteAllText("./settings/punishedUsers.txt", Punishment.save());
        }
        

    }
}