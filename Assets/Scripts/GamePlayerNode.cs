// Isaac Bustad
// 5/20/2025



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BugFreeProductions.Party
{
    public class GamePlayerNode : MonoBehaviour
    {
        // Vars
        [SerializeField] protected Camera nodeCamera = null;


        // Methods
        #region Camera Management

        #endregion
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

        #region Destroy
        protected virtual void OnDestroy()
        {

        }

        #endregion 

        // Accessors
        public Camera NodeCamera { get { return nodeCamera; } }
    }
}