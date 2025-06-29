// Isaac Bustad
// 5/20/2025



using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BugFreeProductions.Party
{
    public class GamePlayerNode : MonoBehaviour
    {
        // Vars
        [SerializeField] protected Camera nodeCamera = null;

        // stored input value
        protected Vector3 moveDir = Vector3.zero;

        // player context references
        protected Rigidbody rb = null;
        //protected PlayerMoveContext pmc = null;

        // store input collector
        protected SinglePlayerInputCollector singlePlayerInputCollector = null;

        // Methods
        protected virtual void OnEnable()
        {
            CollectVars();
        }

        protected virtual void CollectVars()
        {
            rb = GetComponent<Rigidbody>();
        }

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
            Vector2 rVal = aCON.ReadValue<Vector2>();
            moveDir = new Vector3(rVal.x, 0, rVal.y);
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
        public Vector3 MovDir { get { return moveDir; } }

        public SinglePlayerInputCollector SinglePlayerInputCollector { get { return singlePlayerInputCollector; } set { singlePlayerInputCollector = value; } }
    }
}