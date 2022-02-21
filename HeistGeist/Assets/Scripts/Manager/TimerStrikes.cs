using System;
using Manager.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Manager
{
    [Serializable] public class TimerStrikes
    {
        [SerializeField] private int currStrikes;
        public int CurrStrikes {
            get => currStrikes;
            set {
                currStrikes = value;
                TimerStrikesUI.SetStrikes(value);
            }
        }
        [SerializeField] private Timer timer = new Timer();
        public UnityEvent TimerExpired => timer.expired;

        public TimerStrikesUI TimerStrikesUI { set; get; }
        
        public void AddStrike()
        {
            CurrStrikes++;
        }

        public void SetRemainingSeconds(float seconds)
        {
            timer.remainingSeconds = seconds;
            TimerStrikesUI.SetTime(GetRemainingTime());
        }
        
        public void UpdateTimer(float deltaTime)
        {
            timer.Update(deltaTime);
            TimerStrikesUI.SetTime(GetRemainingTime());
        }
        
        public TimeSpan GetRemainingTime()
        {
            return new TimeSpan(0, 0, (int) timer.remainingSeconds);
        }
        
        [Serializable]
        protected class Timer
        {
            [SerializeField] public float remainingSeconds = 0;

            public UnityEvent expired = new UnityEvent();

            public void Update(float deltaTime)
            {
                if (remainingSeconds > 0)
                {
                    remainingSeconds -= deltaTime;
                }
                else
                {
                    remainingSeconds = 0;
                    expired.Invoke();
                }
            }
        }
    }
}