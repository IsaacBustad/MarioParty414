// Isaac Busatd
// 5/30/2025


using BugFreeProductions.Party;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestableGamePlayerNode : GamePlayerNode
{
    // Vars



    // Methods
    // expext callback V2
    public override void FourWayInput(InputAction.CallbackContext aCON)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(aCON.ReadValue<Vector2>()*50);

    }


    // Accessors
}
