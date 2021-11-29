using System;
using UnityEngine;

namespace Scenes.BankLaser
{
    public class BankLaserController : GameplaySceneController
    {
        public GameObject laserPrefab;
        
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
            laser.LightBlink();
            laser.LowerLaserColor(Color.red);
            laser = Instantiate(laserPrefab, new Vector3(9, 6, 0), Quaternion.identity).GetComponent<Laser>();
            laser.TowerType(0);
            laser.TowerShort();
            laser.MiddleLaserColor(Color.blue);
            laser.LightBlink();
            laser = Instantiate(laserPrefab, new Vector3(11, 6, 0), Quaternion.identity).GetComponent<Laser>();
            laser.TowerType(1);
            laser.TowerTall();
            laser.MiddleLaserColor(Color.red);
            laser.UpperLaserColor(Color.yellow);
            laser.LightBlink();
            laser = Instantiate(laserPrefab, new Vector3(13, 6, 0), Quaternion.identity).GetComponent<Laser>();
            laser.TowerType(1);
            laser.TowerShort();
            laser.LowerLaserColor(Color.blue);
            laser.LightBlink();
        }
    }
}