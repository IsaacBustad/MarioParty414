// Isaac Bustad
//7/12/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class RoundTimer : MonoBehaviour
    {
        #region Vars
        // deligates
        public delegate void GameModeTimerChange(int aRoundNum);

        // delegate instances
        public GameModeTimerChange onGameStarted;
        public GameModeTimerChange onRoundTimerPauseEnd;
        public GameModeTimerChange onGameRoundTimerBegin;
        public GameModeTimerChange onGameRoundEnd;
        public GameModeTimerChange onGameModeClose;

        // timer times
        protected List<float> timertimes = new List<float>();
        protected float startTime = 3f;
        protected List<float> roundTimes;
        protected float endTime = 3f;

        // time on timers
        protected float timeToStart = 0;
        protected float timeToRound = 0;
        protected float timeToPause = 0;
        protected float timeToEnd = 0;

        // rounds
        protected int roundNum = 0;

        protected float currentTimer = 0;
        protected float currentPause = 0;

        // bool to enable timer operations
        protected bool isStarted = false;
        #endregion

        #region Methods
        protected virtual void Update()
        {
            OpperateTimer();
        }

        // called to run timer opperations
        // called on update to avoid fixed update bloat
        protected virtual void OpperateTimer()
        {
            if (isStarted == true && timertimes.Count > 0)
            {
                if (currentTimer <= 0 && roundNum < timertimes.Count)
                {
                    // set the current timer for the next timer value
                    currentTimer = timertimes[roundNum];

                    // execute round end actions
                    onGameRoundEnd(roundNum);

                    // increment so next round is sellected for future loop
                    roundNum++;

                    
                }

                // end last timer
                else if (currentTimer <= 0 && roundNum >= timertimes.Count)
                {
                    // execute round end actions
                    onGameRoundEnd(roundNum);

                    // stop timer from opperating
                    isStarted = false;
                }

                else if (currentTimer > 0)
                {
                    // decrement the current timer
                    currentTimer -= Time.deltaTime;
                }
                Debug.Log("Current round = " + roundNum + "   Time on Timer = " + CurrentTimeOnTimer);


            }


        }

        // add time to current timer
        public virtual void AddToTimer( float aTime)
        {
            currentTimer += aTime;
        }


        public virtual void StartTimers(List<float> aRoundTimes)
        {
            currentTimer = aRoundTimes[0];

            // set up the timers for multiple rounds
            timertimes = aRoundTimes;

            // enable timer start condition
            isStarted = true;
        }
        #endregion


        #region Accessors
        // give current time rounded to nearest 2 decimal
        public string CurrentTimeOnTimer 
        { 
            get 
            {
                if (currentTimer > 0)
                {
                    return currentTimer.ToString("F2");
                }
                else 
                {
                    return 0.ToString("F2");
                }
                 
            } 
        }

        public int CurrentRound { get { return roundNum; } }
        #endregion
    }
}