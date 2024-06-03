using Il2CppAssets.Scripts.UI.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FriendsLeaderboard.Save;
using HarmonyLib;
using UnityEngine;

namespace FriendsLeaderboard.Patches
{
    [HarmonyPatch(typeof(PnlRank), nameof(PnlRank.UIRefresh))]
    public class FriendsLeaderboardPatch
    {

        private static void Postfix()
        {
            Color defaultColor = new Color(0.8353f, 0.7373f, 1, 0.6f);
            Color highlightColor = Save.Data.HighlightColor;
            string[] friendsNames = Save.Data.FriendsNames;

            var rankCells = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank/ScvRank/Viewport/Content");

            for (int i = 0; i < rankCells.transform.childCount; i++)
            {
                GameObject cell = rankCells.transform.GetChild(i).gameObject;

                var nameval = cell.transform.Find("TxtIdValueS");

                bool nameMatch = false;
                string cellName = nameval.gameObject.GetComponent<UnityEngine.UI.Text>().text;

                for (int j = 0;j < friendsNames.Length; j++)
                {
                    if (friendsNames[j].Equals(cellName))
                    {
                        nameMatch = true;
                        break;
                    }
                }

                if (nameMatch)
                {
                    nameval.gameObject.GetComponent<UnityEngine.UI.Text>().color = highlightColor;

                    var rankval = cell.transform.Find("TxtRankValueS");
                    rankval.gameObject.GetComponent<UnityEngine.UI.Text>().color = highlightColor;

                    var scoreval = cell.transform.Find("TxtScoreValueS");
                    scoreval.gameObject.GetComponent<UnityEngine.UI.Text>().color = highlightColor;

                    var accval = cell.transform.Find("TxtAccuracyValueS");
                    accval.gameObject.GetComponent<UnityEngine.UI.Text>().color = highlightColor;
                } else
                {
                    nameval.gameObject.GetComponent<UnityEngine.UI.Text>().color = defaultColor;

                    var rankval = cell.transform.Find("TxtRankValueS");
                    rankval.gameObject.GetComponent<UnityEngine.UI.Text>().color = defaultColor;

                    var scoreval = cell.transform.Find("TxtScoreValueS");
                    scoreval.gameObject.GetComponent<UnityEngine.UI.Text>().color = defaultColor;

                    var accval = cell.transform.Find("TxtAccuracyValueS");
                    accval.gameObject.GetComponent<UnityEngine.UI.Text>().color = defaultColor;
                }

            } 
        }
    }
}
