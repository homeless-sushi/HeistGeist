using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Manager
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        private void Awake()
        {
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                SetMasterVolume(PlayerPrefs.GetFloat("MasterVolume"));
            }
        }

        [SerializeField] private AudioMixer masterMixer;

        public void SetMasterVolume(float linearVolume)
        {
            masterMixer.SetFloat("MasterVolume", ToDB(linearVolume));
        }
        
        public void SetMusicVolume(float linearVolume)
        {
            masterMixer.SetFloat("MusicVolume", ToDB(linearVolume));
        }

        [Header("Game Music")]
        [SerializeField] private AudioSource musicSource;
        public enum Track
        {
            MenuTrack,
            GameplayTrack,
        }
        [SerializeField] private AudioClip[] trackList;
        
        public void PlayTrack(Track track)
        {
            if(musicSource.clip == trackList[(int) track])
                return;

            musicSource.clip = trackList[(int) track];
            musicSource.Play();
        }

        private static float ToDB(float linear)
        {
            return (float) (Math.Log10(linear) * 20);
        }
    }
}