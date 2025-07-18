// Isaac Busatd
// 7/8/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BugFreeProductions.Tools;

namespace BugFreeProductions.Party.Coin
{
    public class CoinCMD_Client : Col_CMD_Client
    {
        #region Vars
        [SerializeField,Header("Value of the coin")] protected int coinValue = 1;
        #endregion

        #region Methods

        // on collision pass in game object on the Rigidbody
        protected override void OnCollisionEnter(Collision aCollision)
        {
            Request(aCollision.gameObject);
        }
        #endregion

        #region Accessors
        public int CoinValue { get { return coinValue; }  }
        #endregion
    }
}