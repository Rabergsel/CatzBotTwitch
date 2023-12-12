using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class PunishmentRecord
    {
        public string username { get; set; }
        public Dictionary<string, int> punishmentsByReason { get; set; }

        public int increasePunishmentCounter(string reason)
        {
            if(punishmentsByReason.ContainsKey(reason)) punishmentsByReason[reason]++;
            else punishmentsByReason.Add(reason, 1);

            return punishmentsByReason[reason];
        }

        public PunishmentRecord()
        {
            username = "";
            punishmentsByReason = new Dictionary<string, int>();
        }

        public PunishmentRecord(string username, Dictionary<string, int> punishementsByReason)
        {
            this.username = username;
            this.punishmentsByReason = punishementsByReason;
        }
    }
}
