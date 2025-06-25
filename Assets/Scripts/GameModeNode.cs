// Isaac Bustad
// 5/13/2025


using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Party
{
    public class GameModeNode : MonoBehaviour
    {
        // Vars
        [SerializeField] protected List<GamePlayerNode> playerNodes = null;

        protected CameraViewportManager cameraViewportManager = new CameraViewportManager();

        // store player node ranking
        protected Dictionary<SinglePlayerInputCollector,int> playerRanks = new Dictionary<SinglePlayerInputCollector, int>();

        // Methods
        protected virtual void OnEnable()
        {
            RefreshGameModeInfo();
        }

        #region Player Rank Management
        // read initial rank for the player 
        // based on Single Player Input
        protected virtual void ReadInitRank()
        {
            playerRanks = GameMannager_Singleton.Instance.PlayerRanks;
        }

        // update local player ranks on node
        protected virtual void UpdatePlayerRank(SinglePlayerInputCollector aSPIC, int aRank)
        {
            playerRanks[aSPIC] += aRank;
        }

        // update player rank in mannager
        // assumes upatting of all players in game 
        protected virtual void UpdateMannagerRanks()
        {
            GameMannager_Singleton.Instance.UpdatePlayerRanks(playerRanks);
        }
        #endregion

        #region Player and Camera management

        
        public virtual void RefreshGameModeInfo()
        {
            // refresh Camera Viewport info
            RefreshCameraViewportRefference();

            // refresh Inputs 
            RefreshInputRefference();

            
        }

        // method to refresh input assignments
        protected virtual void RefreshInputRefference()
        {
            GameMannager_Singleton gms = GameMannager_Singleton.Instance;

            // set all gameManagerSingalton game node to this node
            gms.GameModeNode = this;

            // get input collectors from
            List<SinglePlayerInputCollector> spics = gms.PICollectors;


            // assign player node refference to input collectors
            for (int i = 0; i < spics.Count; i++)
            {
                // assign all input collectors an input node
                spics[i].PlayerNode = playerNodes[i];

                // look for player node camera
                Camera camera = playerNodes[i].NodeCamera;
                // add player cameras if there are any
                if ( camera != null)
                {
                    cameraViewportManager.ChangeCamViewport(camera,true);
                }

            }
        }

        protected virtual void RefreshCameraViewportRefference()
        {
            cameraViewportManager = new CameraViewportManager();

        }
        #endregion



        // Accessors



    }
}