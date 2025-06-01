// Isaac Bustad
// 1/17/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


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




        // Methods
        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
                GetComponent<PlayerInputManager>().onPlayerJoined += OnPlayerJoin;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                /*if (instance != this)
                {
                    Destroy(gameObject);
                }*/
                Destroy(gameObject);
            }
        }

        // added for on OnPlayerJoin PlayerInputManagement CallBack
        public void OnPlayerJoin(PlayerInput aPI)
        {
            piCollectors.Add(aPI.GetComponent<SinglePlayerInputCollector>());

            // Refresh the game mode node info if exist
            if (gameModeNode != null)
            {
                gameModeNode.RefreshGameModeInfo();
            }
        }


        // Accessors
        public static GameMannager_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    // create new empty object
                    GameObject nGO = new GameObject();

                    // prevent object from being destroyed on new scene load
                    DontDestroyOnLoad(nGO);

                    // create the instance to be later refferenced
                    instance = nGO.gameObject.AddComponent<GameMannager_Singleton>();
                }
                return instance;
            }
        }

        public List<SinglePlayerInputCollector> PICollectors { get { return piCollectors; } }
        public GameModeNode GameModeNode { get { return gameModeNode; } set { gameModeNode = value; } }

    }
}