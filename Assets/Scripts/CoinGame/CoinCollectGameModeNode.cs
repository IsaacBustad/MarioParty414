// Isaac Bustad
// 6/29/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BugFreeProductions.Party
{
    public class CoinCollectGameModeNode : GameModeNode
    {
        #region Class Variables
        // store coins collected by players
        protected Dictionary<SinglePlayerInputCollector, int> coinsCollByPlayer = new Dictionary<SinglePlayerInputCollector, int>();



        #endregion


        #region Class Methods
        // set defaults
        protected override void SetDefaults()
        {
            coinsCollByPlayer.Clear();

            // add all players to coinsCollByPlayer
            foreach (SinglePlayerInputCollector spic in GameMannager_Singleton.Instance.PICollectors)
            {
                coinsCollByPlayer.Add(spic, 0);
            }
        }

        protected override void RefreshInputRefference()
        {
            base.RefreshInputRefference();

        }

        // collect coin 
        // coins stored in coinsCollByPlayer
        #endregion


        #region Class Accessors

        #endregion
    }
}