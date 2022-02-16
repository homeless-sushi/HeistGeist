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
            const string masterVolumeParam = "MasterVolume";
            if(PlayerPrefs.HasKey(masterVolumeParam))
            {
                SetVolume(masterVolumeParam,PlayerPrefs.GetFloat(masterVolumeParam));
            }
            
            const string musicVolumeParam = "MusicVolume";
            if(PlayerPrefs.HasKey(musicVolumeParam))
            {
                SetVolume(musicVolumeParam,PlayerPrefs.GetFloat(musicVolumeParam));
            }
            
            const string fxVolumeParam = "FxVolume";
            if(PlayerPrefs.HasKey(fxVolumeParam))
            {
                SetVolume(fxVolumeParam,PlayerPrefs.GetFloat(fxVolumeParam));
            }
        }

        [SerializeField] private AudioMixer masterMixer;

        public void SetVolume(String paramName, float linearVolume)
        {
            masterMixer.SetFloat(paramName, ToDB(linearVolume));
        }

        public void SetPauseScreenEffects(bool on)
        {
            if (on)
            {
                masterMixer.FindSnapshot("MusicLowpassON").TransitionTo(0.1f);
            }
            else
            {
                masterMixer.FindSnapshot("Default").TransitionTo(0.1f);
            }
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
        
        [Header("FX")]
        [SerializeField] private AudioSource fxSource;
        public enum Fx
        {
            Strike,
            PuzzleSolved,
        }
        [SerializeField] private AudioClip[] fxList;
        
        public void PlayFX(Fx fx)
        {
            fxSource.clip = fxList[(int) fx];
            fxSource.Play();
        }

        private static float ToDB(float linear)
        {
            return (float) (Math.Log10(linear) * 20);
        }
    }
}