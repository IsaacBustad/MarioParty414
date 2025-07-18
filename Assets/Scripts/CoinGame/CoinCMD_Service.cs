// Isaac Bustad
// 7/9/2025


using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BugFreeProductions.Party.Coin
{
    public class CoinCMD_Service : CMD_Service
    {
        #region Vars
        protected CoinCollectGameModeNode coinCollectGame = null;
        #endregion


        #region Methods
        protected override void Service(GameObject aGO)
        {
            // look for ref to coin Client
            CoinCMD_Client coin = aGO.GetComponent<CoinCMD_Client>();

            // add coin value to Coin Game Mode Node
            if (coin != null && SearchForGameMode() == true)
            {
                // search for player node
                CoinCollectPlayerNode cpn = GetComponent<CoinCollectPlayerNode>();

                // 
                if (cpn != null)
                {
                    coinCollectGame.CollectCoin(cpn.SinglePlayerInputCollector, coin.CoinValue);
                }
                
            }
            base.Service(aGO);
        }

        // search for game mode (Coin Collect Game Mode Node)
        protected virtual bool SearchForGameMode()
        {
            // try to find the game mode
            if ( coinCollectGame == null)
            {
                coinCollectGame = transform.GetComponentInParent<CoinCollectGameModeNode>();
            }

            // return if a refference is found or present
            if( coinCollectGame != null )
            {
                return true;
            }

            // if no refference was found
            else { return false; }

        }

        #endregion


        #region Accessors

        #endregion
    }
}