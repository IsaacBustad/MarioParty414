// Isaac Bustad
// 9/24/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class CMD_Service : MonoBehaviour
    {
        // Vars



        // Methods
        public virtual void Request(GameObject aGO)
        {
            //Debug.Log("Action 7");
            Service(aGO);
            //Debug.Log("Action 8");
        }

        protected virtual void Service(GameObject aGO)
        {
            Debug.Log("Loks lick me made it");
        }


        // Accessors



    }
}