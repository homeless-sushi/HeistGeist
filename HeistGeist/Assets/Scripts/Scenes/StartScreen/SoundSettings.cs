using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.StartScreen
{
    public class SoundSettings : MonoBehaviour
    {
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider fxVolumeSlider;

        private void Start()
        {
            if(!PlayerPrefs.HasKey("MasterVolume"))
            {
                Save("MasterVolume", masterVolumeSlider);
            }
            else
            {
                Load("MasterVolume", masterVolumeSlider);
            }
            
            if(!PlayerPrefs.HasKey("MusicVolume"))
            {
                Save("MusicVolume", musicVolumeSlider);
            }
            else
            {
                Load("MusicVolume", musicVolumeSlider);
            }
            
            if(!PlayerPrefs.HasKey("FxVolume"))
            {
                Save("FxVolume", fxVolumeSlider);
            }
            else
            {
                Load("FxVolume", fxVolumeSlider);
            }
        }
        
        public void SetMasterVolume(float volume)
        {
            GameManager.Instance.SoundManager.SetVolume("MasterVolume", volume);
            Save("MasterVolume", masterVolumeSlider);
        }
        
        public void SetMusicVolume(float volume)
        {
            GameManager.Instance.SoundManager.SetVolume("MusicVolume", volume);
            Save("MusicVolume", musicVolumeSlider);
        }
        
        public void SetFxVolume(float volume)
        {
            GameManager.Instance.SoundManager.SetVolume("FxVolume", volume);
            Save("FxVolume", fxVolumeSlider);
        }
        
        private void Load(string key, Slider slider)
        {
            slider.value = PlayerPrefs.GetFloat(key);
        }

        private void Save(string key, Slider slider)
        {
            PlayerPrefs.SetFloat(key, slider.value);
        }
   
    }
}
