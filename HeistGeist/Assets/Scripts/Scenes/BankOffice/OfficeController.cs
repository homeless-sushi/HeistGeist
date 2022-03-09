using System.Linq;
using UnityEngine;

namespace Scenes.BankOffice
{
    public class OfficeController : MonoBehaviour
    {
        [SerializeField] private GameObject[] bookcases;
        public GameObject[] Bookcases => bookcases;
        private GameObject[] _activeBookcases;
        
        [SerializeField] private GameObject[] plants;
        public GameObject[] Plants => plants;
        private GameObject[] _activePlants;
        
        [SerializeField] private GameObject[] windows;
        public GameObject[] Windows => windows;
        private GameObject[] _activeWindows;
        
        [SerializeField] private GameObject[] lamps;
        public GameObject[] Lamps => lamps;
        private GameObject[] _activeLamps;

        [SerializeField] private GameObject pinkCarpet;
        [SerializeField] private GameObject blueCarpet;
    
    
        public void ActivateNBookcases(int n)
        {
            if (_activeBookcases != null)
                foreach (GameObject activeBookcase in _activeBookcases)
                {
                    activeBookcase.SetActive(false);
                }

            _activeBookcases = Utils.Sample(bookcases, n).ToArray();
            if (_activeBookcases != null)
                foreach (GameObject activeBookcase in _activeBookcases)
                {
                    activeBookcase.SetActive(true);
                }
        }

        public void ActivateNPlants(int n)
        {
            if (_activePlants != null)
                foreach (GameObject plant in _activePlants)
                {
                    plant.SetActive(false);
                }

            _activePlants = Utils.Sample(plants, n).ToArray();
            if (_activePlants != null)
                foreach (GameObject activePlant in _activePlants)
                {
                    activePlant.SetActive(true);
                }
        }
    
        public void ActivateNWindows(int n)
        {
            if(_activeWindows != null)
                foreach (GameObject activeWindow in _activeWindows)
                {
                    activeWindow.SetActive(false);
                }

            _activeWindows = Utils.Sample(windows, n).ToArray();
            if (_activeWindows != null)
                foreach (GameObject activeWindow in _activeWindows)
                {
                    activeWindow.SetActive(true);
                }
        }
    
        public void ActivateNLamps(int n)
        {
            if (_activeLamps != null)
                foreach (GameObject activeLamp in _activeLamps)
                {
                    activeLamp.SetActive(false);
                }

            _activeLamps = Utils.Sample(lamps, n).ToArray();
            if (_activeLamps != null)
                foreach (GameObject activeLamp in _activeLamps)
                {
                    activeLamp.SetActive(true);
                }
        }
    
        public void ActivatePinkCarpet()
        {
           pinkCarpet.SetActive(true);
        }
        
        public void ActivateBlueCarpet()
        {
           blueCarpet.SetActive(true);
        }
    
    }
}
