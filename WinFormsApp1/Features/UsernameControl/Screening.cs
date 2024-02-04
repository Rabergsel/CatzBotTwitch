using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TwitchBot.Features.UsernameControl
{
    public class Screening
    {

        public static void screen(ref TwitchLib.Api.TwitchAPI api, string fromid)
        {
            var response = FollowersAPI.GetFollowers(ref api, fromid);

            if(response.Follows == null)
            {
                DC.DCManager.accumulator("SCREEN", "Could not screen followers");
                return;

            }

            foreach (var f in response.Follows)
            {
                Debug.WriteLine($"Screening follow from {f.FromUserName}");
                if (isRandom(f.FromUserName, WinFormsApp1.Settings.model.RandomThreshold, WinFormsApp1.Settings.model.RandomMinimumLength))
                {

                    if(!WinFormsApp1.Settings.model.suspiciosUsernames.Contains(f.FromUserName))
                    {
                        DC.DCManager.sendEmbed(DSharpPlus.Entities.DiscordColor.Red, "New random user found!", "A new random username was detected in the follower list: " + f.FromUserName, "Informed via dISCORD");
                        WinFormsApp1.Settings.model.suspiciosUsernames.Add(f.FromUserName);
                    }
                }
            }

            DC.DCManager.accumulator("SCREEN", " Follower List was scanned: " + response.TotalFollows + " followers");

        }


        public static bool isRandom(string username, float threshold, int minimumLength)
        {

            if (username.Length < minimumLength) return false;

            int sectors = 0;

            bool lastwasnumber = false;
            for(int i = 0; i < username.Length; i++)
            {
                if(new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }.Contains(username[i]))
                {
                    if (lastwasnumber) continue;
                    else { sectors++;  lastwasnumber = false; } 
                }
                else
                {
                    if (!lastwasnumber) continue;
                    else { sectors++; lastwasnumber = true; }
                }

            }

            Debug.WriteLine("Random score: " + (sectors / username.Length));
            return (sectors / username.Length) < threshold;

        }

    }
}
