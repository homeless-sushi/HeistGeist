using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.StartScreen
{
    public class GraphicManager : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resolutionsDropdown;
        [SerializeField] private Toggle fullscreenToggle;

        private Resolution[] _resolutions;
        public void Awake()
        {
            //No smaller than 720p in height
            _resolutions = Screen.resolutions.Where(resolution => resolution.height >= 720).ToArray();
        }

        public void Start()
        {
            resolutionsDropdown.ClearOptions();
            resolutionsDropdown.AddOptions(
                _resolutions.Select(resolution => $"{resolution.width}*{resolution.height}")
                    .ToList()
                );

            int currentResolutionIndex = Array.FindIndex(_resolutions, 
                resolution => ( resolution.height == Screen.height 
                                && resolution.width == Screen.width )
            );
            resolutionsDropdown.value = currentResolutionIndex;
            resolutionsDropdown.RefreshShownValue();
            
            fullscreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);
        }

        public void ToggleFullscreen(Boolean fullscreen)
        {
            Screen.fullScreenMode = fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        }

        public void ChangeResolution(Int32 selectedResolutionIndex)
        {
            Resolution selectedResolution = _resolutions[selectedResolutionIndex];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        }
    }
}
