// Isaac Bustad
// 6/19/2025



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Party 
{
    public class PlayerMoveContext : MonoBehaviour
    {
        // Vars
        protected PlayerMoveState moveState = new PlayerMoveState();

        // store player node
        protected GamePlayerNode playerNode = null;

        // store Rigidbody
        protected Rigidbody rb = null;

        // Methods
        protected virtual void OnEnable()
        {
            CollectVars();
            SetDefaults();
        }

        // collect all refferences
        protected virtual void CollectVars()
        {
            rb = GetComponent<Rigidbody>();
            playerNode = GetComponent<GamePlayerNode>();
        }

        protected virtual void SetDefaults()
        {
            rb.freezeRotation = true;
        }

        // actions to take place every fixed update
        protected virtual void FixedUpdate()
        {
            FUActions();
        }
        protected virtual void FUActions()
        {
            moveState.FUActions(this);
        }

        // Accessors
        //public Vector3 MovDir { };
        public Rigidbody RB { get { return rb; } }
        public GamePlayerNode PlayerNode { get {  return playerNode; } }

    }
}