// Isaac Bustad
// 9/24/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class Col_CMD_Client : CMD_Client
    {
        // Vars


        // Methods
        /*protected virtual void Request(Collision aCollision)
        {           
            //Debug.Log("Action 1");
            CMD_Request CMD_Request = aCollision.gameObject.GetComponent<CMD_Request>();


            //Debug.Log("Action 2");

            if (CMD_Request != null)
            {

                //Debug.Log("Action 3");
                CMD_Request.Request(gameObject);
                //Debug.Log("Action 4");

            }
        }*/

        // occures on collision
        protected virtual void OnCollisionEnter(Collision aCollision)
        {
            Request(aCollision.gameObject);
        }



        // Accessors
    }
}