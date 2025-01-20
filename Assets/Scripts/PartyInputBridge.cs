// Isaac Bustad
// 1/16/25


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PartyInputBridge : MonoBehaviour
{
    // Vars
    // input component of player
    [SerializeField] protected PlayerInput playerInput;

    protected BridgeNavigator bridgeNavigator = null;


    // Methods
    #region Input Management

    #region ForPrimary gameplay Buttons
    // expect button callback (South Button and L Mouse Click and Space Key)
    protected virtual void PrimaryButtonPress(InputAction.CallbackContext aCON)
    {
        if(!BridgeNavigatorNullCHK)
        {
            bridgeNavigator.PrimaryButtonPress(aCON);
        }
    }


    // expect button callback (East Button and R Mouse Click and Shift Key)
    protected virtual void SecondaryButtonPress(InputAction.CallbackContext aCON)
    {
        if (!BridgeNavigatorNullCHK)
        {
            bridgeNavigator.SecondaryButtonPress(aCON);
        }
    }

    // expext callback context (Controle Stick and WSAD Key Press)
    protected virtual void FourWayInput(InputAction.CallbackContext aCON)
    {
        if (!BridgeNavigatorNullCHK) 
        {
            bridgeNavigator.FourWayInput(aCON);
        }
    }
    #endregion

    #region AuxButtons for extra functionality
    /*// expect button callback
    protected virtual void AuxButtonPress(InputAction.CallbackContext aCON)
    {
        if (!BridgeNavigatorNullCHK)
        {
            bridgeNavigator.AuxButtonPress(aCON);
        }
    }*/

    // expect button callback
    protected virtual void PositiveAuxButtonPress(InputAction.CallbackContext aCON)
    {
        if (!BridgeNavigatorNullCHK)
        {
            bridgeNavigator.PositiveAuxButtonPress(aCON);
        }
    }

    // expect button callback
    protected virtual void NegativeAuxButtonPress(InputAction.CallbackContext aCON)
    {
        if (!BridgeNavigatorNullCHK)
        {
            bridgeNavigator.NegativeAuxButtonPress(aCON);
        }
    }
    #endregion

    #endregion

    #region Do Not Destroy Logic
    public virtual void ParrentThisObject(Transform aTF)
    {
        Transform ntf = gameObject.GetComponent<PlayerInputManager>().transform;
        if (ntf != null)
        {
            transform.parent = aTF;
        }
        
    }
    #endregion

    // Accessors
    protected virtual bool BridgeNavigatorNullCHK
    {
        get
        {
            if (bridgeNavigator != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


}
