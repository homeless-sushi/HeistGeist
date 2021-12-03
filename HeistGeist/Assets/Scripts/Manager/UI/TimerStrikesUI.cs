using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.UI
{
    public class TimerStrikesUI : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI timerText;
        
        [SerializeField] private StrikesData strikesSprite;
        [SerializeField] private Image[] strikesImages;

        public void SetTime(TimeSpan time)
        {
            timerText.text = time.ToString(@"mm\:ss");
        }
        
        public void SetStrikes(int n)
        {
            if (n < 0 || n > 3)
            {
                throw new Exception($"Invalid strike numbers {n}");
            }

            int i;
            for (i = 0; i < n; i++)
            {
                strikesImages[i].sprite = strikesSprite.StrikeRed;
            }
            for (; i < strikesImages.Length; i++)
            {
                strikesImages[i].sprite = strikesSprite.StrikeWhite;
            }
        }
    }
}
