using System;
using UnityEngine;
using UnityEngine.Events;

namespace Manager
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float startingTime = 300;
        [SerializeField] private float secondsRemaining;
        [SerializeField] public bool isRunning = false;

        public UnityEvent expired;

        private void Awake(){
            expired = new UnityEvent();
            secondsRemaining = startingTime;
        }

        private void Update()
        {
            if (!isRunning)
                return;
            
            if (secondsRemaining > 0)
            {
                secondsRemaining -= Time.unscaledDeltaTime;
            }
            else 
            {
                isRunning = false;
                secondsRemaining = 0;
                expired.Invoke();
            }
        }

        public TimeSpan GetRemainingTime()
        {
            return new TimeSpan(0, 0, (int) secondsRemaining);
        }

        public void Reset()
        {
            secondsRemaining = startingTime;
        }
    }
}