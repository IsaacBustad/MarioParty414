// Isaac Bustad
// 5/13/2025


using BugFreeProductions.Tools;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace BugFreeProductions.Party
{
    public class GameModeNode : MonoBehaviour
    {
        // Vars
        // game player nodes
        [SerializeField] protected List<GamePlayerNode> playerNodes = null;

        // camera viewport management system
        protected CameraViewportManager cameraViewportManager = new CameraViewportManager();

        // store SinglePlayerInputCollector node ranking
        protected Dictionary<SinglePlayerInputCollector,int> playerRanks = new Dictionary<SinglePlayerInputCollector, int>();

        // has the game mode been initalized
        protected bool gameModeInit = false;

        // Methods
        protected virtual void OnEnable()
        {
            GameMannager_Singleton gms = GameMannager_Singleton.Instance;
            if (gms != null)
            {
                gms.GameModeNode = this;
                gms.RefreshGameModeNode();
            }
                        
        }

        // Set Defaults
        protected virtual void SetDefaults()
        {

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

        // rank players
        // to be overwritten by child classes
        protected virtual void RankPlayers()
        {
            
            
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

            // initialized if not initialized
            InitGameMode();


        }

        // initialize the game mode
        protected virtual void InitGameMode()
        {
                gameModeInit = true;            
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
            if (spics.Count > 0 && playerNodes.Count >= spics.Count)
            {
                for (int i = 0; i < spics.Count; i++)
                {
                    // assign all input collectors a player node
                    spics[i].PlayerNode = playerNodes[i];

                    // assign all player nodes a input collector
                    playerNodes[i].SinglePlayerInputCollector = spics[i];

                    // look for player node camera
                    Camera camera = playerNodes[i].NodeCamera;
                    // add player cameras if there are any
                    if (camera != null)
                    {
                        cameraViewportManager.ChangeCamViewport(camera, true);
                    }

                }
            }
            else if(playerNodes.Count < spics.Count)
            {
                Debug.LogError("Not enough Player Nodes are not added to Player Nodes Array on: " + this.name);
            }
            
        }

        protected virtual void RefreshCameraViewportRefference()
        {
            cameraViewportManager = new CameraViewportManager();

        }

        protected virtual void EndGame()
        {

        }
        #endregion



        // Accessors



    }
}