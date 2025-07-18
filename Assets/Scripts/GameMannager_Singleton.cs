// Isaac Bustad
// 1/17/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;


namespace BugFreeProductions.Party

{
    public class GameMannager_Singleton : MonoBehaviour
    {
        // Vars
        // Delegates
        /*public delegate void OnGameNodeChangeDel(GameModeNode aGMN);
        public OnGameNodeChangeDel onGameNodeChangeDel;*/
        protected GameModeNode gameModeNode = null;


        // instance of the singal object to refference
        private static GameMannager_Singleton instance = null;

        private List<SinglePlayerInputCollector> piCollectors = new List<SinglePlayerInputCollector>();

        // store current Player Ranks
        protected Dictionary<SinglePlayerInputCollector, int> playerRanks =
                                new System.Collections.Generic.Dictionary<SinglePlayerInputCollector,int>();




        // Methods
        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
                GetComponent<PlayerInputManager>().playerJoinedEvent.AddListener(OnPlayerJoin);
                //GetComponent<PlayerInputManager>().playerLeftEvent.RemoveListener(OnPlayerJoin);
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            // debug some info for status checks
            Report();
        }

        // Debug a report on current class status
        protected virtual void Report()
        {
            foreach (KeyValuePair<SinglePlayerInputCollector,int> kvp in playerRanks)
            {
                Debug.Log(kvp.Key + " " + kvp.Value);
            }
            Debug.Log("" + playerRanks);
        }


        // initialize new dictionary for ranks
        protected virtual void InitPlayerRanks()
        {
            // clear any residual player info
            playerRanks.Clear();

            // create new dictionary info
            foreach (SinglePlayerInputCollector spc in piCollectors)
            {
                playerRanks.Add(spc,0);
            }

        }

        // update the Player Ranks
        public virtual void UpdatePlayerRanks(Dictionary<SinglePlayerInputCollector,int> aPlayerRanks )
        {
            foreach (KeyValuePair<SinglePlayerInputCollector,int>  pr in aPlayerRanks)
            {
                playerRanks[pr.Key] += pr.Value;
                Debug.Log("New Manager Value = " + playerRanks[pr.Key]);
            }
            
        }


        // added for on OnPlayerJoin PlayerInputManagement CallBack
        public void OnPlayerJoin(PlayerInput aPI)
        {
            piCollectors.Add(aPI.GetComponent<SinglePlayerInputCollector>());
            InitPlayerRanks();

            // Refresh the game mode node info if exist
            RefreshGameModeNode();
        }

        // refresh the game mode node
        public virtual void RefreshGameModeNode()
        {
            // Refresh the game mode node info if exist
            if (gameModeNode == null)
            {
                gameModeNode = FindObjectOfType<GameModeNode>();
            }
            gameModeNode.RefreshGameModeInfo();
        }


        // Accessors
        public static GameMannager_Singleton Instance
        {
            get
            {
                /*if (instance == null)
                {
                    // create new empty object
                    GameObject nGO = new GameObject();

                    // prevent object from being destroyed on new scene load
                    DontDestroyOnLoad(nGO);

                    // create the instance to be later refferenced
                    instance = nGO.gameObject.AddComponent<GameMannager_Singleton>();
                }*/
                return instance;
            }
        }

        // Accessors
        public List<SinglePlayerInputCollector> PICollectors { get { return piCollectors; } }
        public GameModeNode GameModeNode { get { return gameModeNode; } set { gameModeNode = value; } }

        public Dictionary<SinglePlayerInputCollector,int> PlayerRanks { get { return playerRanks; } }

    }
}