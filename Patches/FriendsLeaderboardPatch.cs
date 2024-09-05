using Il2CppAssets.Scripts.UI.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FriendsLeaderboard.Save;
using HarmonyLib;
using UnityEngine;
using Il2CppAssets.Scripts.PeroTools.Nice.Values;
using MelonLoader;

namespace FriendsLeaderboard.Patches
{

    [HarmonyPatch(typeof(PnlRank), nameof(PnlRank.UIRefresh))]
    public class FriendsLeaderboardPatch
    {
        private static void Postfix()
        {

            UnityEngine.Color defaultColor = Save.Data.DefaultColor;
            UnityEngine.Color highlightColor = Save.Data.HighlightColor;
            UnityEngine.Color selfColor = Save.Data.SelfColor; 
            string[] friendsNames = Save.Data.FriendsNames;
            string[] selfNames = Save.Data.SelfNames;

            var rankCells = UnityEngine.GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank/ScvRank/Viewport/Content");

            for (int i = 0; i < rankCells.transform.childCount; i++)
            {
                UnityEngine.GameObject cell = rankCells.transform.GetChild(i).gameObject;

                var nameval = cell.transform.Find("TxtIdValueS").gameObject.GetComponent<UnityEngine.UI.Text>();
                var rankval = cell.transform.Find("TxtRankValueS").gameObject.GetComponent<UnityEngine.UI.Text>();
                var scoreval = cell.transform.Find("TxtScoreValueS").gameObject.GetComponent<UnityEngine.UI.Text>();
                var accval = cell.transform.Find("TxtAccuracyValueS").gameObject.GetComponent<UnityEngine.UI.Text>();

                int nameMatch = 0;
                string cellName = nameval.text;

                for (int j = 0;j < friendsNames.Length; j++)
                {
                    if (friendsNames[j].Equals(cellName))
                    {
                        nameMatch = 1;
                        break;
                    }
                }

                for (int j = 0; j < selfNames.Length; j++)
                {
                    if (selfNames[j].Equals(cellName))
                    {
                        nameMatch = 2;
                        break;
                    }
                }

                if (nameMatch == 1)
                {
                    nameval.color = highlightColor;
                    rankval.color = highlightColor;
                    scoreval.color = highlightColor;
                    accval.color = highlightColor;
                }
                else if (nameMatch == 2)
                {
                    nameval.color = selfColor;
                    rankval.color = selfColor;
                    scoreval.color = selfColor;
                    accval.color = selfColor;
                } else
                {
                    nameval.color = defaultColor;
                    rankval.color = defaultColor;
                    scoreval.color = defaultColor;
                    accval.color = defaultColor;
                }

            } 
        }
    }
}
