using System;
using UnityEngine;
using UnityEngine.Events;

namespace Manager
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float secondsRemaining;
        [SerializeField] public bool isRunning = false;

        public UnityEvent expired;

        private void Awake(){
            expired = new UnityEvent();
        }

        private void Update()
        {
            if (!isRunning)
                return;
            
            if (secondsRemaining > 0)
            {
                secondsRemaining -= Time.deltaTime;
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
    }
}