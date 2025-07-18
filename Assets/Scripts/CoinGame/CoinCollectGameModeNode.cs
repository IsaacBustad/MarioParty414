// Isaac Bustad
// 6/29/2025

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using BugFreeProductions.Tools;

namespace BugFreeProductions.Party
{
    public class CoinCollectGameModeNode : GameModeNode
    {
        #region Class Variables
        // store coins collected by players
        protected Dictionary<SinglePlayerInputCollector, int> coinsCollByPlayer = new Dictionary<SinglePlayerInputCollector, int>();

        // store timer
        // timer times
        [SerializeField, Header("Timings for timer"), Tooltip("If there are breaks between rounds use start,round,pause,round format")] 
        protected List<float> roundTimings = new List<float>();

        // timer object
        protected RoundTimer roundTimer = null;        
        #endregion


        #region Class Methods
        protected override void OnEnable()
        {
            base.OnEnable();
            SetDefaults();
        }

        protected override void SetDefaults()
        {
            base.SetDefaults();
            

        }

        // set defaults
        protected override void InitGameMode()
        {
            // remove old coin scores
            coinsCollByPlayer.Clear();

            // add all players to coinsCollByPlayer
            foreach (SinglePlayerInputCollector spic in GameMannager_Singleton.Instance.PICollectors)
            {
                coinsCollByPlayer.Add(spic, 0);
            }

            // set game timers
            SetGameTimers();
        }

        // set game timers
        protected virtual void SetGameTimers()
        {
            roundTimer = gameObject.AddComponent<RoundTimer>();
            roundTimer.onGameRoundEnd += OnRoundEnd;
            roundTimer.StartTimers(roundTimings);
        }

        // actions done when game mode round ends as ends
        // called by delegate on the Round timer
        protected virtual void OnRoundEnd(int aRoundNum)
        {

            //   0      1    2     3     4
            // start pause round pause end
            if (roundTimer.CurrentRound == 0)
            {

            }

            else if (roundTimer.CurrentRound > 0)
            {

            }

            else if (roundTimer.CurrentRound % 2 != 0)
            {


            }
        }

        // collect coin 
        // coins stored in coinsCollByPlayer
        public virtual void CollectCoin(SinglePlayerInputCollector spic, int aCoinCount)
        {
            Debug.Log(coinsCollByPlayer[spic] + " is the old coin value");
            coinsCollByPlayer[spic] += aCoinCount;
            Debug.Log(coinsCollByPlayer[spic] + " is the new coin value");
        }

        protected override void RankPlayers()
        {
            // hold a coppy of a the ranking dictionary
            Dictionary<SinglePlayerInputCollector, int> holdToSort = coinsCollByPlayer;

            // hold sorted coppy of ranks to be filled
            Dictionary<SinglePlayerInputCollector, int> sortedRanks = new Dictionary<SinglePlayerInputCollector, int>();

            // rank for assignment
            int ranking = 0;

            // perform sort
            while (holdToSort.Count > 0)
            {
                // track last largest coin count
                int maxCoins = 0;

                // track last pair with the greatest coin value
                KeyValuePair<SinglePlayerInputCollector, int> maxKVP = new KeyValuePair<SinglePlayerInputCollector, int>();



                foreach (KeyValuePair<SinglePlayerInputCollector, int> kvp in holdToSort)
                {
                    if (kvp.Value > maxCoins)
                    {
                        maxCoins = kvp.Value;
                        maxKVP = kvp;
                    }
                }

                // add kvp to sorted
                sortedRanks.Add(maxKVP.Key, ranking);

                // remove the kvp from dict
                holdToSort.Remove(maxKVP.Key);

                // increase ranking
                ranking++;
            }
            playerRanks = sortedRanks;

            // comunicate the resulting rank to persistant manager
            UpdateMannagerRanks();

            // activate
            ActivateCanvas();
        }

        

        /* public void AltRankPlayers()
         {
             // hold a coppy of a the ranking dictionary
             Dictionary<SinglePlayerInputCollector, int> holdToSort = coinsCollByPlayer;

             // hold sorted coppy of ranks to be filled
             Dictionary<SinglePlayerInputCollector, int> sortedRanks = new Dictionary<SinglePlayerInputCollector, int>();

             // rank for assignment
             int ranking = 0;

             // perform sort
             while (holdToSort.Count > 0)
             {
                 // track last largest coin count
                 int maxCoins = 0;

                 // track last pair with the greatest coin value
                 KeyValuePair<SinglePlayerInputCollector, int> maxKVP = new KeyValuePair<SinglePlayerInputCollector, int>();



                 foreach (KeyValuePair<SinglePlayerInputCollector, int> kvp in holdToSort)
                 {
                     if (kvp.Value > maxCoins)
                     {
                         maxCoins = kvp.Value;
                         maxKVP = kvp;
                     }
                 }

                 // add kvp to sorted
                 sortedRanks.Add(maxKVP.Key, ranking);

                 // remove the kvp from dict
                 holdToSort.Remove(maxKVP.Key);

                 // increase ranking
                 ranking++;
             }
             playerRanks = sortedRanks;

             // comunicate the resulting rank to persistant manager
             UpdateMannagerRanks();

             // activate
             ActivateCanvas();
         }*/
        // activate canvas to end game
        protected virtual void ActivateCanvas()
        {
            GameObject endGameCanvas = FindObjectOfType<MenuNavigation>().gameObject;
            endGameCanvas.SetActive(true);
        }

        protected override void EndGame()
        {
            base.EndGame();
        }
        #endregion



        #region Class Accessors

        #endregion
    }
}