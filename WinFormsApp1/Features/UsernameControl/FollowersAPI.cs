using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TwitchBot.Features.UsernameControl
{
    public class FollowersAPI
    {

        public static TwitchLib.Api.Helix.Models.Users.GetUserFollows.GetUsersFollowsResponse GetFollowers(ref TwitchLib.Api.TwitchAPI api, string fromid)
        {
            try
            {
                Debug.WriteLine("Starting fetching of follower list");
                var channelFollowers = api.Helix.Users.GetUsersFollowsAsync(fromId: fromid).Result;
                Debug.WriteLine("Fetching done!");
                return channelFollowers;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return new TwitchLib.Api.Helix.Models.Users.GetUserFollows.GetUsersFollowsResponse();
            }
        }

    }
}
