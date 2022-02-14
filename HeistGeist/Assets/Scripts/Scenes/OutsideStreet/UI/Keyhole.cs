using UnityEngine;
using UnityEngine.Events;

namespace Scenes.OutsideStreet.UI
{
    public class Keyhole : MonoBehaviour
    {
        [SerializeField] private int correctKeyNumber;

        public int CorrectKeyNumber
        {
            set => correctKeyNumber = value;
            get => correctKeyNumber;
        }

        [SerializeField] private UnityEvent<bool> answer; 
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Key key = other.GetComponent<Key>();
            if (key == null) return;

            bool correctAnswer = key.KeyNumber == correctKeyNumber;
            answer.Invoke(correctAnswer);
        }
    }
}
