using MelonLoader;
using Tomlet;
using static FriendsLeaderboard.Save;
using UnityEngine;

namespace FriendsLeaderboard
{
    public class Main : MelonMod
    {

        public override void OnInitializeMelon()
        {
            Load();
            MelonLogger.Msg("FriendsLeaderboard initialized.");
        }
    }
}
