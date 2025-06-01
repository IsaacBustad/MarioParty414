// Isaac Bustad
// 5/13/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace BugFreeProductions.Party
{
    public class SinglePlayerInputCollector : MonoBehaviour
    {

        // Vars
        protected GameModeNode gameModeNode = null;
        [SerializeField] protected GamePlayerNode playerNode = null;


        // Methods
        public virtual void OnGameModeNodeChange(GameModeNode aGMN)
        {
            gameModeNode = aGMN;
        }



        // done on Enable to save resources
        //Setup my vars and set external references
        protected virtual void OnEnable()
        {
            CollectVariables();
        }

        protected virtual void CollectVariables()
        {
            //pib
            //GameMannager_Singleton.Instance.onGameNodeChangeDel += OnGameModeNodeChange;
            transform.parent = GameMannager_Singleton.Instance.gameObject.transform;
        }

        #region Input Management
        #region ForPrimary gameplay Buttons
        // expect button callback
        public virtual void PrimaryButtonPress(InputAction.CallbackContext aCON)
        {
            if (playerNode != null)
            {
                playerNode.PrimaryButtonPress(aCON);
            }
        }


        // expect button callback
        public virtual void SecondaryButtonPress(InputAction.CallbackContext aCON)
        {
            if(playerNode != null)
            {
                playerNode.SecondaryButtonPress(aCON);
            }
        }

        // expext callback context
        public virtual void FourWayInput(InputAction.CallbackContext aCON)
        {
            Debug.Log(aCON.ReadValue<Vector2>());
            if (playerNode != null)
            {
                playerNode.FourWayInput(aCON);
            }
        }
        #endregion

        #region AuxButtons for extra functionality
        // expect button callback
        public virtual void AuxButtonPress(InputAction.CallbackContext aCON)
        {
            if (playerNode != null)
            {
                playerNode.AuxButtonPress(aCON);
            }
        }

        // expect button callback
        public virtual void PositiveAuxButtonPress(InputAction.CallbackContext aCON)
        {
            if (playerNode != null)
            {
                playerNode.PositiveAuxButtonPress(aCON);
            }
        }

        // expect button callback
        public virtual void NegativeAuxButtonPress(InputAction.CallbackContext aCON)
        {
            if ( playerNode != null)
            {
                playerNode.NegativeAuxButtonPress(aCON);
            }
        }
        #endregion

        #endregion

        #region Destroy Logic
        #endregion
        // Accessors
        public GamePlayerNode PlayerNode { get { return playerNode; } set { Debug.Log(value.name); playerNode = value; } }


    }
}