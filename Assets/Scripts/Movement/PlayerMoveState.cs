// Isaac Bustad
// 6/19/2025



using BugFreeProductions.Extentions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Party
{
    public class PlayerMoveState 
    {
        // Actions executed every Fixed Update
        public virtual void FUActions(PlayerMoveContext aPMC)
        {
            Move(aPMC);
            LimmitVel(aPMC);
        }

        // moves the player bassed on player state
        protected virtual void Move(PlayerMoveContext aPMC)
        {
            if (aPMC.RB.velocity.magnitude < 10)
            {
                aPMC.RB.AddForce(aPMC.PlayerNode.MovDir.normalized * 50);
            }
            
        }

        protected virtual void LimmitVel(PlayerMoveContext aPMC)
        {
            BugFreeTool.LimitToWorldVelocity(aPMC.RB.velocity);
        }
    }
}