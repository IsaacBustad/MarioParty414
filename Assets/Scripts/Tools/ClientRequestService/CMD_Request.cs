// Isaac Bustad
// 9/24/2024



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BugFreeProductions.Tools
{
    public class CMD_Request : MonoBehaviour
    {
        // Vars
        [SerializeField] protected CMD_Service[] col_CMD_Services;



        // Methods
        public virtual void Request(GameObject aGO)
        {
            //Debug.Log("Action 5");
            foreach (CMD_Service service in col_CMD_Services) { service.Request(aGO); }
            //Debug.Log("Action 6");
        }



    }
}