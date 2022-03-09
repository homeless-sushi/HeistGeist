using System;
using System.Linq;
using Manager;
using Scenes.VaultArt;
using Scenes.VaultArt.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Scenes.BankOffice
{
    public class BankOfficeController : GameplaySceneController
    {
        private int _correctAnswersCounter = 0;
        [SerializeField] private Door exitDoor;
        
        [Serializable]
        private struct OfficeAndPaintingController
        {
            public OfficeController officeController;
            public RotatingPaintingFrame rotatingPaintingFrame;
        }

        [SerializeField] private OfficeAndPaintingController[] officesAndPaintings;

        [SerializeField] private PaintingFrameData[] portraitPaintings;
        [SerializeField] private PaintingFrameData[] siblingPaintings;
        [SerializeField] private PaintingFrameData[] animalPaintings;
        [SerializeField] private PaintingFrameData[] genericPaintings;

        private void Start()
        {
            FindObjectOfType<TransitionManager>().TransitionIn();
            GameManager.Instance.GameplayRun();
            GameManager.Instance.SoundManager.PlayTrack(SoundManager.Track.GameplayTrack);
            Generate();
        }

        protected override void Generate()
        {
            
            //Choose the 4 offices
            OfficeAndPaintingController[] permutation 
                = Utils.Sample(officesAndPaintings, officesAndPaintings.Length).ToArray();
                
            OfficeAndPaintingController directorOffice = permutation[0];
            OfficeAndPaintingController investmentManagerOffice = permutation[1];
            OfficeAndPaintingController securityOfficerOffice = permutation[2];
            OfficeAndPaintingController accountManagerOffice = permutation[3];

            int leastWindows = 2;
            int mostWindows = 
                Random.Range(leastWindows, directorOffice.officeController.Windows.Length+1);
            int leastBookcases = 3;
            int mostBookcases = 
                Random.Range(leastBookcases, securityOfficerOffice.officeController.Bookcases.Length+1);

            //Director Office
            //Public: Most windows. No lamp. Portrait.
            //Private: One or two carpet.
            directorOffice.officeController.ActivateNWindows(mostWindows);
            directorOffice.officeController.ActivateNBookcases(
                Random.Range(leastBookcases,mostBookcases+1));
            if (Random.value >= 0.5)
            {
                directorOffice.officeController.ActivatePinkCarpet();
                if (Random.value >= 0.5)
                {
                    directorOffice.officeController.ActivateBlueCarpet();
                }
            }
            else
            {
                directorOffice.officeController.ActivateBlueCarpet();
            }
            
            
            directorOffice.rotatingPaintingFrame.CorrectRotationAngle = 180;
            directorOffice.rotatingPaintingFrame.SetPaintingFrameData(
                portraitPaintings[Random.Range(0,portraitPaintings.Length)]);
            
            
            //Investment Manager
            //Public: Plants in his office and in an adjacent office. No carpet or pink carpet.
            //Private: If plants in directors office, at least lamp; otherwise 0 to 2 lamps. No bookcases.
            investmentManagerOffice.officeController.ActivateNPlants(
                Random.Range(1,directorOffice.officeController.Plants.Length)+1);
            
            int investmentManagerOfficeIndex =
                Array.IndexOf(officesAndPaintings, investmentManagerOffice);
            
            int investmentManagerAdjacentOfficeIndex;
            if (investmentManagerOfficeIndex == 0)
            {
                investmentManagerAdjacentOfficeIndex = 1;
            }
            else if (investmentManagerOfficeIndex == 3)
            {
                investmentManagerAdjacentOfficeIndex = 2;
            }
            else
            {
                investmentManagerAdjacentOfficeIndex = Random.Range(1, 3);
            }
            officesAndPaintings[investmentManagerAdjacentOfficeIndex].officeController
                .ActivateNPlants(Random.Range(1,officesAndPaintings[investmentManagerAdjacentOfficeIndex].officeController.Plants.Length+1));
            
            int directorOfficeIndex =
                Array.IndexOf(officesAndPaintings, directorOffice);
            if (investmentManagerAdjacentOfficeIndex == directorOfficeIndex)
            {
                investmentManagerOffice.officeController.ActivateNLamps(
                    Random.Range(1,investmentManagerOffice.officeController.Lamps.Length));
            }
            else
            {
                investmentManagerOffice.officeController.ActivateNLamps(
                    Random.Range(0,investmentManagerOffice.officeController.Lamps.Length));
            }

            if (Random.value >= 0.3)
            {
                investmentManagerOffice.officeController.ActivatePinkCarpet();
            }

            investmentManagerOffice.officeController.ActivateNBookcases(0);
            
            investmentManagerOffice.officeController.ActivateNWindows(
                Random.Range(leastWindows,mostWindows+1));
            
            
            investmentManagerOffice.rotatingPaintingFrame.CorrectRotationAngle = 315;
            investmentManagerOffice.rotatingPaintingFrame.SetPaintingFrameData(
                genericPaintings[Random.Range(0,genericPaintings.Length)]);
            
            //Security Officer
            //Public: Most bookcases. At least a lamp. Painting of siblings.
            //Private:
            securityOfficerOffice.officeController.ActivateNBookcases(mostBookcases);
            securityOfficerOffice.officeController.ActivateNLamps(
                Random.Range(1,securityOfficerOffice.officeController.Lamps.Length));

            securityOfficerOffice.officeController.ActivateNWindows(
                Random.Range(leastWindows,mostWindows+1));
            if (Random.value >= 0.5)
            {
                securityOfficerOffice.officeController.ActivatePinkCarpet();
            }
            else
            {
                securityOfficerOffice.officeController.ActivateBlueCarpet();
            }
                
            
            securityOfficerOffice.rotatingPaintingFrame.CorrectRotationAngle = 45;
            securityOfficerOffice.rotatingPaintingFrame.SetPaintingFrameData(
                siblingPaintings[Random.Range(0,siblingPaintings.Length)]);
            
            
            //Account Manager
            //Public: Blue carpet. Painting of an animal.
            //Private: Most windows.
            accountManagerOffice.officeController.ActivateBlueCarpet();
            accountManagerOffice.officeController.ActivateNWindows(mostWindows);
            
            accountManagerOffice.officeController.ActivateNBookcases(
                Random.Range(leastBookcases,mostBookcases+1));
            accountManagerOffice.officeController.ActivateNLamps(
                Random.Range(0, directorOffice.officeController.Lamps.Length+1));
            
            accountManagerOffice.rotatingPaintingFrame.CorrectRotationAngle = 225;
            accountManagerOffice.rotatingPaintingFrame.SetPaintingFrameData(
                animalPaintings[Random.Range(0,animalPaintings.Length)]);
        }

        public void Answer(bool correct)
        {
            if (correct)
            {
                _correctAnswersCounter++;
                if (_correctAnswersCounter == 4)
                {
                    GameManager.Instance.SoundManager.PlayFX(SoundManager.Fx.PuzzleSolved);
                    exitDoor.Open();
                }
            }
            else
            {
                Fail(false);
            }
        }
        
        public void EnterDoor()
        {
            if (GameManager.Instance.GameModeData.CurrentGameMode == GameModeData.GameMode.Story)
            {
                FindObjectOfType<TransitionManager>().TransitionOut(
                    "Finally, you've reached the vault!",
                    () =>
                    {
                        SceneManager.LoadScene((int) SceneFlow.GetRandomVaultScene());
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