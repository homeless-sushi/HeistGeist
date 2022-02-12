using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.BankLaser
{
    public class BankLaserController : GameplaySceneController
    {
        [Space(20)]
        [Header("Lasers")]
        [SerializeField]
        private GameObject laserPrefab;
        [SerializeField]
        private int lasersCount;
        [SerializeField]
        private Vector2[] lasersPositions;
        
        [Space(20)]
        [Header("Colors")]
        [SerializeField]
        private Color redLaserColor;
        [SerializeField]
        private Color blueLaserColor;
        [SerializeField]
        private Color upperLaserColor;
        [SerializeField]
        private Color defaultLaserColor;

        [Space(20)]
        [Header("Flags")]
        [SerializeField]
        private FlagGenerator flagGenerator;
        [SerializeField]
        private FlagsChecker flagsChecker;
        
        private void Start()
        {
            Generate();
            FindObjectOfType<TransitionManager>().TransitionIn();
            GameManager.Instance.GameplayRun();
            GameManager.Instance.SoundManager.PlayTrack(SoundManager.Track.GameplayTrack);
        }

        protected override void Generate()
        {
            foreach (var position in Utils.Sample(lasersPositions, lasersCount))
            {
                var laser = GenerateLaser(position);
            }
        }

        private Laser GenerateLaser(Vector2 position)
        {
            var laser = Instantiate(laserPrefab, position, Quaternion.identity).GetComponent<Laser>();
            var flags = flagGenerator.GetFlags();
            
            // Light
            if((flags & Flags.LightBlink) != 0)
                laser.Light(LightStatus.Blink);
            else if((flags & Flags.LightOn) != 0)
                laser.Light(LightStatus.On);
            else
                laser.Light(LightStatus.Off);
            
            // Colors
            if ((flags & Flags.RedLaser) != 0 && (flags & Flags.BlueLaser) != 0)
            {
                // Red and Blue
                var p = Random.value;
                laser.MiddleLaserColor(p < .5 ? redLaserColor : blueLaserColor);
                laser.LowerLaserColor(p < .5 ? blueLaserColor : redLaserColor);
            }
            else if ((flags & Flags.RedLaser) != 0)
            {
                // Red only
                var p = Random.value;
                laser.MiddleLaserColor(p < 2 / 3f ? redLaserColor : defaultLaserColor);
                laser.LowerLaserColor(p > 1 / 3f ? redLaserColor : defaultLaserColor);
            }
            else if((flags & Flags.BlueLaser) != 0)
            {
                // Blue only
                var p = Random.value;
                laser.MiddleLaserColor(p < 2 / 3f ? blueLaserColor : defaultLaserColor);
                laser.LowerLaserColor(p > 1 / 3f ? blueLaserColor : defaultLaserColor);
            }
            
            // Tower
            if((flags & Flags.ThirdLaser) != 0)
            {
                laser.UpperLaserColor(upperLaserColor);
                laser.TowerTall();
            }
            else
                laser.TowerShort();
            laser.TowerType((flags & Flags.TowerType) != 0 ? 1 : 0);

            laser.expectedState = flagsChecker.ExpectedState(flags);
            laser.collisionEvent.AddListener(LaserCollision);
            
            return laser;
        }
        
        private void LaserCollision()
        {
            Fail(false);
        }
        
        public void EnterDoor()
        {
            if (GameManager.Instance.GameModeData.CurrentGameMode == GameModeData.GameMode.Story)
            {
                FindObjectOfType<TransitionManager>().TransitionOut(
                    "Congratulations!",
                    () => { SceneManager.LoadScene((int) Scene.YouWinScreen); });
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