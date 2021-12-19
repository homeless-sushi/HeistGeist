using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.StartScreen
{
    public class SoundSettings : MonoBehaviour
    {
        [SerializeField] private Slider masterVolumeSlider;

        private void Start()
        {
            if(!PlayerPrefs.HasKey("MasterVolume"))
            {
                Save();
            }
            else
            {
                Load();
            }
        }
        
        public void SetMasterVolume(float volume)
        {
            GameManager.Instance.SoundManager.SetMasterVolume(volume);
            Save();
        }
        
        private void Load()
        {
            masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        }
   
    }
}
