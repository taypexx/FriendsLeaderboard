using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomlet;
using Tomlet.Attributes;
using UnityEngine;

namespace FriendsLeaderboard
{
    internal static class Save
    {
        internal static Data Data = new();

        public static void Load()
        {
            if (!File.Exists(Path.Combine("UserData", "FriendsLeaderboard.cfg")))
            {
                var defaultConfig = TomletMain.TomlStringFrom(Data);
                File.WriteAllText(Path.Combine("UserData", "FriendsLeaderboard.cfg"), defaultConfig);
            }

            var data = File.ReadAllText(Path.Combine("UserData", "FriendsLeaderboard.cfg"));
            Data = TomletMain.To<Data>(data);
        }
    }

    public class Data
    {
        [TomlPrecedingComment("The list of friends usernames to be highlighted")]
        internal string[] FriendsNames { get; set; } = { "FriendName1", "FriendName2" };

        [TomlPrecedingComment("The color of highlighting")]
        internal Color HighlightColor { get; set; } = new Color(0, 0.6373f, 1, 0.8f);

        [TomlPrecedingComment("Your usernames")]
        internal string[] SelfNames { get; set; } = { "YourName1", "YourName2" };

        [TomlPrecedingComment("The color of highlighting for yourself")]
        internal Color SelfColor { get; set; } = new Color(0.9f, 0f, 1f, 0.8f);

        [TomlPrecedingComment("Default color of other usernames")]
        internal Color DefaultColor { get; set; } = new Color(0.8353f, 0.7373f, 1, 0.6f);
    }
}