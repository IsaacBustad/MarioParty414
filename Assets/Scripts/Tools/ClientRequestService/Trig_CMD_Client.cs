// Isaac Bustad
// 11/5/2024


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class Trig_CMD_Client : CMD_Client
    {
        // Vars



        // Methods
        protected virtual void OnTriggerEnter(Collider other)
        {
            //other.attachedRigidbody.gameObject.name = "here is collision";
            //Debug.Log("Found it " + other.gameObject.name);

            Rigidbody aRB = other.attachedRigidbody;
            //Debug.Log(other.gameObject);

            if (aRB != null)
            {
                Request(aRB.gameObject);
            }
            else
            {
                Request(other.gameObject);
            }
            //Request(other.attachedRigidbody.gameObject);
        }



        // Accessors




    }
}