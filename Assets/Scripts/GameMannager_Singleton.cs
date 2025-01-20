// Isaac Bustad
// 1/17/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannager_Singleton : MonoBehaviour
{
    // Vars
    // instance of the singal object to refference
    private GameMannager_Singleton instance = null;




    // Methods
    //public


    // Accessors
    public GameMannager_Singleton Instance 
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
