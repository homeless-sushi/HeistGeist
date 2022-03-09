using Scenes.BankOffice.UI;
using Scenes.VaultArt.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Scenes.BankOffice
{
    public class RotatingPaintingFrame : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer paintingSpriteRenderer; //SpriteRenderer for the painting
        [SerializeField] protected SpriteRenderer frameSpriteRenderer; //SpriteRenderer for the frame

        [SerializeField] private int correctRotationAngle;
        public int CorrectRotationAngle { set => correctRotationAngle = value; }

        [SerializeField] [Range(0, 360)] private int currentRotationAngle = 0;
        [SerializeField] private int rotationIncrement = 45;

        private bool _solved = false; //True if the correct answer has been confirmed
        [SerializeField] private UnityEvent<bool> confirmAnswer; //On confirm
        
        [SerializeField] protected PaintingFrameData paintingFrameData; //Data with the painting's sprite

        [SerializeField] protected UIInspectPainting uIInspectPainting; //Component that controls the UI

        public void SetPaintingFrameData(PaintingFrameData paintingFrameData)
        {
            this.paintingFrameData = paintingFrameData;
            paintingSpriteRenderer.sprite = this.paintingFrameData.Painting;
            frameSpriteRenderer.sprite = this.paintingFrameData.FrameData.Frame;
        }

        public void InspectPainting()
        {
            if (uIInspectPainting.gameObject.activeSelf)
            {
                uIInspectPainting.RotateButton.onClick.RemoveListener(RotatePainting);
                uIInspectPainting.EnterButton.onClick.RemoveListener(Confirm);
            }
            else
            {
                uIInspectPainting.SetPaintingFrameAngle(
                    paintingFrameData.UIPainting,
                    paintingFrameData.FrameData.UIFrame,
                    Quaternion.Euler(0, 0, currentRotationAngle));

                if (_solved)
                    uIInspectPainting.Solved();
                else
                    uIInspectPainting.Unsolved();
                   
                uIInspectPainting.RotateButton.onClick.AddListener(RotatePainting);
                uIInspectPainting.EnterButton.onClick.AddListener(Confirm);
            }

            uIInspectPainting.Display();
        }
        public void CloseInspectPainting()
        {
            uIInspectPainting.RotateButton.onClick.RemoveListener(RotatePainting);
            uIInspectPainting.EnterButton.onClick.RemoveListener(Confirm);
            uIInspectPainting.Close();
        }

        private void RotatePainting()
        {
            if (_solved)
                return;
            
            currentRotationAngle += rotationIncrement;
            currentRotationAngle = (currentRotationAngle >= 360) ? currentRotationAngle - 360 : currentRotationAngle;
            Quaternion rotation = Quaternion.Euler(0,0,currentRotationAngle);

            paintingSpriteRenderer.transform.rotation = rotation;
            frameSpriteRenderer.transform.rotation = rotation;
            
            uIInspectPainting.SetPaintingFrameAngle(
                paintingFrameData.UIPainting,
                paintingFrameData.FrameData.UIFrame,
                rotation);
        }

        private void Confirm()
        {
            if (_solved)
                return; 
            
            bool correctAnswer = correctRotationAngle == currentRotationAngle;
            if (correctAnswer)
            {
                _solved = true;
                uIInspectPainting.Solved();
            }
            
            confirmAnswer.Invoke(correctAnswer);
        }
    }
}