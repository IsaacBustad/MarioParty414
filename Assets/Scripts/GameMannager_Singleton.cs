// Isaac Bustad
// 1/17/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMannager_Singleton : MonoBehaviour
{
    // Vars
    public delegate void OnGameNodeChangeDel(GameModeNode aGMN);
    public OnGameNodeChangeDel onGameNodeChangeDel;

    // instance of the singal object to refference
    private static GameMannager_Singleton instance = null;

    private List<SinglePlayerInputCollector> piCollectors = new List<SinglePlayerInputCollector>();




    // Methods
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
            
        }
    }

    // added for on OnPlayerJoin PlayerInputManagement CallBack
    public void OnPlayerJoin(PlayerInput aPI)
    {
        piCollectors.Add(aPI.GetComponent<SinglePlayerInputCollector>());
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


}
