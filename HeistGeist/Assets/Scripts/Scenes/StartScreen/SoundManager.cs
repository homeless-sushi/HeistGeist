using UnityEngine;
using UnityEngine.UI;

namespace Scenes.StartScreen
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] Slider volumeSlider;

        void Start ()
        {
            if(!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 1);
                Load();
            }
            else
            {
                Load();
            }
        }

        public void ChangeVolume()
        {
            AudioListener.volume = volumeSlider.value;
            Save();
        }

        private void Load()
        {
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        }
   
    }
}
