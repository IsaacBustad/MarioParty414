// Isaac Busatd
// 1/16/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BridgeNavigator : MonoBehaviour
{
    // Vars
    protected PartyInputBridge pib = null;


    // Methods
    // done on Enable to save resources
    //Setup my vars and set external references
    protected virtual void OnEnable()
    {
        CollectVariables();
    }

    protected virtual void CollectVariables()
    {
        //pib
    }

    #region Input Management
    #region ForPrimary gameplay Buttons
    // expect button callback
    public virtual void PrimaryButtonPress(InputAction.CallbackContext aCON)
    {

    }


    // expect button callback
    public virtual void SecondaryButtonPress(InputAction.CallbackContext aCON)
    {

    }

    // expext callback context
    public virtual void FourWayInput(InputAction.CallbackContext aCON)
    {

    }
    #endregion

    #region AuxButtons for extra functionality
    // expect button callback
    public virtual void AuxButtonPress(InputAction.CallbackContext aCON)
    {

    }

    // expect button callback
    public virtual void PositiveAuxButtonPress(InputAction.CallbackContext aCON)
    {

    }

    // expect button callback
    public virtual void NegativeAuxButtonPress(InputAction.CallbackContext aCON)
    {

    }
    #endregion

    #endregion

    #region Destroy Logic
    #endregion
    // Accessors





}
