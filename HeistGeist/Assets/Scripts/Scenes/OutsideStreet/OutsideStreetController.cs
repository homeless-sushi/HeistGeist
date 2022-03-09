using System.Collections.Generic;
using Manager;
using Scenes.OutsideStreet.Data;
using Scenes.OutsideStreet.UI;
using Scenes.VaultArt;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.OutsideStreet
{
    public class OutsideStreetController : GameplaySceneController
    {
        [SerializeField] private KeyKeyholeData[] keysKeyholes;
        [SerializeField] private Key[] keys;
        [SerializeField] private Keyhole keyhole;
        [SerializeField] private Door manhole;

        [Space(20)] 
        [Header("Disable on correct answer")] 
        [SerializeField] private Interactable interactable;
        [SerializeField] private GameObject manholeWalls;
        [SerializeField] private UIInspectManhole uIInspectManhole;

        private void Start()
        {
            FindObjectOfType<TransitionManager>().TransitionIn();
            GameManager.Instance.GameplayRun();
            GameManager.Instance.SoundManager.PlayTrack(SoundManager.Track.GameplayTrack);
            Generate();
        }

        protected override void Generate()
        {
            List<KeyKeyholeData> randomizeKeysKeyholes = new List<KeyKeyholeData>(keys.Length);
            foreach (var keyKeyholeData in Utils.Sample(keysKeyholes, keys.Length))
            {
                randomizeKeysKeyholes.Add(keyKeyholeData);
            }

            int chosenKey = Random.Range(0, keys.Length);
            for (int i = 0; i < keys.Length; i++)
            {
                AssignKeyData(keys[i], randomizeKeysKeyholes[i]);
            }

            keyhole.gameObject.GetComponent<Image>().sprite 
                = randomizeKeysKeyholes[chosenKey].Keyhole;
            keyhole.CorrectKeyNumber = randomizeKeysKeyholes[chosenKey].KeyNumber;

        }

        private void AssignKeyData(Key key, KeyKeyholeData keyData)
        {
            key.KeyNumber = keyData.KeyNumber;
            key.gameObject.GetComponent<Image>().sprite = keyData.Key; 
        }

        public void Answer(bool correct)
        {
            if (correct)
            {
                GameManager.Instance.SoundManager.PlayFX(SoundManager.Fx.PuzzleSolved);
                manhole.Open();
                
                uIInspectManhole.gameObject.SetActive(false);
                interactable.gameObject.SetActive(false);
            }
            else
            {
                Fail(false);
            }
        }
        
        public void EnterDoor()
        {
            manholeWalls.SetActive(true);
            if (GameManager.Instance.GameModeData.CurrentGameMode == GameModeData.GameMode.Story)
            {
                FindObjectOfType<TransitionManager>().TransitionOut(
                    "In the sewers below the bank...",
                    () =>
                    {
                        SceneManager.LoadScene((int) SceneFlow.GetRandomOutsideScene());
                    });
            }
            else
            {
                FindObjectOfType<TransitionManager>().QuitTransition(
                    () => 
                    {
                        GameManager.Instance.GameplayStop();
                        SceneManager.LoadScene((int) Scene.StartScreen);
                    });
            }
        }
    }
}