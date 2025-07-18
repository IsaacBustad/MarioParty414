// Isaac Bustad
// 11/5/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BugFreeProductions.Tools
{
    public class CMD_Client : MonoBehaviour
    {
        protected virtual void Request(GameObject aGO)
        {
            //Debug.Log("Action 1");
            CMD_Request CMD_Request = aGO.GetComponent<CMD_Request>();


            //Debug.Log("Action 2");

            if (CMD_Request != null)
            {

                //Debug.Log("Action 3");
                CMD_Request.Request(gameObject);
                //Debug.Log("Action 4");

            }
        }
    }
}