using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class RateCounter
    { 

        List<DateTime> occurences = new List<DateTime>();

        public int occurencesInTimeSpan(int seconds)
        {
            int counter = 0;

            if (occurences.Count == 0) return 0;
            for(int i = occurences.Count - 1; i >= 0; i--)
            {
                if ((DateTime.Now - occurences[i]).TotalSeconds < seconds) counter++;
                else
                {
                    break;
                }
            }

            return counter;
        }


        public void addOccurence()
        {
            occurences.Add(DateTime.Now);
        }
    }
}
