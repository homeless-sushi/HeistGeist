using UnityEngine;

namespace Scenes.BankLaser
{
    public class BankLaserController : GameplaySceneController
    {
        public GameObject laserPrefab;
        
        [SerializeField]
        private FlagGenerator flagGenerator;
        [SerializeField]
        private FlagsChecker flagsChecker;
        
        private void Start()
        {
            Generate();
        }

        protected override void Generate()
        {
            Laser laser;
            laser = Instantiate(laserPrefab, new Vector3(7, 6, 0), Quaternion.identity).GetComponent<Laser>();
            laser.TowerType(0);
            laser.TowerTall();
            laser.Light(LightStatus.Blink);
            laser.LowerLaserColor(Color.red);
            laser = Instantiate(laserPrefab, new Vector3(9, 6, 0), Quaternion.identity).GetComponent<Laser>();
            laser.TowerType(0);
            laser.TowerShort();
            laser.MiddleLaserColor(Color.blue);
            laser.Light(LightStatus.Blink);
            laser = Instantiate(laserPrefab, new Vector3(11, 6, 0), Quaternion.identity).GetComponent<Laser>();
            laser.TowerType(1);
            laser.TowerTall();
            laser.MiddleLaserColor(Color.red);
            laser.UpperLaserColor(Color.yellow);
            laser.Light(LightStatus.Blink);
            laser = Instantiate(laserPrefab, new Vector3(13, 6, 0), Quaternion.identity).GetComponent<Laser>();
            laser.TowerType(1);
            laser.TowerShort();
            laser.LowerLaserColor(Color.blue);
            laser.Light(LightStatus.Blink);
        }
    }
}